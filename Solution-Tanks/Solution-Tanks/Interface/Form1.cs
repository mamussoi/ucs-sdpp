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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            doneButton.Select();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("Jogador 1","Jogador 2","Map.txt");
            form2.ShowDialog();
            form2.Dispose();
        }
    }
}
