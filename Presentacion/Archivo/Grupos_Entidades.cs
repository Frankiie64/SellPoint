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

        Negocio_GruposEntidades grupoEntidades;
        private string idGrupoEntidades = null;
        private bool Editar = false;


        public Grupos_Entidades()
        {
            connection = new SqlConnection(connectionString);
            grupoEntidades = new Negocio_GruposEntidades(connection);
            InitializeComponent();
        }

        private void Grupos_Entidades_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            MostrarProductos();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void MostrarProductos()
        {
            dataGridView1.DataSource = grupoEntidades.MostrarGrupoEntidades();
            dataGridView1.ClearSelection();
        }

        private  void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Insertar
            if (Editar == false)
            {
                try
                {
                    grupoEntidades.Insertar_GrupoEntidades(txtDescripcion.Text, txtComentario.Text, txtIdStatus.Text == "true" ? 1 : 2, txtNoEliminable.Text == "true" ? true : false, Convert.ToDateTime(dateTimePicker1.Text));
                    MessageBox.Show("Se han insertado los datos correctamente");
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
                    grupoEntidades.Editar_GrupoEntidades(txtDescripcion.Text, txtComentario.Text, txtIdStatus.Text == "true" ? 1 : 2, txtNoEliminable.Text == "true" ? true : false, Convert.ToDateTime(dateTimePicker1.Text), idGrupoEntidades);
                    MessageBox.Show("Se han editado los datos correctamente");                    
                    Editar = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por : " + ex);
                }
            }
            dataGridView1.DataSource = null;

            LimpiarForm();

            MostrarProductos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtComentario.Text = dataGridView1.CurrentRow.Cells["Comentario"].Value.ToString();
                txtIdStatus.Text = dataGridView1.CurrentRow.Cells["IdStatus"].Value.ToString();
                txtNoEliminable.Text = dataGridView1.CurrentRow.Cells["No Eliminable"].Value.ToString();
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

        //Evento Volver al menu principal
        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlMenuPrincipal();
        }

        private void VolverAlMenuPrincipal()
        {
            this.Close();            
        }

        private void Grupos_Entidades_FormClosed(object sender, FormClosedEventArgs e)
        {

            Menu_Principal menu = new Menu_Principal(connection);

            menu.Show();
        }

        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            btnEliminar.FlatAppearance.BorderColor = Color.Red;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.FlatAppearance.BorderColor = Color.White;
        }

        private void btnEditar_MouseEnter(object sender, EventArgs e)
        {
            Color purple1 = Color.FromArgb(106, 90, 205);
            btnEditar.BackColor = purple1;
        }

        private void btnEditar_MouseLeave(object sender, EventArgs e)
        {
            btnEditar.BackColor = Color.Transparent;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
