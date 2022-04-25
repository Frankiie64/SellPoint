using Dato.Model;
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

namespace Presentacion.Archivo.Funciones_de_las_Entidades
{
    public partial class Agregar_RedesSociales : Form
    {
        Agregar_Entidad agregar_Entidades;
        SqlConnection _con;
        private bool value = true;
        public Agregar_RedesSociales(SqlConnection con)
        {
            InitializeComponent();
            _con = con;           
        }

        #region Events
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        #region Metodos Privados

        private void rellenar()
        {
            if (GlobalRepositoty.Instance.IdRedSocial != 0)
            {
                txtUrlFacebook.Text = GlobalRepositoty.Instance.RedesSociales.Urlfacebook;
                txtUrlInstagram.Text = GlobalRepositoty.Instance.RedesSociales.Urlinstagram;
                txtUrllTikTok.Text = GlobalRepositoty.Instance.RedesSociales.UrltikTok;
                txtUrlTwitter.Text = GlobalRepositoty.Instance.RedesSociales.UrltikTok;
                txtUrlPaginaWeb.Text = GlobalRepositoty.Instance.RedesSociales.UrlpaginaWeb;
            }
        }
        private void Save()
        {
            agregar_Entidades = new Agregar_Entidad(_con);

            if (!Validaciones())
            {
                return;
            }

            GlobalRepositoty.Instance.RedesSociales = createRedSocial();

            value = false;
            this.Close();
            agregar_Entidades.Show();
        }

        private bool Validaciones()
        {
            if(string.IsNullOrWhiteSpace(txtUrlPaginaWeb.Text) && string.IsNullOrWhiteSpace(txtUrlFacebook.Text) &&
                string.IsNullOrWhiteSpace(txtUrlInstagram.Text) && string.IsNullOrWhiteSpace(txtUrlTwitter.Text) &&
                string.IsNullOrWhiteSpace(txtUrllTikTok.Text))
            {
                if(MessageBox.Show("Estas seguro de querer continuar, no has agregado ningun link para tus redes sociales?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;

                }
            }
            return true;
        }
        private RedesSociales createRedSocial()
        {
            RedesSociales item = new RedesSociales();
            {
                item.UrlpaginaWeb = txtUrlPaginaWeb.Text;
                item.Urlfacebook = txtUrlFacebook.Text;
                item.Urltwitter = txtUrlTwitter.Text;
                item.Urlinstagram = txtUrlInstagram.Text;
                item.UrltikTok = txtUrllTikTok.Text;
            }
            return item;
        }
        #endregion

        private void Agregar_RedesSociales_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (value)
            {
                GlobalRepositoty.Instance.RedesSociales = null;
                Menu_Principal.Intance.Show();
            }            
        }

        private void Agregar_RedesSociales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (value)
            {
                if (MessageBox.Show("Estas seguro de querer salir ?, se perderan todos los datos que has ingresado hasta el momento. ", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }           
        }

        private void Agregar_RedesSociales_Load(object sender, EventArgs e)
        {
            rellenar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
