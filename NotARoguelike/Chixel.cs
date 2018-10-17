﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class Chixel
    {
        public Chixel(char glyph, ConsoleColor fg_color = ConsoleColor.White, ConsoleColor bg_color = ConsoleColor.Black)
        {
            this.Glyph = glyph;
            this.ForegroundColor = fg_color;
            this.BackgroundColor = bg_color;
            this.Dirty = true;
        }

        public Chixel(Chixel other)
        {
            this.Glyph = other.Glyph;
            this.ForegroundColor = other.ForegroundColor;
            this.BackgroundColor = other.BackgroundColor;
            this.Dirty = true;
        }

        public char Glyph { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public bool Dirty { get; set; }
    }
}
