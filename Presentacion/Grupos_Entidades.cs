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
        SqlConnection connection;

        Negocio_GruposEntidades grupoEntidades = new Negocio_GruposEntidades();
        private string idGrupoEntidades = null;
        private bool Editar = false;


        public Grupos_Entidades()
        {
            connection = new SqlConnection(connectionString);
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

        private  void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Insertar
            if (Editar == false)
            {
                try
                {
                    grupoEntidades.Insertar_GrupoEntidades(txtDescripcion.Text, txtComentario.Text, Convert.ToInt32(txtIdStatus.Text), Convert.ToBoolean(txtNoEliminable.Text), Convert.ToDateTime(dateTimePicker1.Text));
                    MessageBox.Show("Se han insertado los datos correctamente");
                    MostrarProductos();
                    LimpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por : " + ex);
                }
            }

            //Editar
            if (Editar == true)
            {
                try
                {
                    grupoEntidades.Editar_GrupoEntidades(txtDescripcion.Text, txtComentario.Text, Convert.ToInt32(txtIdStatus.Text), Convert.ToBoolean(txtNoEliminable.Text), Convert.ToDateTime(dateTimePicker1.Text), idGrupoEntidades);
                    MessageBox.Show("Se han editado los datos correctamente");
                    MostrarProductos();
                    LimpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por : " + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtComentario.Text = dataGridView1.CurrentRow.Cells["Comentario"].Value.ToString();
                txtIdStatus.Text = dataGridView1.CurrentRow.Cells["IdStatus"].Value.ToString();
                txtNoEliminable.Text = dataGridView1.CurrentRow.Cells["IdNoEliminable"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["FechaRegistro"].Value.ToString();
                idGrupoEntidades = dataGridView1.CurrentRow.Cells["IdGrupoEnitdad"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila");
            }
        }
        private void LimpiarForm()
        {
            txtDescripcion.Clear();
            txtComentario.Clear();
            txtIdStatus.Clear();
            txtNoEliminable.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idGrupoEntidades = dataGridView1.CurrentRow.Cells["IdGrupoEnitdad"].Value.ToString();
                grupoEntidades.Eliminar_GrupoEntidades(idGrupoEntidades);
                MessageBox.Show("Datos Eliminados Correctamente");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila");

            }
        }


    }
}
