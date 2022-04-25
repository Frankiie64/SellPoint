using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Acerca_De : Form
    {
        SqlConnection _con;
        public Acerca_De(SqlConnection con)
        {
            InitializeComponent();
            _con = con;
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
            Menu_Principal menu = new Menu_Principal(_con);
            menu.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
