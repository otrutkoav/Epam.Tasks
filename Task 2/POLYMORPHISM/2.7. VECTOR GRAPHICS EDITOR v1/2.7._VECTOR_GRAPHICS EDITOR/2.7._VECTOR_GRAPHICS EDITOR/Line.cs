using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    public class Line : Figure, IFigure
    {
        #region Поля и свойства

        double endX { get; set; }
        double endY { get; set; }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
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

        public double EndX
        {
            get
            {
                return this.endX;
            }
            private set
            {
                this.endX = value;
            }
        }

        public double EndY
        {
            get
            {
                return this.endY;
            }
            private set
            {
                this.endY = value;
            }
        }

        #endregion

        #region Конструкторы 

        public Line(double x, double y, double endX, double endY)
        {
            this.IntitalX = x;
            this.IntitalY = y;
            this.endX = EndX;
            this.endY = EndY;
            this.Type = "Линия";
        }

        #endregion

        #region Методы
        public double Length()
        {
            var result = Math.Pow(this.endX-this.IntitalX,2) + Math.Pow(this.endY-this.IntitalY,2);
            result = Math.Sqrt(result);
            return Math.Round(result, 2);
        }

        public double Area()
        {
            return 0.0;
        }

        public string GetCoordinates()
        {
            return $"Координаты точки А({this.IntitalX},{this.IntitalY})" +Environment.NewLine+
                $"Координаты точки В({this.endX},{this.endY})";
        }

        public double TiltAngleStraight()
        {
            double k = (this.endY - this.IntitalY / this.endX - this.IntitalX);
            double angle = Math.Atan(k);
            return Math.Round(angle, 2);
        }

        public override string ToString()
        {
            return $"Фигура {this.Type}" +Environment.NewLine+
                $"{this.GetCoordinates()}" + Environment.NewLine +
                $"Длина: {this.Length()}" + Environment.NewLine +
                $"Угол наклона относительно оси абсцисс: {this.TiltAngleStraight()}";
        }

        #endregion
    }
}
