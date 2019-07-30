using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public class Triangle
    {
        double sideA;
        double sideB;
        double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
            IsExists();
        }

       

        public double SideA
        {
            get
            {
                return sideA;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.sideA = value;
            }
        }

        public double SideB
        {
            get
            {
                return sideB;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.sideB = value;
            }
        }

        public double SideC
        {
            get
            {
                return sideC;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.sideC = value;
            }
        }

        public double Perimetr
        {
            get
            {
                return CalculetePerimetr();
            }
        }

        public double SemiPerimeter
        {
            get
            {
                return CalculeteSemiPerimeter();
            }
        }

        public double Area
        {
            get
            {
                return Math.Round(CalculeteArea(), 2);
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"Объект треугольник.\n"
                +$"Стороны: {sideA}, {sideB}, {sideC}.\n"
                +$"Периметр - {Perimetr}. Площадь - {Area}");
        }

        private void IsExists()
        {
            bool firstCondition = (sideA + sideB) > sideC;
            bool secondCondition = (sideB + sideC) > sideA;
            bool thirdCondition = (sideA + sideC) > sideB;

            if (!firstCondition && secondCondition && thirdCondition)
            {
                throw new TriangleException($"Невозможно создать треугольник со сторонами {sideA}, {sideB}, {sideC}");
            }
        }

        private double CalculeteSemiPerimeter()
        {
            return Perimetr / 2;
        }

        private double CalculetePerimetr()
        {
            return sideA + sideB + sideC;
        }

        private double CalculeteArea()
        {
            return Math.Sqrt(SemiPerimeter * (SemiPerimeter-sideA)*(SemiPerimeter-sideB)*(SemiPerimeter-sideC));
        }

    }
}
