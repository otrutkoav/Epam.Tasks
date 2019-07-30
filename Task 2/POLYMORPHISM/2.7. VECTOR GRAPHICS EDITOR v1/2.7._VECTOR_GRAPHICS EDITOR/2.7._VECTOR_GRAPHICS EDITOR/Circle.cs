using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    public class Circle:Figure,IFigure
    {
        #region Поля и свойства

        public double IntitalX
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
                return this.Radius;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException($"Радиус не может быть меньше или равен 0. Вы ввели {value}");
                }
                this.Radius = value;
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

        public Circle(double x, double y, double radius)
        {
            this.IntitalX = x;
            this.IntitalY = y;
            this.Radius = radius;
            this.Type = "Окружность";
        }
        #endregion

        #region Методы

        public string GetCoordinates()
        {
            return $"Координаты центра окружности: ({this.IntitalX},{this.IntitalY})";
        }

        public double Length()
        {
            return Math.Round(2 * Math.PI * this.Radius, 2);
        }

        public double Area()
        {
            return 0.0;
        }

        public override string ToString()
        {
            return $"Фигура: {this.Type}" + Environment.NewLine+
                $"{this.GetCoordinates()}" + Environment.NewLine +
                $"Радиус окружности: {this.Radius}" + Environment.NewLine +
                $"Длина оркужности: {this.Length()}";
        }

        #endregion
    }
}
