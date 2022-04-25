using Microsoft.IdentityModel.Protocols;
using Negocio.ModelosDto;
using Negocio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;


namespace Presentacion.Login
{
    public sealed partial class frmMenu : Form
    {
        public static frmMenu Instance { get; } = new frmMenu();

        public string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private SqlConnection _con;

        Services_Login service;
        private frmMenu()
        {            
            InitializeComponent();
            _con = new SqlConnection(connectionString);
            service = new Services_Login(_con);
            
        }

        #region Eventos
        private void btnEnviar_Click(object sender, EventArgs e)
        {                        
            InicioSesecion();
        }

        


        #endregion

        #region Metodos Privados
        //Metodos Principales
        private void InicioSesecion()
        {
            Menu_Principal menu = new Menu_Principal(_con);

            if(!validacion())
            {
                return;
            }

            if(!service.Login(crearUsario()))
            {
                MessageBox.Show("Las credenciales son incorrectas, por favor vuelva a intentarlo.");
                return;

            }
            //MessageBox.Show($"Bienvenido {txtUsuario.Text}");
            this.Hide();
            menu.Show();

        }



        //Metodos secundarios

        private bool validacion()
        {
            if(string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Arregla el mensaje, validacion principal del textbox usuario, metodo privado");
                return false;
            }
            else if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Arregla el mensaje, validacion principal del textbox contraseña, metodo privado");
                return false;
            }
            return true;
        }

        private EntidadLoginDto crearUsario()
        {
            EntidadLoginDto usuario = new EntidadLoginDto();
            {
                usuario.Username = txtUsuario.Text;
                usuario.Password = txtContraseña.Text;
            }            
            return usuario;
        }

        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.Instance.Close();
        }

        private void lblContraseña_Click(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblRecuperContra_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

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
