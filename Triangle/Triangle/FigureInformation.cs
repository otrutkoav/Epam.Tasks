using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public static class FigureInformation
    {
        public static HashSet<string> GetTypeTriangle(Triangle triangle)
        {
            HashSet<string> typeTriangles = new HashSet<string>();

            if (triangle == null)
            {
                throw new NullReferenceException();
            }

            SidesTriangle sidesTriangle = new SidesTriangle(triangle);

            if (Math.PythagoreanTheorem(sidesTriangle))
            {
                typeTriangles.Add(TypeTriangle.rectangular);
            }

            if (Math.AcuteAngledTriplet(sidesTriangle))
            {
                typeTriangles.Add(TypeTriangle.sharpAngled);
            }
            else
            {
                typeTriangles.Add(TypeTriangle.obtuse);
            }

            if (Math.IsoscelesTriangle(sidesTriangle))
            {
                typeTriangles.Add(TypeTriangle.isosceles);
            }

            if (Math.EquilateralTriangle(sidesTriangle))
            {
                typeTriangles.Add(TypeTriangle.isosceles);
            }

            if (Math.EquilateralTriangle(sidesTriangle))
            {
                typeTriangles.Add(TypeTriangle.isosceles);
            }
            else
            {
                if (!typeTriangles.Contains(TypeTriangle.isosceles))
                {
                    typeTriangles.Add(TypeTriangle.versatile);
                }
            }

            return typeTriangles;
        }
    }

    public static class Math
    {
        /// <summary>
        /// Теорема Пифагора, позволяет узнать является ли трегольник прямоугольным
        /// </summary>
        public static bool PythagoreanTheorem(this SidesTriangle sidesTriangle)
        {
            return (sidesTriangle.BigSide * sidesTriangle.BigSide) == (sidesTriangle.FirstSmallSide * sidesTriangle.FirstSmallSide) + (sidesTriangle.SecondSmallSide * sidesTriangle.SecondSmallSide);
        }

        /// <summary>
        /// Метод, позволяет определить, является ли треугольник остроугольным или тупым
        /// </summary>
        public static bool AcuteAngledTriplet(this SidesTriangle sidesTriangle)
        {
            return (sidesTriangle.BigSide * sidesTriangle.BigSide) < (sidesTriangle.FirstSmallSide * sidesTriangle.FirstSmallSide) + (sidesTriangle.SecondSmallSide * sidesTriangle.SecondSmallSide);
        }

        /// <summary>
        /// Метод, позволяет определить, является ли треугольник равнобедренным
        /// </summary>
        public static bool IsoscelesTriangle(this SidesTriangle sidesTriangle)
        {
            return (sidesTriangle.BigSide == sidesTriangle.FirstSmallSide) || (sidesTriangle.FirstSmallSide == sidesTriangle.SecondSmallSide) || (sidesTriangle.BigSide==sidesTriangle.SecondSmallSide);
        }

        /// <summary>
        /// Метод, позволяет определить, является ли треугольник равносторонним или разносторонним
        /// </summary>
        public static bool EquilateralTriangle(this SidesTriangle sidesTriangle)
        {
            return (sidesTriangle.BigSide == sidesTriangle.FirstSmallSide) && (sidesTriangle.FirstSmallSide == sidesTriangle.SecondSmallSide) && (sidesTriangle.BigSide == sidesTriangle.SecondSmallSide);
        }

    }

    internal static class TypeTriangle
    {
        public static readonly string sharpAngled = "остроуголный";
        public static readonly string rectangular = "прямоугольный";
        public static readonly string obtuse = "тупой";
        public static readonly string isosceles = "равнобедренный";
        public static readonly string equilateral = "равносторонний";
        public static readonly string versatile = "разносторонний";
    }

    public struct SidesTriangle
    {
        public SidesTriangle(Triangle triangle)
        {
            BigSide = triangle.GetMaxSide(out FirstSmallSide, out SecondSmallSide);
        }

        public double BigSide;
        public double FirstSmallSide;
        public double SecondSmallSide;
    }
}
