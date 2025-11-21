using System;

namespace GeometryLab
{
    public interface ICurve
    {
        void SetCoefficients();
        void PrintCoefficients();
        bool ContainsPoint(double x, double y);
    }

    public abstract class CurveBase : ICurve
    {
        public abstract void SetCoefficients();
        public abstract void PrintCoefficients();
        public abstract bool ContainsPoint(double x, double y);

        ~CurveBase() { }
    }

    public class Ellipse : CurveBase
    {
        private double _a;
        private double _b;

        public double A
        {
            get => _a;
            set { if (value > 0) _a = value; }
        }

        public double B
        {
            get => _b;
            set { if (value > 0) _b = value; }
        }

        public Ellipse() { }

        public Ellipse(double a, double b)
        {
            A = a;
            B = b;
        }

        public override void SetCoefficients()
        {
            Console.Write("Enter a: ");
            A = double.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            B = double.Parse(Console.ReadLine());
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Ellipse: x^2/{A}^2 + y^2/{B}^2 = 1");
        }

        public override bool ContainsPoint(double x, double y)
        {
            double value = (x * x) / (A * A) + (y * y) / (B * B);
            return value <= 1.000000001;
        }

        ~Ellipse() { }
    }

    public class QuadraticCurve : CurveBase
    {
        private double _a11, _a12, _a22, _b1, _b2, _c;

        public override void SetCoefficients()
        {
            Console.Write("a11: "); _a11 = double.Parse(Console.ReadLine());
            Console.Write("a12: "); _a12 = double.Parse(Console.ReadLine());
            Console.Write("a22: "); _a22 = double.Parse(Console.ReadLine());
            Console.Write("b1: "); _b1 = double.Parse(Console.ReadLine());
            Console.Write("b2: "); _b2 = double.Parse(Console.ReadLine());
            Console.Write("c: "); _c = double.Parse(Console.ReadLine());
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"{_a11}x^2 + 2{_a12}xy + {_a22}y^2 + {_b1}x + {_b2}y + {_c} = 0");
        }

        public override bool ContainsPoint(double x, double y)
        {
            double val = _a11 * x * x + 2 * _a12 * x * y + _a22 * y * y + _b1 * x + _b2 * y + _c;
            return Math.Abs(val) < 1e-9;
        }

        ~QuadraticCurve() { }
    }

    class Program
    {
        static void Main()
        {
            ICurve ellipse = new Ellipse();
            ellipse.SetCoefficients();
            ellipse.PrintCoefficients();

            Console.Write("Enter X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter Y: ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine(ellipse.ContainsPoint(x, y) ? "Point is inside ellipse" : "Point is outside ellipse");

            ICurve curve = new QuadraticCurve();
            curve.SetCoefficients();
            curve.PrintCoefficients();
            Console.WriteLine(curve.ContainsPoint(x, y) ? "Point satisfies quadratic curve" : "Point does NOT satisfy curve");
        }
    }
}
