using System;

namespace LabWork
{
    // ======================= ІНТЕРФЕЙС =======================
    public interface IPrintable
    {
        void PrintCoefficients();
        bool Contains(double x, double y);
    }

    // =================== АБСТРАКТНИЙ КЛАС ====================
    public abstract class Conic : IPrintable
    {
        public double A11 { get; protected set; }
        public double A12 { get; protected set; }
        public double A22 { get; protected set; }
        public double B1 { get; protected set; }
        public double B2 { get; protected set; }
        public double C { get; protected set; }

        protected Conic(double a11, double a12, double a22, double b1, double b2, double c)
        {
            A11 = a11;
            A12 = a12;
            A22 = a22;
            B1 = b1;
            B2 = b2;
            C = c;

            Console.WriteLine("✔ Створено криву другого порядку (Conic)");
        }

        ~Conic()
        {
            Console.WriteLine("✖ Знищено обʼєкт Conic");
        }

        public abstract bool Contains(double x, double y);

        public virtual void PrintCoefficients()
        {
            Console.WriteLine("\n--- Коефіцієнти рівняння кривої другого порядку ---");
            Console.WriteLine($"A11 = {A11}, A12 = {A12}, A22 = {A22}");
            Console.WriteLine($"B1 = {B1}, B2 = {B2}");
            Console.WriteLine($"C = {C}");
        }
    }

    // ======================== ЕЛІПС ===========================
    public class Ellipse : Conic
    {
        public double A { get; private set; } // велика піввісь
        public double B { get; private set; } // мала піввісь

        public Ellipse(double a, double b)
            : base(
                  a11: 1 / (a * a),
                  a12: 0,
                  a22: 1 / (b * b),
                  b1: 0,
                  b2: 0,
                  c: -1)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Півосі еліпса повинні бути додатними.");

            A = a;
            B = b;

            Console.WriteLine("✔ Створено еліпс");
        }

        ~Ellipse()
        {
            Console.WriteLine("✖ Знищено еліпс");
        }

        public override bool Contains(double x, double y)
        {
            double value = (x * x) / (A * A) + (y * y) / (B * B);
            return value <= 1;
        }

        public override void PrintCoefficients()
        {
            base.PrintCoefficients();
            Console.WriteLine($"Еліпс: a = {A}, b = {B}");
        }
    }

    // ========================= MAIN ===========================
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPrintable ellipse = new Ellipse(5, 3);

                ellipse.PrintCoefficients();

                Console.WriteLine("\nПеревірка належності точки еліпсу:");

                Console.Write("Введіть x: ");
                double x = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введіть y: ");
                double y = Convert.ToDouble(Console.ReadLine());

                bool inside = ellipse.Contains(x, y);

                Console.WriteLine(inside
                    ? "Точка належить еліпсу."
                    : "Точка не належить еліпсу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\nГотово!");
        }
    }
}
