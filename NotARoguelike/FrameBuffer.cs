using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class FrameBuffer
    {
        public FrameBuffer(int left, int top, int width, int height)
        {
            _instance = this;

            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
            Clear();
        }

        static public FrameBuffer Instance
        {
            get { return _instance; }
        }

        static private FrameBuffer _instance;
        private int Left;
        private int Top;
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        //private Chixel[,] chixels;

        private int lastWindowWidth = -1;
        private int lastWindowHeight = -1;

        public void Clear()
        {
            Console.Clear();
            //chixels = new Chixel[this.Width, this.Height];
        }
    }
}
