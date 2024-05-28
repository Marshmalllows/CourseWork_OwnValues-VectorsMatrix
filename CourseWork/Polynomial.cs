using System;

namespace CourseWork
{
    public class Polynomial
    {
        private readonly double[] _coefficients;

        private readonly int _power;

        public Polynomial(int power, double[] coefficients)
        {
            _power = power;
            _coefficients = new double[power];
            for (var i = 0; i < power; i++)
            {
                _coefficients[i] = coefficients[i];
            }
        }

        public double Function(double x)
        {
            var result = Math.Pow(x, _power);
            for (var i = _power - 1; i >= 2; i--)
            {
                result -= Math.Pow(x, i) * _coefficients[_power - i - 1];
            }

            result -= x * _coefficients[_power - 2];
            result -= _coefficients[_power - 1];

            return result;
        }
        
        public double BinarySearchRoot(double a, double b, double epsilon)
        {
            while (Math.Abs(b - a) > epsilon)
            {
                var midpoint = (a + b) / 2;
                if (Math.Sign(Function(a)) != Math.Sign(Function(midpoint)))
                {
                    b = midpoint;
                }
                else
                {
                    a = midpoint;
                }
            }
            return (a + b) / 2;
        }
    }
}