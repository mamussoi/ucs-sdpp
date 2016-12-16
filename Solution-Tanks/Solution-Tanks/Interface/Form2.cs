using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TankGame
{
    public partial class Form2 : Form
    {
        // Attributes
        private string player1Name;
        private string player2Name;
        private string mapFile;

        Tank tank1;
        Tank tank2;

        Bullet bull1 = new Bullet(-100, -100, 0);
        Bullet bull2 = new Bullet(-100, -100, 0);

        Button greentank = new Button();
        Button redtank = new Button();

        Button bullet1 = new Button();
        Button bullet2 = new Button();
               

        Button[] walls = new Button[5];
        Button wall1 = new Button();
        Button wall2 = new Button();
        Button wall3 = new Button();
        Button wall4 = new Button();
        Button wall5 = new Button();

        // Load Bitmap images
        Bitmap bulletimage = new Bitmap("Bullet.png");
        Bitmap wallimage = new Bitmap("Wall.jpg");
        Bitmap redimage0 = new Bitmap("RedTank0.jpg");
        Bitmap redimage1 = new Bitmap("RedTank1.jpg");
        Bitmap redimage2 = new Bitmap("RedTank2.jpg");
        Bitmap redimage3 = new Bitmap("RedTank3.jpg");
        Bitmap greenimage0 = new Bitmap("GreenTank0.jpg");
        Bitmap greenimage1 = new Bitmap("GreenTank1.jpg");
        Bitmap greenimage2 = new Bitmap("GreenTank2.jpg");
        Bitmap greenimage3 = new Bitmap("GreenTank3.jpg");

        public Form2(string p1, string p2, string mf)
        {
            // Load data from previous form
            InitializeComponent();
            player1Name = p1;
            player2Name = p2;
            mapFile = mf;

            // Load MapFile data
            Size = new System.Drawing.Size(800, 600);
            MapFile file = new MapFile(Application.StartupPath + "\\"+ mapFile);
            file.loadData();

            // Load tanks for MapFile
            tank1 = (Tank)file.Tanks[0];
            tank2 = (Tank)file.Tanks[1];

            // Create tanks --------------------------------------------------------------------------------

            // Set locations of tanks
            Point point1 = new Point(tank1.Horizontal, tank1.Vertical);
            greentank.Location = point1;
            Point point2 = new Point(tank2.Horizontal, tank2.Vertical);
            redtank.Location = point2;

            // Set sizes of tanks
            greentank.Size = new System.Drawing.Size(60, 60);
            greentank.BackColor = Color.Transparent;
            redtank.Size = new System.Drawing.Size(60, 60);

            // Set image of greentank
            switch (tank1.Direction)
            {
                case 0:
                    greentank.Image = greenimage0;
                    break;
                case 1:
                    greentank.Image = greenimage1;
                    break;
                case 2:
                    greentank.Image = greenimage2;
                    break;
                case 3:
                    greentank.Image = greenimage3;
                    break;
            }

            // Set image of redtank
            switch (tank2.Direction)
            {
                case 0:
                    redtank.Image = redimage0;
                    break;
                case 1:
                    redtank.Image = redimage1;
                    break;
                case 2:
                    redtank.Image = redimage2;
                    break;
                case 3:
                    redtank.Image = redimage3;
                    break;
            }

            // Add tanks to form
            this.Controls.Add(greentank);
            this.Refresh();
            this.Controls.Add(redtank);
            this.Refresh();

            // Create bullets ------------------------------------------------------------------------------

            // Set locations of bullets
            Point point3 = new Point(-100, -100);
            bullet1.Location = point3;
            bullet2.Location = point3;

            // Set sizes of bullets
            bullet1.Size = new System.Drawing.Size(30, 30);
            bullet2.Size = new System.Drawing.Size(30, 30);

            // Set image of bullets
            bullet1.Image = bulletimage;
            bullet2.Image = bulletimage;

            // Add bullets to form
            this.Controls.Add(bullet1);
            this.Refresh();
            this.Controls.Add(bullet2);
            this.Refresh();

            // Create walls --------------------------------------------------------------------------------
            walls[0] = wall1;
            walls[1] = wall2;
            walls[2] = wall3;
            walls[3] = wall4;
            walls[4] = wall5;

            // Set wall attributes and load to form
            /*for(int i = 0; i < 5; i++)
            {
                Wall newWall = (Wall)file.Walls[i];
                Point point4 = new Point(newWall.Horizontal, newWall.Vertical);
                walls[i].Location = point4;
                walls[i].Size = new System.Drawing.Size(60,60);
                walls[i].Image = wallimage;
                this.Controls.Add(walls[i]);
                this.Refresh();
            }
            */
            timer1.Start();
            this.Select();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GameConstants gc = new GameConstants();
            // Get current direction, move tank
            switch (tank1.Direction)
            {
                case 0:     // Move tank up
                    greentank.Image = greenimage0;
                    if (tank2.Vertical >= 0)
                    {
                        tank1.Vertical -= gc.TankSpeed;
                        Point pointa = new Point(tank1.Horizontal, tank1.Vertical);
                        greentank.Location = pointa;
                    }
                    else    // Recoil
                    {
                        tank1.Direction = 2;
                        tank1.Vertical += gc.TankSpeed;
                        Point point3 = new Point(tank1.Horizontal, tank1.Vertical);
                        redtank.Location = point3;
                    }
                    break;
                case 1:     // Move tank right
                    greentank.Image = greenimage1;
                    if (tank1.Horizontal <= gc.GameWidth)
                    {
                        tank1.Horizontal += gc.TankSpeed;
                        Point pointb = new Point(tank1.Horizontal, tank1.Vertical);
                        greentank.Location = pointb;
                    }
                    else    // Recoil
                    {
                        tank1.Direction = 3;
                        tank1.Horizontal -= gc.TankSpeed;
                        Point point3 = new Point(tank1.Horizontal, tank1.Vertical);
                        redtank.Location = point3;
                    }
                    break;
                case 2:     // Move tank down
                    greentank.Image = greenimage2;
                    if (tank1.Vertical <= gc.GameHeight)
                    {
                        tank1.Vertical += gc.TankSpeed;
                        Point pointc = new Point(tank1.Horizontal, tank1.Vertical);
                        greentank.Location = pointc;
                    }
                    else    // Recoil
                    {
                        tank1.Direction = 0;
                        tank1.Vertical -= gc.TankSpeed;
                        Point point3 = new Point(tank1.Horizontal, tank1.Vertical);
                        redtank.Location = point3;
                    }
                    break;
                case 3:     // Move tank left
                    greentank.Image = greenimage3;
                    if (tank1.Horizontal >= 0)
                    {
                        tank1.Horizontal -= gc.TankSpeed;
                        Point pointd = new Point(tank1.Horizontal, tank1.Vertical);
                        greentank.Location = pointd;
                    }
                    else    // Recoil
                    {
                        tank1.Direction = 1;
                        tank1.Horizontal += gc.TankSpeed;
                        Point point3 = new Point(tank1.Horizontal, tank1.Vertical);
                        redtank.Location = point3;
                    }
                    break;
            }
            switch (tank2.Direction)
            {
                case 0:     // Move tank up
                    redtank.Image = redimage0;
                    if (tank2.Vertical >= 0)
                    {
                        tank2.Vertical -= gc.TankSpeed;
                        Point point1 = new Point(tank2.Horizontal, tank2.Vertical);
                        redtank.Location = point1;
                    }
                    else    // Recoil
                    {
                        tank2.Direction = 2;
                        tank2.Vertical += gc.TankSpeed;
                        Point point3 = new Point(tank2.Horizontal, tank2.Vertical);
                        redtank.Location = point3;
                    }
                    break;
                case 1:     // Move tank right
                    redtank.Image = redimage1;
                    if (tank2.Horizontal <= gc.GameWidth)
                    {
                        tank2.Horizontal += gc.TankSpeed;
                        Point point2 = new Point(tank2.Horizontal, tank2.Vertical);
                        redtank.Location = point2;
                    }
                    else    // Recoil
                    {
                        tank2.Direction = 3;
                        tank2.Horizontal -= gc.TankSpeed;
                        Point point3 = new Point(tank2.Horizontal, tank2.Vertical);
                        redtank.Location = point3;
                    }
                    break;
                case 2:     // Move tank down
                    redtank.Image = redimage2;
                    if (tank2.Vertical <= gc.GameHeight)
                    {
                        tank2.Vertical += gc.TankSpeed;
                        Point point3 = new Point(tank2.Horizontal, tank2.Vertical);
                        redtank.Location = point3;
                    }
                    else    // Recoil
                    {
                        tank2.Direction = 0;
                        tank2.Vertical -= gc.TankSpeed;
                        Point point3 = new Point(tank2.Horizontal, tank2.Vertical);
                        redtank.Location = point3;
                    }
                    break;
                case 3:     // Move tank left
                    redtank.Image = redimage3;
                    if (tank2.Horizontal >= 0)
                    {
                        tank2.Horizontal -= gc.TankSpeed;
                        Point point4 = new Point(tank2.Horizontal, tank2.Vertical);
                        redtank.Location = point4;
                    }
                    else    // Recoil
                    {
                        tank2.Direction = 1;
                        tank2.Horizontal += gc.TankSpeed;
                        Point point3 = new Point(tank2.Horizontal, tank2.Vertical);
                        redtank.Location = point3;
                    }
                    break;
            }

            // Get current direction, move bullet
            switch (bull1.Direction)
            {
                case 0:
                    if (bull1.Vertical >= 0)
                    {
                        bull1.Vertical -= gc.BulletSpeed;
                        Point point = new Point(bull1.Horizontal, bull1.Vertical);
                        bullet1.Location = point;
                    }
                    else
                    {
                        bull1.Vertical = -100;
                        bull1.Horizontal = -100;
                        bull1.Direction = 0;
                        Point point = new Point(bull1.Horizontal, bull1.Vertical);
                        bullet1.Location = point;
                        tank1.CanFire = true;
                    }
                    break;
                case 1:
                    if (bull1.Horizontal <= gc.GameWidth)
                    {
                        bull1.Horizontal += gc.BulletSpeed;
                        Point point = new Point(bull1.Horizontal, bull1.Vertical);
                        bullet1.Location = point;
                    }
                    else
                    {
                        bull1.Vertical = -100;
                        bull1.Horizontal = -100;
                        bull1.Direction = 0;
                        Point point = new Point(bull1.Horizontal, bull1.Vertical);
                        bullet1.Location = point;
                        tank1.CanFire = true;
                    }
                    break;
                case 2:
                    if (bull1.Vertical <= gc.GameHeight)
                    {
                        bull1.Vertical += gc.BulletSpeed;
                        Point point = new Point(bull1.Horizontal, bull1.Vertical);
                        bullet1.Location = point;
                    }
                    else
                    {
                        bull1.Vertical = -100;
                        bull1.Horizontal = -100;
                        bull1.Direction = 0;
                        Point point = new Point(bull1.Horizontal, bull1.Vertical);
                        bullet1.Location = point;
                        tank1.CanFire = true;
                    }
                    break;
                case 3:
                    if (bull1.Horizontal >= 0)
                    {
                        bull1.Horizontal -= gc.BulletSpeed;
                        Point point = new Point(bull1.Horizontal, bull1.Vertical);
                        bullet1.Location = point;
                    }
                    else
                    {
                        bull1.Vertical = -100;
                        bull1.Horizontal = -100;
                        bull1.Direction = 0;
                        Point point = new Point(bull1.Horizontal, bull1.Vertical);
                        bullet1.Location = point;
                        tank1.CanFire = true;
                    }
                    break;
            }
            switch (bull2.Direction)
            {
                case 0:
                    if (bull2.Vertical >= 0)
                    {
                        bull2.Vertical -= gc.BulletSpeed;
                        Point point = new Point(bull2.Horizontal, bull2.Vertical);
                        bullet2.Location = point;
                    }
                    else
                    {
                        bull2.Vertical = -100;
                        bull2.Horizontal = -100;
                        bull2.Direction = 0;
                        Point point = new Point(bull2.Horizontal, bull2.Vertical);
                        bullet2.Location = point;
                        tank2.CanFire = true;
                    }
                    break;
                case 1:
                    if (bull2.Horizontal <= gc.GameWidth)
                    {
                        bull2.Horizontal += gc.BulletSpeed;
                        Point point = new Point(bull2.Horizontal, bull2.Vertical);
                        bullet2.Location = point;
                    }
                    else
                    {
                        bull2.Vertical = -100;
                        bull2.Horizontal = -100;
                        bull2.Direction = 0;
                        Point point = new Point(bull2.Horizontal, bull2.Vertical);
                        bullet2.Location = point;
                        tank2.CanFire = true;
                    }
                    break;
                case 2:
                    if (bull2.Vertical <= gc.GameHeight)
                    {
                        bull2.Vertical += gc.BulletSpeed;
                        Point point = new Point(bull2.Horizontal, bull2.Vertical);
                        bullet2.Location = point;
                    }
                    else
                    {
                        bull2.Vertical = -100;
                        bull2.Horizontal = -100;
                        bull2.Direction = 0;
                        Point point = new Point(bull2.Horizontal, bull2.Vertical);
                        bullet2.Location = point;
                        tank2.CanFire = true;
                    }
                    break;
                case 3:
                    if (bull2.Horizontal >= 0)
                    {
                        bull2.Horizontal -= gc.BulletSpeed;
                        Point point = new Point(bull2.Horizontal, bull2.Vertical);
                        bullet2.Location = point;
                    }
                    else
                    {
                        bull2.Vertical = -100;
                        bull2.Horizontal = -100;
                        bull2.Direction = 0;
                        Point point = new Point(bull2.Horizontal, bull2.Vertical);
                        bullet2.Location = point;
                        tank2.CanFire = true;
                    }
                    break;
            }
            Refresh();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            GameConstants gc = new GameConstants();

            switch (e.KeyData)
            {
                case Keys.W:    // Tank faces up
                    tank1.Direction = 0;
                    greentank.Image = greenimage0;
                    break;
                case Keys.D:    // Tank faces right
                    tank1.Direction = 1;
                    greentank.Image = greenimage1;
                    break;
                case Keys.S:    // Tank faces down
                    tank1.Direction = 2;
                    greentank.Image = greenimage2;
                    break;
                case Keys.A:    // Tank faces left
                    tank1.Direction = 3;
                    greentank.Image = greenimage3;
                    break;
                case Keys.F:    // Bullet appears
                    if (tank1.Direction == 0 && tank1.CanFire == true)
                    {
                        Point point1 = new Point(tank1.Horizontal + (gc.BulletWidth / 2), tank1.Vertical
                            - gc.BulletHeight);
                        bullet1.Location = point1;
                        bull1.Vertical = (tank1.Vertical - gc.BulletHeight);
                        bull1.Horizontal = (tank1.Horizontal + (gc.BulletWidth / 2));
                        bull1.Direction = 0;
                        tank1.CanFire = false;
                    }
                    else if (tank1.Direction == 1 && tank1.CanFire == true)
                    {
                        Point point2 = new Point(tank1.Horizontal + gc.ImageWidth, tank1.Vertical
                            + (gc.BulletWidth / 2));
                        bullet1.Location = point2;
                        bull1.Vertical = (tank1.Vertical + (gc.BulletHeight / 2));
                        bull1.Horizontal = (tank1.Horizontal + gc.ImageWidth);
                        bull1.Direction = 1;
                        tank1.CanFire = false;
                    }
                    else if (tank1.Direction == 2 && tank1.CanFire == true)
                    {
                        Point point3 = new Point(tank1.Horizontal + (gc.BulletWidth/2), 
                            tank1.Vertical + gc.ImageHeight);
                        bullet1.Location = point3;
                        bull1.Vertical = (tank1.Vertical + gc.ImageHeight);
                        bull1.Horizontal = (tank1.Horizontal + (gc.BulletWidth / 2));
                        bull1.Direction = 2;
                        tank1.CanFire = false;
                    }
                    else if (tank1.Direction == 3 && tank1.CanFire == true)
                    {
                        Point point4 = new Point(tank1.Horizontal - gc.BulletWidth,
                            tank1.Vertical + (gc.BulletWidth / 2));
                        bullet1.Location = point4;
                        bull1.Vertical = (tank1.Vertical + (gc.BulletWidth / 2));
                        bull1.Horizontal = (tank1.Horizontal - gc.BulletWidth);
                        bull1.Direction = 3;
                        tank1.CanFire = false;
                    }
                    break;
                case Keys.I:       // Tank faces up
                    tank2.Direction = 0;
                    redtank.Image = redimage0;
                    break;
                case Keys.L:    // Tank faces right
                    tank2.Direction = 1;
                    redtank.Image = redimage1;
                    break;
                case Keys.K:     // Tank faces down
                    tank2.Direction = 2;
                    redtank.Image = redimage2;
                    break;
                case Keys.J:     // Tank faces left
                    tank2.Direction = 3;
                    redtank.Image = redimage3;
                    break;
                case Keys.H:     // Bullet appears
                    if (tank2.Direction == 0 && tank2.CanFire == true)
                    {
                        Point point1 = new Point(tank2.Horizontal + (gc.BulletWidth / 2), tank2.Vertical
                            - gc.BulletHeight);
                        bullet2.Location = point1;
                        bull2.Vertical = (tank2.Vertical - gc.BulletHeight);
                        bull2.Horizontal = (tank2.Horizontal + (gc.BulletWidth / 2));
                        bull2.Direction = 0;
                        tank2.CanFire = false;
                    }
                    else if (tank2.Direction == 1 && tank2.CanFire == true)
                    {
                        Point point2 = new Point(tank2.Horizontal + gc.ImageWidth, tank2.Vertical
                            + (gc.BulletHeight / 2));
                        bullet2.Location = point2;
                        bull2.Vertical = (tank2.Vertical + (gc.BulletHeight / 2));
                        bull2.Horizontal = (tank2.Horizontal + gc.ImageWidth);
                        bull2.Direction = 1;
                        tank2.CanFire = false;
                    }
                    else if (tank2.Direction == 2 && tank2.CanFire == true)
                    {
                        Point point3 = new Point(tank2.Horizontal + (gc.BulletWidth / 2),
                            tank2.Vertical + gc.ImageHeight);
                        bullet2.Location = point3;
                        bull2.Vertical = (tank2.Vertical + gc.ImageHeight);
                        bull2.Horizontal = (tank2.Horizontal + (gc.BulletWidth / 2));
                        bull2.Direction = 2;
                        tank2.CanFire = false;
                    }
                    else if (tank2.Direction == 3 && tank2.CanFire == true)
                    {
                        Point point4 = new Point(tank2.Horizontal - gc.BulletWidth,
                            tank2.Vertical + (gc.BulletWidth/2));
                        bullet2.Location = point4;
                        bull2.Vertical = (tank2.Vertical + (gc.BulletWidth / 2));
                        bull2.Horizontal = (tank2.Horizontal - gc.BulletWidth);
                        bull2.Direction = 3;
                        tank2.CanFire = false;
                    }
                    break;
            }
        }
    }
}
