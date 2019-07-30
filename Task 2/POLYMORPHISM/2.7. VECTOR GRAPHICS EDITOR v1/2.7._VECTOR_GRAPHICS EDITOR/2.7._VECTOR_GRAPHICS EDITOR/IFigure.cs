using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    interface IFigure
    {
        double Length();
        double Area();
        string GetCoordinates();
    }
}
