using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    public class Rectangle:Figure,IFigure
    {
        #region Поля и свойства

        double width;
        double height;

        public string Type
        {
            get
            {
                return type;
            }
            private set
            {
                type = value;
            }
        }

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

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("Значение ширины не может быть меньше или равно 0");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("Значение высоты не может быть меньше или равно 0");
                }
                this.height = value;
            }
        }

        #endregion

        #region Конструкторы

        public Rectangle(double x, double y, double width, double height)
        {
            this.IntitalX = x;
            this.IntitalY = y;
            this.Height = height;
            this.Width = width;
            this.Type = IsSquare() ? "Прямоугольник(Квадрат)" : "Прямоугольник";
        }

        #endregion

        #region Методы

        bool IsSquare()
        {
            if (this.width == this.height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Area()
        {
            return Math.Round(this.height * this.width,2);
        }

        public double Length()
        {
            return Math.Round((this.width+this.height)*2,2);
        }

        public string GetCoordinates()
        {
            return $"Координаты вершин следующие:" + Environment.NewLine +
                $"А({this.IntitalX},{this.IntitalY})" + Environment.NewLine +
                $"B({this.IntitalX},{this.IntitalY+this.height})" + Environment.NewLine +
                $"C({this.IntitalX+this.width},{this.IntitalY + this.height})" + Environment.NewLine +
                $"D({this.IntitalX+this.width},{this.IntitalY})";
        }

        public override string ToString()
        {
            return $"Фигура: {this.type}" + Environment.NewLine +
                $"Ширина {this.width}. Высота {this.height}" + Environment.NewLine +
                $"{this.GetCoordinates()}" + Environment.NewLine +
                $"Периметр {this.Length()}. Площадь {this.Area()}"; 
        }

        #endregion
    }
}
