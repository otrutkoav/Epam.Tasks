using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round
{
    public class Round
    {

        double x;//координата на оси абсцисс
        double y;//координата на оси ординат
        double radius;//радиус круга
        double diameter;//диаметр круга

        /// <summary>
        /// Конструктор для содания объекта типа "Круг"
        /// </summary>
        /// <param name="x">Координата центра круга по Абсциссе(X)</param>
        /// <param name="y">Координата центра круга на Ординате(Y)</param>
        /// <param name="radius">Радиус круга, он должен быть больше 0</param>
        public Round(double x, double y,double radius)
        {
            this.x = x;
            this.y = y;
            this.Radius = radius;
            this.diameter = Radius * 2;
        }

        /// <summary>
        /// Координата X
        /// </summary>
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Координата Y
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// Радиус кргуа
        /// </summary>
        public double Radius
        {
            get
            {
                return radius;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.radius = value;
            }
        }

        /// <summary>
        /// Диаметр круга
        /// </summary>
        public double Diameter
        {
            get
            {
                return this.diameter;
            }
        }

        /// <summary>
        /// Длина описанной окружности
        /// </summary>
        public double Circumference
        {
            get
            {
                return CalculeteCircumference();
            }
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        public double Area
        {
            get
            {
                return CalculeteArea();
            }
        }

        //Метод расчитывающий длину окружности
        double CalculeteCircumference()
        {
            double c = 2 * Math.PI * this.radius;
            return Math.Round(c, 2);
        }

        //Метод расчитывающий площадь круга
        double CalculeteArea()
        {
            double area = Math.PI * Math.Pow(radius, 2);
            return Math.Round(area, 2);
        }

        /// <summary>
        /// Метод сообщающий информацию о круге
        /// </summary>
        public void GetInfo()
        {
            Console.WriteLine($"Объект круг: Координаты центра ({x},{y}).\n "
                +$"Радиус {radius}.\n "
                +$"Длина окружности {Circumference}.\n "
                +$"Площадь круга {Area}.\n ");
        }

    }
}
