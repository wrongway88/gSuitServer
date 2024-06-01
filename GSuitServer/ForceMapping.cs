using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSuitServer
{
    internal class ForceMapping
    {
        private static float _minForce = 1.0f;
        private static float _maxForce = 10.0f;

        private static float _minPressure = 0.0f;
        private static float _maxPressure = 3000.0f;

        public static float GForceToPressure(float gForce)
        {
            float result = 0.0f;

            gForce = Math.Min(gForce, _maxForce);
            gForce = Math.Max(gForce, _minForce);

            float factor = (gForce - _minForce) / (_maxForce - _minForce);

            result = ((_maxPressure - _minPressure) * factor) + _minPressure;

            return result;
        }
    }
}
