using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame
{
    class GameConstants
    {
        private const int GAME_WIDTH = 800;
        private const int GAME_HEIGHT = 600;
        private const int IMAGE_WIDTH = 60;
        private const int IMAGE_HEIGHT = 60;
        private const int BULLET_WIDTH = 30;
        private const int BULLET_HEIGHT = 30;
        private const int TANK_SPEED = 15;
        private const int BULLET_SPEED = 40;
        private const int MAX_LIVES = 1;

        // Properties
        public int GameWidth
        {
            get { return GAME_WIDTH; }
        }

        public int GameHeight
        {
            get { return GAME_HEIGHT; }
        }

        public int ImageWidth
        {
            get { return IMAGE_WIDTH; }
        }

        public int ImageHeight
        {
            get { return IMAGE_HEIGHT; }
        }

        public int BulletWidth
        {
            get { return BULLET_WIDTH; }
        }

        public int BulletHeight
        {
            get { return BULLET_HEIGHT; }
        }

        public int TankSpeed
        {
            get { return TANK_SPEED; }
        }

        public int BulletSpeed
        {
            get { return BULLET_SPEED; }
        }

        public int MaxLives
        {
            get { return MAX_LIVES; }
        }
    }
}
