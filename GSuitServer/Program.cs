using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using static GSuitServer.GSuit;

namespace GSuitServer
{
    internal static class Program
    {
        static SerialPortWrapper _portWrapper = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GSuit gSuite = new GSuit();

            Application.Run(gSuite);
        }
    }
}
