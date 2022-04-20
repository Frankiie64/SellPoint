using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Acerca_De : Form
    {
        public Acerca_De()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Acerca_De_Load(object sender, EventArgs e)
        {

        }

        private void Acerca_De_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu_Principal.Intance.Show();
        }
    }
}
