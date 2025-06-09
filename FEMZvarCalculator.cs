using System;

namespace Calculations
{
    public static class FEMZvarCalculator
    {
        public static double LinearShrinkage(double alpha, double deltaT, double length)
        {
            return alpha * deltaT * length;
        }

        public static double AngularDistortion(double shrinkage, double thickness)
        {
            return (180.0 / Math.PI) * Math.Atan(shrinkage / thickness);
        }
    }
}
