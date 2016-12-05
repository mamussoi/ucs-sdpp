using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Tanks
{
    public class Graph
    {
        public const int SIZE = 70;
        public Point Position;
        public int Number;
        public Brush Color; //note: Can't use class Color for some reason

        public Graph(Point position, int number, Brush color)
        {
            this.Position = position;
            this.Number = number;
            this.Color = color;
        }

        public void Draw(Graphics g)
        {
            var font = new Font(FontFamily.GenericSansSerif, 16f, FontStyle.Regular); //font of numbers
            g.FillRectangle(this.Color, new Rectangle(this.Position, new Size(SIZE, SIZE)));
            g.DrawRectangle(new Pen(Brushes.Black, 5f), new Rectangle(this.Position, new Size(SIZE, SIZE)));
            g.DrawString(this.Number.ToString(), font, Brushes.Black, new PointF(Position.X + SIZE / 2 + 16 - font.Size, Position.Y + 40)); //draw number for orientation 
        }

    }
}
