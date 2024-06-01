using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSuitServer
{
    internal class SerialProtocol
    {
        private static string _challengeMessage = "PUMPITUP";
        private static string _responseMessage = "HITTHEJAM";

        private static string _setPressureMessage = "SET_PRESSURE";
        
        public static string ChallengeMessage
        {
            get { return _challengeMessage; }
        }

        public static string ResponseMessage
        {
            get { return _responseMessage; }
        }

        public static string SetPressureMessage
        {
            get { return _setPressureMessage; }
        }
    }
}
