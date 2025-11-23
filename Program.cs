using System;

namespace LabWork
{
    // ======================= ІНТЕРФЕЙС =======================
    public interface ICurve
    {
        void SetCoefficients();
        void PrintCoefficients();
        bool ContainsPoint(double x, double y);
    }

    // =================== АБСТРАКТНИЙ КЛАС ====================
    public abstract class CurveBase : ICurve
    {
        public abstract void SetCoefficients();
        public abstract void PrintCoefficients();
        public abstract bool ContainsPoint(double x, double y);

        public CurveBase()
        {
            Console.WriteLine("Викликано конструктор CurveBase");
        }

        ~CurveBase()
        {
            Console.WriteLine("Викликано деструктор CurveBase");
        }
    }

    // ======================== КЛАС ЕЛІПС ======================
    // рівняння: x²/a² + y²/b² = 1
    public class Ellipse : CurveBase
    {
        private double a;
        private double b;

        public Ellipse() : base()
        {
            Console.WriteLine("Створено Ellipse");
        }

        ~Ellipse()
        {
            Console.WriteLine("Знищено Ellipse");
        }

        public override void SetCoefficients()
        {
            Console.Write("Введіть a: ");
            a = double.Parse(Console.ReadLine());

            Console.Write("Введіть b: ");
            b = double.Parse(Console.ReadLine());
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Еліпс: x^2/{a}^2 + y^2/{b}^2 = 1");
        }

        public override bool ContainsPoint(double x, double y)
        {
            double left = (x * x) / (a * a) + (y * y) / (b * b);
            return Math.Abs(left - 1.0) < 0.0001 || left < 1.0; 
        }
    }

    // ============= КРИВА ДРУГОГО ПОРЯДКУ =====================
    // a11*x^2 + 2*a12*x*y + a22*y^2 + b1*x + b2*y + c = 0
    public class SecondOrderCurve : CurveBase
    {
        private double a11, a12, a22, b1, b2, c;

        public SecondOrderCurve() : base()
        {
            Console.WriteLine("Створено SecondOrderCurve");
        }

        ~SecondOrderCurve()
        {
            Console.WriteLine("Знищено SecondOrderCurve");
        }

        public override void SetCoefficients()
        {
            Console.Write("a11 = ");
            a11 = double.Parse(Console.ReadLine());

            Console.Write("a12 = ");
            a12 = double.Parse(Console.ReadLine());

            Console.Write("a22 = ");
            a22 = double.Parse(Console.ReadLine());

            Console.Write("b1 = ");
            b1 = double.Parse(Console.ReadLine());

            Console.Write("b2 = ");
            b2 = double.Parse(Console.ReadLine());

            Console.Write("c = ");
            c = double.Parse(Console.ReadLine());
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine(
                $"Крива 2-го порядку: {a11}x^2 + 2*{a12}xy + {a22}y^2 + {b1}x + {b2}y + {c} = 0"
            );
        }

        public override bool ContainsPoint(double x, double y)
        {
            double value = a11 * x * x +
                           2 * a12 * x * y +
                           a22 * y * y +
                           b1 * x +
                           b2 * y +
                           c;

            return Math.Abs(value) < 0.0001; 
        }
    }

    // ======================== MAIN ============================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЕЛІПС ===");
            Ellipse ellipse = new Ellipse();
            ellipse.SetCoefficients();
            ellipse.PrintCoefficients();

            Console.Write("\nВведіть x точки: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введіть y точки: ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine(
                ellipse.ContainsPoint(x, y)
                    ? "Точка належить еліпсу"
                    : "Точка НЕ належить еліпсу"
            );

            Console.WriteLine("\n=== КРИВА ДРУГОГО ПОРЯДКУ ===");
            SecondOrderCurve curve = new SecondOrderCurve();
            curve.SetCoefficients();
            curve.PrintCoefficients();

            Console.WriteLine(
                curve.ContainsPoint(x, y)
                    ? "Точка належить кривій 2-го порядку"
                    : "Точка НЕ належить кривій 2-го порядку"
            );
        }
    }
}
