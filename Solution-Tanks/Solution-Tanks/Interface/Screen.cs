using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solution_Tanks
{

    public partial class Screen : Form
    {
        private ScreenManager screenManager;
        public Screen()
        {
            InitializeComponent();
            this.screenManager = new ScreenManager();
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            this.screenManager.Update();
            this.screenManager.Draw(e.Graphics);
        }

        private void Screen_Load(object sender, EventArgs e)
        {
           
        }
    }
}
