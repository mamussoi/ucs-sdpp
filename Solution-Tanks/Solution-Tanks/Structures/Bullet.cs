using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame
{
    class Bullet
    {
        GameConstants gc = new GameConstants();

        // Attributes
        protected int vertical;
        protected int horizontal;
        protected int direction;
        protected bool isActive;

        // Property for vertical position
        public int Vertical
        {
            get { return vertical; }
            set { vertical = value; }
        }

        // Property for horizontal position
        public int Horizontal
        {
            get { return horizontal; }
            set { horizontal = value; }
        }

        // Property for direction
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        // Property for isActive
        public bool IsActive
        {
            get { return isActive; }
        }

        // Constructor for bullet
        public Bullet(int h, int v, int d)
        {
            vertical = v;
            horizontal = h;
            direction = d;
            isActive = true;
        }

        // Method to move bullet
        public void move()
        {
            switch (direction)
            {
                case 0: // Bullet moves up
                    vertical -= gc.BulletSpeed;
                    break;
                case 1: // Bullet moves right
                    horizontal += gc.BulletSpeed;
                    break;
                case 2: // Bullet moves down
                    vertical += gc.BulletSpeed;
                    break;
                case 3: // Bullet moves left
                    horizontal -= gc.BulletSpeed;
                    break;
            }
        }

        // Override toString
        public override string ToString()
        {
            return "Bullet - Location: " + horizontal + "," + vertical +
                " Direction: " + direction + " Is Active: " + isActive;
        }
    }
}
