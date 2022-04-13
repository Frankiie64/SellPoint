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
using Negocio;

namespace Presentacion
{
    public partial class Grupos_Entidades : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        //SqlConnection connection;

        Negocio_GruposEntidades grupoEntidades = new Negocio_GruposEntidades();


        public Grupos_Entidades()
        {
           // connection = new SqlConnection(connectionString);
            InitializeComponent();
        }

        private void Grupos_Entidades_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void MostrarProductos()
        {
            Negocio_GruposEntidades ObjetosgrupoEntidades = new Negocio_GruposEntidades();
            dataGridView1.DataSource = ObjetosgrupoEntidades.MostrarGrupoEntidades();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                grupoEntidades.Insertar_GrupoEntidades(txtDescripcion.Text, txtComentario.Text, Convert.ToInt32(txtIdStatus.Text), Convert.ToBoolean(txtIdNoEliminable.Text), Convert.ToDateTime(txtFechaRegistro.Text));
                MessageBox.Show("Se han insertado los datos correctamente");
                MostrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar los datos por : " + ex);
            }
        }
    }
}
