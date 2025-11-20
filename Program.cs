using System;

namespace LabWork
{
    // ======================== БАЗОВИЙ КЛАС ==========================
    // Рівносторонній трикутник
    class EquilateralTriangle
    {
        public double Side;    // довжина сторони
        public double AngleA;  // кути (в рівносторонньому по 60°)
        public double AngleB;
        public double AngleC;

        public EquilateralTriangle()
        {
            AngleA = AngleB = AngleC = 60;
        }

        // Введення довжини сторони
        public virtual void InitSide()
        {
            C
