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

namespace Presentacion.Login
{
    public  partial class frmMenu : Form
    {
        private bool value = true;
        Services_Login service;
        public frmMenu(SqlConnection connection)
        {
            InitializeComponent();
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
            //MessageBox.Show($"Bienvenido {txtUsuario.Text}");
            value = false;
            this.Close();
            Menu_Principal.Intance.Show();

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
            if (value)
            {
                GlobalRepositoty.Instance.value = false;
                Menu_Principal.Intance.Close();
            }
        }
    }
}
