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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Login
{
    public sealed partial class frmLogin : Form
    {

        public static frmLogin Intance { get; } = new frmLogin();
        public string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        Services_Login service;
        SqlConnection connection;

        private frmLogin()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            service = new Services_Login(connection);

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
            if(!validacion())
            {
                return;
            }

            if(!service.Login(crearUsario()))
            {
                MessageBox.Show("Las credenciales son incorrectas, por favor vuelva a intentarlo.");
                return;

            }
            MessageBox.Show($"Bienvenido {txtUsuario.Text}");

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
    }
}
