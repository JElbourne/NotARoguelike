using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class Rect
    {
        public Rect(int left, int top, int width, int height)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;

            if (this.Width < 0)
            {
                this.Left += this.Width;
                this.Width *= -1;
            }
            if (this.Height < 0)
            {
                this.Top += this.Height;
                this.Height *= -1;
            }
        }

        public int Left { get; protected set; }
        public int Top { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
    }
}
