using System;

namespace GeometryLab
{
    public interface ICurve
    {
        void SetCoefficients();
        void PrintCoefficients();
        bool ContainsPoint(double x, double y);
    }

    // ===================== АБСТРАКТНИЙ КЛАС =====================
    public abstract class CurveBase : ICurve
    {
        public abstract void SetCoefficients();
        public abstract void PrintCoefficients();
        public abstract bool ContainsPoint(double x, double y);

        ~CurveBase() { }
    }

    // =========================== ЕЛІПС ===========================
    public class Ellipse : CurveBase
    {
        private double _a;
        private double _b;

        public double A
        {
            get => _a;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Parameter 'a' must be positive.");
                _a = value;
            }
        }

        public double B
        {
            get => _b;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Parameter 'b' must be positive.");
                _b = value;
            }
        }

        public Ellipse() { }

        public Ellipse(double a, double b)
        {
            A = a;
            B = b;
        }

        public override void SetCoefficients()
        {
            A = ReadDouble("Enter a: ");
            B = ReadDouble("Enter b: ");
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Ellipse equation: x²/{A * A} + y²/{B * B} = 1");
        }

        public override bool ContainsPoint(double x, double y)
        {
            double value = (x * x) / (A * A) + (y * y) / (B * B);
            return value <= 1.000000001;
        }

        private double ReadDouble(string message)
        {
            double result;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.Write("Invalid input. Try again: ");
            }
            return result;
        }

        ~Ellipse() { }
    }

    // ===================== КРИВА ДРУГОГО ПОРЯДКУ =====================
    public class QuadraticCurve : CurveBase
    {
        private double _a11, _a12, _a22, _b1, _b2, _c;

        public override void SetCoefficients()
        {
            _a11 = ReadDouble("a11: ");
            _a12 = ReadDouble("a12: ");
            _a22 = ReadDouble("a22: ");
            _b1 = ReadDouble("b1: ");
            _b2 = ReadDouble("b2: ");
            _c  = ReadDouble("c:  ");
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Curve: {_a11}x² + 2({_a12})xy + {_a22}y² + {_b1}x + {_b2}y + {_c} = 0");
        }

        public override bool ContainsPoint(double x, double y)
        {
            double val = _a11 * x * x + 2 * _a12 * x * y + _a22 * y * y + _b1 * x + _b2 * y + _c;
            return Math.Abs(val) < 1e-9;
        }

        private double ReadDouble(string message)
        {
            double result;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Try again: ");
            }
            return result;
        }

        ~QuadraticCurve() { }
    }

    // =========================== MAIN ===========================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Ellipse ===");
            ICurve ellipse = new Ellipse();
            ellipse.SetCoefficients();
            ellipse.PrintCoefficients();

            double x = ReadDouble("Enter X: ");
            double y = ReadDouble("Enter Y: ");

            Console.WriteLine(ellipse.ContainsPoint(x, y)
                ? "Point is INSIDE ellipse"
                : "Point is OUTSIDE ellipse");

            Console.WriteLine("\n=== General Quadratic Curve ===");
            ICurve curve = new QuadraticCurve();
            curve.SetCoefficients();
            curve.PrintCoefficients();

            Console.WriteLine(curve.ContainsPoint(x, y)
                ? "Point satisfies the quadratic curve"
                : "Point does NOT satisfy the curve");
        }

        static double ReadDouble(string message)
        {
            double result;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid number. Try again: ");
            }
            return result;
        }
    }
}
