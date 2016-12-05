using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Tanks
{
    public class ScreenManager
    {
        public ScreenManager()
        {
            this.Squares = new List<Graph>();
            this.Initialize();
        }

        public List<Graph> Squares;
        public int iteracoes = 0;

        public void Update()
        {
            this.UpdateGraphs();
        }

        public void Draw(Graphics g)
        {
            foreach (var square in this.Squares)
                square.Draw(g);
        }

        private void Initialize()
        {
            this.CreateGraphs();
            
        }

        private void CreateGraphs()
        {
            int number = 0;
            for (int y = 0; y < 11; y++)
                for (int x = 0; x < 11; x++)
                {
                    number++;
                    this.Squares.Add(new Graph(new Point(x * Graph.SIZE, Graph.SIZE * y), number, Brushes.White));
                }
        }

        private void UpdateGraphs()
        {
            this.RepaintGraphs();
            PaintTanksAtTheStart();
        }

        private void RepaintGraphs()
        {
            foreach (var square in this.Squares)
                square.Color = Brushes.White;
        }

        private void PaintTanksAtTheStart()
        {
            foreach (var square in this.Squares.Where(s => s.Number == 6 || s.Number == 56))
                square.Color = Brushes.LimeGreen;
        }

    }
}
