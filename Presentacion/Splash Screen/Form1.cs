using Presentacion.Login;
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
    public sealed partial class Form1 : Form
    {
        public static Form1 Instance { get; } = new Form1();

        private Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            progressBar1.Increment(2);
            label1.Text = progressBar1.Value.ToString() + "%";

            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                frmMenu.Instance.ShowDialog();
            }
        }
    }
}
