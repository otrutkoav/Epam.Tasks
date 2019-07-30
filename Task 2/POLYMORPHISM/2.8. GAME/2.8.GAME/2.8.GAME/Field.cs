using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME
{
    public class Field
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Field()
        {
            this.Width = 600;
            this.Height = 450;
        }
    }
}
