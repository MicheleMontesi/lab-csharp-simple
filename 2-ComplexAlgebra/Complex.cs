using System;
using System.Collections.Generic;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        // TODO: fill this class\
        private double _real;
        private double _imaginary;
        public Complex(double real, double imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }
        
        public double Real { get; }
        
        public double Imaginary { get; }

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex num)
        {
            return new Complex(Real + num.Real, Imaginary + num.Imaginary);
        }

        public Complex Minus(Complex num)
        {
            return new Complex(Real - num.Real, Imaginary - num.Imaginary);
        }

        public double Modulus => Math.Sqrt((Real * Real) + (Imaginary * Imaginary));

        public double Phase => Math.Atan2(Imaginary, Real);

        public override string ToString()
        {
            return _real + (_imaginary >= 0 ? " +" : " ") + _imaginary + "i";
        }

        private sealed class RealImaginaryEqualityComparer : IEqualityComparer<Complex>
        {
            public bool Equals(Complex x, Complex y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._real.Equals(y._real) && x._imaginary.Equals(y._imaginary);
            }

            public int GetHashCode(Complex obj)
            {
                return HashCode.Combine(obj._real, obj._imaginary);
            }
        }

        public static IEqualityComparer<Complex> RealImaginaryComparer { get; } = new RealImaginaryEqualityComparer();
    }
}