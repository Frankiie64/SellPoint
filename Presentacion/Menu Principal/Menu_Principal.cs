using Dato.Model;
using Negocio.ModelosDto;
using Presentacion.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public  partial class Menu_Principal : Form
    {

        private bool value = true;
        private SqlConnection _con;
        Entidades entidades;

        //Dato.Model.Entidades _entidades = new Dato.Model.Entidades();
        EntidadLoginDto entidadLoginDto = new EntidadLoginDto();

        public Menu_Principal(SqlConnection con)
        {
            InitializeComponent();
            _con = con;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            value = false;
            Acerca_De acerca_De = new Acerca_De(_con);
            acerca_De.Show();
           this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {           
            timer1.Enabled = true;
            toolStripHora.Text = DateTime.Now.ToString ("hh:mm:ss");
            toolStripFecha.Text = DateTime.Now.ToString ("dddd MMMM yyy");

            //labelNombreUsuario.Text = Dato.Model.Entidades.Id;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //labelHora.Text = DateTime.Now.ToString("hh:mm:ss");

        }

        private void gruposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            value = false;
            Grupos_Entidades grupos_Entidades = new Grupos_Entidades();
           this.Close();

            grupos_Entidades.Show();
        }

        private void tiposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            value = false;
            Tipos_Entidades tipos_Entidades = new Tipos_Entidades(_con);
           this.Close();
            tipos_Entidades.Show();
        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            value = false;
            entidades = new Entidades(_con);
           this.Close();
            entidades.Show();
        }

        private void Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (value)
            {
                if (MessageBox.Show("Estas seguro de querer salir del menu principal ?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;                    
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void Menu_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (value)
            {
                frmMenu.Instance.Close();
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            value = false;
            this.Close();
            frmMenu.Instance.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelNombreUsuario_Click(object sender, EventArgs e)
        {

        }

        private void toolStripFecha_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
                       this.Close();
        }
    }
}
