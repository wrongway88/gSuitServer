using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSuitServer
{
    public partial class GSuit : Form
    {
        SerialPortWrapper _portWrapper = null;

        public delegate void WriteToSerialPortCallback(String message);
        public WriteToSerialPortCallback _writeToSerialPortCallback = null;

        private long _lastSerialWrite = 0;

        Thread _socketThread = null;
        Thread _bufferThread = null;

        public GSuit()
        {
            InitializeComponent();

            _lastSerialWrite = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            Thread initThread = new Thread(Initialize);
            initThread.Start();
        }

        private void Initialize()
        {
            InitSerialConnection();

            SerialPortWrapper._serialPortError += OnSerialPortLost;

            _socketThread = new Thread(new ThreadStart(AsynchronousSocketListener.StartListening));
            _socketThread.Start();

            MessageBuffer.IsRunning = true;
            _bufferThread = new Thread(new ThreadStart(MessageBuffer.Run));
            _bufferThread.Start();
        }

        public void SetDebugText(String text)
        {
            if (textBox_debugOutput.InvokeRequired)
            {
                Invoke(new Action<string>(SetDebugText), new object[] { text });
                return;
            }

            textBox_debugOutput.Text = text;
        }

        public void WriteDebugLine(String text)
        {
            long nowMilli = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            if (textBox_debugOutput.InvokeRequired)
            {
                Invoke(new Action<string>(WriteDebugLine), new object[] { text });
                return;
            }

            textBox_debugOutput.AppendText(Environment.NewLine);
            textBox_debugOutput.AppendText((nowMilli - _lastSerialWrite).ToString() + ": " + text);
            _lastSerialWrite = nowMilli;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            SetDebugText("");
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            String text = textBox_debugInput.Text;
            int number = 0;
            // if(int.TryParse(text, out number))
            {
                WriteDebugLine("Debug to serial: " + text);

                _writeToSerialPortCallback.Invoke(text);
            }
        }

        private void trackBar_debugForce_Scroll(object sender, EventArgs e)
        {
            float val = (float)trackBar_debugForce.Value;

            float pressure = ForceMapping.GForceToPressure(val);

            _writeToSerialPortCallback.Invoke(SerialProtocol.SetPressureMessage + pressure.ToString());
        }

        void InitSerialConnection()
        {
        bool found = false;

        while (found == false)
        {
            string[] portNames = SerialPort.GetPortNames();

            foreach (string portName in portNames)
            {
                try
                {
                    SerialPort serialPort = new SerialPort();
                    serialPort.PortName = portName;
                    serialPort.BaudRate = 9600;
                    serialPort.DtrEnable = true;
                    serialPort.Open();

                    if (serialPort.IsOpen)
                    {
                        serialPort.Write(SerialProtocol.ChallengeMessage + ";");

                        Thread.Sleep(500);

                        string response = serialPort.ReadExisting();

                        serialPort.Close();

                        if (response == (SerialProtocol.ResponseMessage + ";\r\n"))
                        {
                            _portWrapper = new SerialPortWrapper();
                            _portWrapper.Init(portName);

                            AsynchronousSocketListener._socketCallback += MessageBuffer.SocketCallback;
                            MessageBuffer._writeToSerialPortCallback += _portWrapper.WriteSerialPort;
                            MessageBuffer._debugPrintCallback += WriteDebugLine;
                            MessageBuffer._serialReadCallback += _portWrapper.ReadSerialPort;
                            _writeToSerialPortCallback = _portWrapper.WriteSerialPort;

                            WriteDebugLine("GSuit found at " + portName);

                            found = true;

                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

            if (found == false)
            {
                WriteDebugLine("Failed to find GSuite. Check USB connection.");
            }
        }

        private void GSuite_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBuffer.IsRunning = false;
            _bufferThread.Join();
            _socketThread.Join();
        }

        private void OnSerialPortLost()
        {
            WriteDebugLine("Serial Connection lost. Attempting reconnect...");

            InitSerialConnection();
        }
    }
}
