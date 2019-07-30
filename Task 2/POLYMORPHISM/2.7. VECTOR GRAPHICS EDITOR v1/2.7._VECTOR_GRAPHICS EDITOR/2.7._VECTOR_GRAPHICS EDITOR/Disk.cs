using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    public class Disk : Figure, IFigure
    {
        #region Поля и свойства

        double radius;

        public double IntintalX
        {
            get
            {
                return this.intitalX;
            }
            private set
            {
                this.intitalX = value;
            }
        }

        public double IntitalY
        {
            get
            {
                return this.intitalY;
            }
            private set
            {
                this.intitalY = value;
            }
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException($"Радиус не может быть меньше или равен 0. Вы указали радиус {value}");
                }
                this.radius = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        #endregion

        #region Конструкторы

        public Disk(double x, double y, double radius)
        {
            this.IntintalX = x;
            this.IntitalY = y;
            this.Radius = radius;
            this.Type = "Круг";
        }

        #endregion

        #region Методы

        public string GetCoordinates()
        {
            return $"Координаты центра круга: ({this.IntintalX},{this.IntitalY})";
        }

        public double Area()
        {
            return Math.Round(Math.PI*(Math.Pow(this.radius,2)), 2);
        }

        public double Length()
        {
            return 0.0;
        }

        public override string ToString()
        {
            return $"Фигура: {this.type}" +Environment.NewLine+
                $"{this.GetCoordinates()}" + Environment.NewLine +
                $"Радиус: {this.Radius}" + Environment.NewLine +
                $"Площадь: {this.Area()}";
        }
        #endregion
    }
}
