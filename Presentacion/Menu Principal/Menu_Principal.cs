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
    public sealed partial class Menu_Principal : Form
    {
        public static Menu_Principal Intance { get; } = new Menu_Principal();

        public string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private SqlConnection _con;

        //Dato.Model.Entidades _entidades = new Dato.Model.Entidades();
        EntidadLoginDto entidadLoginDto = new EntidadLoginDto();

        private Menu_Principal()
        {
            InitializeComponent();
            _con = new SqlConnection(connectionString);

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca_De acerca_De = new Acerca_De();
            acerca_De.Show();
this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
this.Hide();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu login = new frmMenu(_con);

            login.Show();

            timer1.Enabled = true;
            toolStripHora.Text = DateTime.Now.ToString("hh:mm:ss");
            toolStripFecha.Text = DateTime.Now.ToLongDateString();

            //labelNombreUsuario.Text = Dato.Model.Entidades.Id;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //labelHora.Text = DateTime.Now.ToString("hh:mm:ss");

        }

        private void gruposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grupos_Entidades grupos_Entidades = new Grupos_Entidades();
            this.Hide();

            grupos_Entidades.Show();
        }

        private void tiposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tipos_Entidades tipos_Entidades = new Tipos_Entidades(_con);
            this.Hide();
            tipos_Entidades.Show();
        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entidades entidades = new Entidades();
            this.Hide();
            entidades.Show();
        }

        private void Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalRepositoty.Instance.value)
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
        }
    }
}
