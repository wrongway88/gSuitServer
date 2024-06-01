using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace GSuitServer
{
    class SerialPortWrapper
    {
        public delegate void SerialPortError();
        public static SerialPortError _serialPortError = null;

        static private SerialPort _serialPort = null;

        public void Init(string serialPortName)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = serialPortName;
            _serialPort.BaudRate = 9600;
            _serialPort.DtrEnable = true;
            TryOpenPort();
        }

        public void WriteSerialPort(String message)
        {
            try // isOpen doesn't catch if the serial plug was disconnected, causing an exception :(
            {
                lock (_serialPort)
                {
                    if (_serialPort.IsOpen)
                    {
                        _serialPort.Write(message + ";");
                    }
                    else
                    {
                        TryOpenPort();
                    }
                }
            }
            catch(Exception  e)
            {
                if(_serialPortError != null)
                {
                    _serialPortError();
                }

                return;
            }
        }
        
        public String ReadSerialPort()
        {
            String result = "";

            try // isOpen doesn't catch if the serial plug was disconnected, causing an exception :(
            {
                if (_serialPort.IsOpen)
                {
                    result = _serialPort.ReadExisting();
                }
                else
                {
                    TryOpenPort();
                }
            }
            catch (Exception e)
            {
                if (_serialPortError != null)
                {
                    _serialPortError();
                }

                return "";
            }

            return result;
        }

        private void TryOpenPort()
        {
            try
            {
                _serialPort.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
