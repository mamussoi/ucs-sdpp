using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame
{
    class Wall
    {
        // Attributes
        private int vertical;
        private int horizontal;

        // Constructor
        public Wall(int h, int v)
        {
            horizontal = h;
            vertical = v;
        }
        // Property for vertical position
        public int Vertical
        {
            get { return vertical; }
        }

        // Property for horizontal position
        public int Horizontal
        {
            get { return horizontal; }
        }

        // Override toString
        public override string ToString()
        {
            return "Wall - Location: " + horizontal + "," + vertical;
        }
    }
}
