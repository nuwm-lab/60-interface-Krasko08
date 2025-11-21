using System;

namespace GeometryLab
{
    // Інтерфейс для кривих
    public interface ICurve
    {
        void SetCoefficients();
        void PrintCoefficients();
        bool ContainsPoint(double x, double y);
    }

    // Абстрактний клас
    public abstract class CurveBase : ICurve
    {
        public abstract void SetCoefficients();
        public abstract void PrintCoefficients();
        public abstract bool ContainsPoint(double x, double y);

        ~CurveBase()
        {
            Console.WriteLine("Destructor of CurveBase called");
        }
    }

    // Клас Еліпс
    public class Ellipse : CurveBase
    {
        private double a;
        private double b;

        public Ellipse() { }

        public Ellipse(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override void SetCoefficients()
        {
            Console.Write("Enter a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter b: ");
            b = Convert.ToDouble(Console.ReadLine());
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Ellipse: x^2/{a}^2 + y^2/{b}^2 = 1");
        }

        public override bool ContainsPoint(double x, double y)
        {
            return (x * x) / (a * a) + (y * y) / (b * b) <= 1;
        }

        ~Ellipse()
        {
            Console.WriteLine("Destructor of Ellipse called");
        }
    }

    // Квадратична крива другого порядку
    public class SecondOrderCurve : CurveBase
    {
        private double a11, a12, a22, b1, b2, c;

        public SecondOrderCurve() { }

        public override void SetCoefficients()
        {
            Console.Write("a11: "); a11 = Convert.ToDouble(Console.ReadLine());
            Console.Write("a12: "); a12 = Convert.ToDouble(Console.ReadLine());
            Console.Write("a22: "); a22 = Convert.ToDouble(Console.ReadLine());
            Console.Write("b1: "); b1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("b2: "); b2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("c: "); c = Convert.ToDouble(Console.ReadLine());
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"{a11}x^2 + 2{a12}xy + {a22}y^2 + {b1}x + {b2}y + {c} = 0");
        }

        public override bool ContainsPoint(double x, double y)
        {
            double val = a11 * x * x + 2 * a12 * x * y + a22 * y * y + b1 * x + b2 * y + c;
            return Math.Abs(val) < 1e-6;
        }

        ~SecondOrderCurve()
        {
            Console.WriteLine("Destructor of SecondOrderCurve called");
        }
    }

    // Демонстрація роботи
    class Program
    {
        static void Main()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.SetCoefficients();
            ellipse.PrintCoefficients();

            Console.Write("Enter test point X: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter test point Y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(ellipse.ContainsPoint(x, y)
                ? "Point belongs to ellipse"
                : "Point does NOT belong to ellipse");

            SecondOrderCurve curve = new SecondOrderCurve();
            curve.SetCoefficients();
            curve.PrintCoefficients();
            Console.WriteLine(curve.ContainsPoint(x, y)
                ? "Point satisfies second‑order curve"
                : "Point does NOT satisfy curve equation");
        }
    }
}
