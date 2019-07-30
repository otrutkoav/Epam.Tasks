using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    public class Ring : Figure, IFigure
    {
        #region Поля и свойства

        double innerRadius;
        double outerRadius;

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

        public double InnerRadius
        {
            get
            {
                return this.innerRadius;
            }
            private set
            {
                if (value >= this.OuterRadius)
                {
                    throw new ArgumentOutOfRangeException("Внутренний радиус не может быть больше или равен внешнему");
                }
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Радиус не может быть меньше или равен 0");
                }
                this.innerRadius = value;
            }
        }

        public double OuterRadius
        {
            get
            {
                return this.outerRadius;
            }
            private set
            {
                if (value <= this.InnerRadius)
                {
                    throw new ArgumentOutOfRangeException("Внешний радиус не может быть меньше или равен внутреннему");
                }
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Радиус не может быть меньше или равен 0");
                }
                this.outerRadius = value;
            }
        }

        #endregion

        #region Конструкторы

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            this.IntitalX = x;
            this.IntitalY = y;
            this.OuterRadius = outerRadius;
            this.InnerRadius = innerRadius;
            this.Type = "Кольцо";
        }

        #endregion

        #region Методы

        public string GetCoordinates()
        {
            return $"Координаты центра кольца: ({this.intitalX}, {this.intitalY})";
        }

        double InnerAreaCircle
        {
            get
            {
                return (Math.PI * Math.Pow(this.innerRadius, 2));
            }
        }

        double OuterAreaCircle
        {
            get
            {
                return (Math.PI * Math.Pow(this.outerRadius, 2));
            }
        }

        public double Area()
        {
            return Math.Round(this.OuterAreaCircle - this.InnerAreaCircle, 2);
        }

        public double Length()
        {
            return 0.0;
        }

        public override string ToString()
        {
            return $"Фигура: {this.type}" + Environment.NewLine+
                $"{this.GetCoordinates()}" + Environment.NewLine +
                $"Внутренний радиус: {this.InnerRadius}. Внешний радиус: {this.OuterRadius}" + Environment.NewLine +
                $"Площадь: {this.Area()}";
        }
        #endregion
    }
}
