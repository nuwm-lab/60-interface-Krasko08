using System;

namespace LabWork
{
    // --------------------- ІНТЕРФЕЙС ---------------------
    public interface ITriangle
    {
        double SideA { get; set; }
        double SideB { get; }
        double SideC { get; }
        double AngleA { get; set; }
        double AngleB { get; set; }
        double AngleC { get; }

        double GetPerimeter();
        void PrintInfo();
    }

    // --------------------- АБСТРАКТНИЙ КЛАС ---------------------
    public abstract class TriangleBase : ITriangle
    {
        public abstract double SideA { get; set; }
        public abstract double SideB { get; protected set; }
        public abstract double SideC { get; protected set; }

        public abstract double AngleA { get; set; }
        public abstract double AngleB { get; set; }
        public abstract double AngleC { get; protected set; }

        public abstract double GetPerimeter();

        public abstract void PrintInfo();

        public TriangleBase()
        {
            Console.WriteLine("✔ Створено трикутник (базовий клас)");
        }

        ~TriangleBase()
        {
            Console.WriteLine("✖ Знищено обʼєкт базового класу");
        }
    }

    // --------------------- РІВНОСТОРОННІЙ ТРИКУТНИК ---------------------
    public class EquilateralTriangle : TriangleBase
    {
        private double _side;

        public override double SideA
        {
            get => _side;
            set
            {
                if (value <= 0)
                    throw new Exception("Довжина сторони має бути додатною.");
                _side = value;
                SideB = _side;
                SideC = _side;
                AngleA = AngleB = AngleC = 60;
            }
        }

        public override double SideB { get; protected set; }
        public override double SideC { get; protected set; }

        public override double AngleA { get; set; }
        public override double AngleB { get; set; }
        public override double AngleC { get; protected set; }

        public EquilateralTriangle(double side)
        {
            SideA = side;
            Console.WriteLine("✔ Створено рівносторонній трикутник");
        }

        ~EquilateralTriangle()
        {
            Console.WriteLine("✖ Знищено рівносторонній трикутник");
        }

        public override double GetPerimeter()
        {
            return SideA * 3;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("\n--- Рівносторонній трикутник ---");
            Console.WriteLine($"Сторони: {SideA}, {SideB}, {SideC}");
            Console.WriteLine($"Кути: {AngleA}°, {AngleB}°, {AngleC}°");
            Console.WriteLine($"Периметр = {GetPerimeter()}");
        }
    }

    // --------------------- ПРОСТИЙ ТРИКУТНИК ---------------------
    public class Triangle : TriangleBase
    {
        private double _sideA;
        private double _angleA;
        private double _angleB;

        public override double SideA
        {
            get => _sideA;
            set
            {
                if (value <= 0)
                    throw new Exception("Сторона має бути додатною.");
                _sideA = value;
            }
        }

        public override double SideB { get; protected set; }
        public override double SideC { get; protected set; }

        public override double AngleA
        {
            get => _angleA;
            set
            {
                if (value <= 0 || value >= 180)
                    throw new Exception("Кут має бути у межах (0;180)");
                _angleA = value;
                UpdateThirdAngle();
            }
        }

        public override double AngleB
        {
            get => _angleB;
            set
            {
                if (value <= 0 || value >= 180)
                    throw new Exception("Кут має бути у межах (0;180)");
                _angleB = value;
                UpdateThirdAngle();
            }
        }

        public override double AngleC { get; protected set; }

        private void UpdateThirdAngle()
        {
            AngleC = 180 - AngleA - AngleB;
            if (AngleC <= 0)
                throw new Exception("Сума двох кутів повинна бути < 180.");
            CalculateOtherSides();
        }

        private void CalculateOtherSides()
        {
            double radA = AngleA * Math.PI / 180;
            double radB = AngleB * Math.PI / 180;
            double radC = AngleC * Math.PI / 180;

            SideB = SideA * Math.Sin(radB) / Math.Sin(radA);
            SideC = SideA * Math.Sin(radC) / Math.Sin(radA);
        }

        public Triangle(double side, double angleA, double angleB)
        {
            SideA = side;
            AngleA = angleA;
            AngleB = angleB;

            Console.WriteLine("✔ Створено довільний трикутник");
        }

        ~Triangle()
        {
            Console.WriteLine("✖ Знищено трикутник");
        }

        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("\n--- Довільний трикутник ---");
            Console.WriteLine($"Сторони: A={SideA:F2}, B={SideB:F2}, C={SideC:F2}");
            Console.WriteLine($"Кути: A={AngleA}°, B={AngleB}°, C={AngleC}°");
            Console.WriteLine($"Периметр = {GetPerimeter():F2}");
        }
    }

    // --------------------- MAIN ---------------------
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Рівносторонній
                ITriangle eq = new EquilateralTriangle(10);
                eq.PrintInfo();

                // Довільний
                ITriangle t = new Triangle(12, 40, 70);
                t.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\nГотово!");
        }
    }
}
