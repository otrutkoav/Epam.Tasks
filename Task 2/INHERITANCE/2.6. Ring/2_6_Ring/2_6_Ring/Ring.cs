using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_6_Ring
{
    public class Ring
    {
        public double X { get; set; }//координата X
        public double Y { get; set; }//координата Y

        double outerRadius;//внешний радиус
        double innerRadius;//внутренний радиус

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            this.X = x;
            this.Y = y;
            this.OuterRadius = outerRadius;
            this.InnerRadius = innerRadius;
        }

        public double InnerRadius
        {
            get
            {
                return innerRadius;
            }
            private set
            {
                if (value>=OuterRadius)
                {
                    throw new RingException("Внутренний радиус не может быть больше или равен внешнему");
                }
                if (value<=0)
                {
                    throw new RingException("Радиус не может быть меньше или равен 0");
                }
                innerRadius = value;
            }
        }

        public double OuterRadius
        {
            get
            {
                return outerRadius;
            }
            private set
            {
                if (value<=InnerRadius)
                {
                    throw new RingException("Внешний радиус не может быть меньше или равен внутреннему");
                }
                if (value<=0)
                {
                    throw new RingException("Радиус не может быть меньше или равен 0");
                }
                outerRadius = value;
            }
        }

        public double InnerAreaCircle
        {
            get
            {
                return (Math.PI * Math.Pow(this.innerRadius, 2));
            }
        }

        public double OuterAreaCircle
        {
            get
            {
                return (Math.PI * Math.Pow(this.outerRadius, 2));
            }
        }

        public double Area
        {
            get
            {
                return Math.Round(this.OuterAreaCircle - this.InnerAreaCircle, 2);
            }
        }

        public double InnerCircumference
        {
            get
            {
                return Math.Round(2*Math.PI*this.innerRadius,2);
            }
        }

        public double OuterCircumference
        {
            get
            {
                return Math.Round(2 * Math.PI * this.outerRadius, 2);
            }
        }

        public double LengthOuterInnerCircumference
        {
            get
            {
                return Math.Round(this.OuterCircumference+this.InnerCircumference,2);
            }
        }

        public static Ring ChangeRingSize(Ring ring, double valueIncrease)
        {      
           Ring newRing = new Ring(ring.X, ring.Y, ring.InnerRadius + valueIncrease, ring.OuterRadius + valueIncrease);
           return newRing;
        }

        public static Ring ChangeRingSize(Ring ring, double valueIncreaseOuterRadius, double valueIncreaseInnerRadius)
        {
            Ring newRing = new Ring(ring.X, ring.Y, ring.InnerRadius + valueIncreaseOuterRadius, ring.OuterRadius + valueIncreaseInnerRadius);
            return newRing;
        }

        public override string ToString()
        {
            return $"Кольцо: " + Environment.NewLine
                + $"Координаты центра: ({this.X},{this.Y})." + Environment.NewLine
                + $"Внутренний радиус: {InnerRadius}" + Environment.NewLine
                + $"Внешний радиус: {OuterRadius}"+Environment.NewLine
                +$"Площадь: {this.Area}"+Environment.NewLine
                +$"Длина внешней и внутренней окружности: {this.LengthOuterInnerCircumference}";
        }

    }
}
