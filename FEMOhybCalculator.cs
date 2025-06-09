using System;

namespace Calculations
{
    public static class FEMOhybCalculator
    {
        public static double SpringbackAngle(double angle, double Re, double E, double t, double r)
        {
            double ratio = Re / E;
            double correction = ratio * (t / (2 * r)) * angle;
            return angle - correction;
        }

        public static double BendAllowance(double angle, double r, double t, double k)
        {
            return (Math.PI * (r + k * t) * angle) / 180.0;
        }

        public static double BendDeduction(double a, double b, double BA)
        {
            return a + b - BA;
        }
    }
}
