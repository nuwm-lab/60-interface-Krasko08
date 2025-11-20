using System;

namespace LabWork
{
    // ================== ІНТЕРФЕЙС =====================
    public interface ITriangle
    {
        double Perimeter();
        void PrintInfo();
    }

    // ================== АБСТРАКТНИЙ КЛАС =====================
    public abstract class TriangleBase : ITriangle
    {
        public double SideA { get; protected set; }
        public double SideB { get; protected set; }
        public double SideC { get; protected set; }

        public double AngleA { get; protected set; }
        public double AngleB { get; protected set; }
        public double AngleC { get; protected set; }

        public TriangleBase()
        {
            Console.WriteLine("► Конструктор TriangleBase");
        }

        ~TriangleBase()
        {
            Console.WriteLine("► Деструктор TriangleBase");
        }

        public abstract void CalculateOtherParameters();  
        public abstract double Perimeter();

        public virtual void PrintInfo()
        {
            Console.WriteLine("\n--- Інформація про трикутник ---");
            Console.WriteLine($"Сторони: A={SideA:F3}, B={SideB:F3}, C={SideC:F3}");
            Console.WriteLine($"Кути: A={AngleA:F3}, B={AngleB:F3}, C={AngleC:F3}");
            Console.WriteLine($"Периметр = {Perimeter():F3}");
        }
    }


    // ================== РІВНОСТОРОННІЙ ТРИКУТНИК =====================
    public class EquilateralTriangle : TriangleBase
    {
        public EquilateralTriangle(double side)
        {
            Console.WriteLine("► Конструктор EquilateralTriangle");
            SideA = SideB = SideC = side;

            AngleA = AngleB = AngleC = 60;
        }

        ~EquilateralTriangle()
        {
            Console.WriteLine("► Деструктор EquilateralTriangle");
        }

        public override void CalculateOtherParameters()
        {
            // У рівностороннього трьохкутника все вже відоме
        }

        public override double Perimeter() => SideA * 3;
    }


    // ================== ЗАГАЛЬНИЙ ТРИКУТНИК (одна сторона + 2 кути) =====================
    public class GeneralTriangle : TriangleBase
    {
        public GeneralTriangle(double knownSide, double angleAdjacent1, double angleAdjacent2)
        {
            Console.WriteLine("► Конструктор GeneralTriangle");

            SideA = knownSide;
            AngleB = angleAdjacent1;
            AngleC = angleAdjacent2;
            AngleA = 180 - AngleB - AngleC;

            if (AngleA <= 0)
                throw new Exception("Сума двох заданих кутів ≥ 180°. Трикутник неможливий.");

            CalculateOtherParameters();
        }

        ~GeneralTriangle()
        {
            Console.WriteLine("► Деструктор GeneralTriangle");
        }

        public override void CalculateOtherParameters()
        {
            double radA = AngleA * Math.PI / 180;
            double radB = AngleB * Math.PI / 180;
            double radC = AngleC * Math.PI / 180;

            // Закон синусів
            SideB = SideA * Math.Sin(radB) / Math.Sin(radA);
            SideC = SideA * Math.Sin(radC) / Math.Sin(radA);
        }

        public override double Perimeter() => SideA + SideB + SideC;
    }


    // ================== MAIN =====================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрація роботи з абстрактними класами та інтерфейсами ===");

            // ===== Рівносторонній трикутник =====
            EquilateralTriangle eq = new EquilateralTriangle(10);
            eq.CalculateOtherParameters();
            eq.PrintInfo();

            // ===== Загальний трикутник =====
            GeneralTriangle gt = new GeneralTriangle(12, 50, 60);
            gt.PrintInfo();

            Console.WriteLine("\nПрограма виконана!");
        }
    }
}
