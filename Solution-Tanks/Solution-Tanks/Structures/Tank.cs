using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame
{
    class Tank
    {
        GameConstants gc = new GameConstants();

        // Attributes
        private Player owner;
        private int vertical;
        private int horizontal;
        private int direction;
        private int hits;
        private Bullet bullet = null;
        private bool canFire;

        // Constructor to set Tank
        public Tank(Player p, int d, int h, int v)
        {
            owner = p;
            vertical = v;
            horizontal = h;
            direction = d;
            canFire = true;
            hits = 0;
        }

        // Property for owner
        public Player Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        // Property for vertical
        public int Vertical
        {
            get { return vertical; }
            set { vertical = value; }
        }

        // Property for horizontal
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

        // Property for hits
        public int Hits
        {
            get { return hits; }
        }

        // Property for canFire
        public bool CanFire
        {
            get { return canFire; }
            set { canFire = value; }
        }

        // Property for bullet
        public Bullet TankBullet
        {
            get { return bullet; }
        }

        // Method to adjust health
        public void takeHit()
        {
            hits++;
        }

        // Method to indicate if tank is dead
        public bool isDead()
        {
            if (hits > 1) return true;
            return false;
        }

        // Method to move tank
        public void move(ConsoleKeyInfo[] array)
        {
            // Reads each key in array
            for (int i = 0; i < array.Length; i++)
            {
                if (owner.PlayerID == 1)
                {
                    // Determines movement and direction of tank
                    switch (array[i].Key)
                    {
                        // Move tank 1 up
                        case ConsoleKey.E:
                            vertical -= gc.TankSpeed;
                            break;
                        // Move tank 1 right
                        case ConsoleKey.F:
                            horizontal += gc.TankSpeed;
                            break;
                        // Move tank 1 down
                        case ConsoleKey.D:
                            vertical += gc.TankSpeed;
                            break;
                        // Move tank 1 left
                        case ConsoleKey.S:
                            horizontal -= gc.TankSpeed;
                            break;
                        // Fire bullet
                        case ConsoleKey.A:
                            if (canFire)
                            {
                                bullet = new Bullet(vertical + gc.BulletWidth, horizontal + gc.BulletHeight, direction);
                            }
                            break;
                    }
                }
                else
                {
                    switch (array[i].Key)
                    {
                        // Move tank 2 up
                        case ConsoleKey.I:
                            vertical -= gc.TankSpeed;
                            break;
                        // Move tank 2 right
                        case ConsoleKey.L:
                            horizontal += gc.TankSpeed;
                            break;
                        // Move tank 2 down
                        case ConsoleKey.K:
                            vertical += gc.TankSpeed;
                            break;
                        // Move tank 2 left
                        case ConsoleKey.J:
                            horizontal -= gc.TankSpeed;
                            break;
                        // Fire bullet
                        case ConsoleKey.H:
                            if (canFire)
                            {
                                bullet = new Bullet(horizontal + gc.BulletWidth, vertical + gc.BulletHeight, direction);
                            }
                            break;
                    }
                }
            }
        }

        // Override toString
        public override string ToString()
        {
            return "Tank - Direction: " + direction + " Location: " + horizontal +
                "," + vertical + " Hits: " + hits + " Can Fire: " + canFire;
        }
    }
}
