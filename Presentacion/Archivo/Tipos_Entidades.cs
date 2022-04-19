using Dato.Model;
using Negocio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Tipos_Entidades : Form
    {
        private SqlConnection _con;
        Services_defaults service;
        Services_TipoEntidad Services_Tipo;
        ComboBoxItem itemStauts;
        ComboBoxItem itemGrupos;
        ComboBoxItem itemNoEliminable;
        private int id = 0;

        public Tipos_Entidades(SqlConnection con)
        {
            InitializeComponent();
            _con = con;
            service = new Services_defaults(_con);
            Services_Tipo = new Services_TipoEntidad(_con);
        }
       
        private void load()
        {
            loadElimibable();
            loadStatus();
            loadGrupoEntidad();
            loadTable();
        }
        private void loadTable()
        {
            dgvRegistrosTENT.DataSource = Services_Tipo.loadTable();
            dgvRegistrosTENT.ClearSelection();

            dgvRegistrosTENT.Columns[0].Visible = false;
            dgvRegistrosTENT.Columns[2].Visible = false;
            dgvRegistrosTENT.Columns[4].Visible = false;
            dgvRegistrosTENT.Columns[5].Visible = false;

        }
        private void loadElimibable()
        {

            var status = service.getAllEliminable();

            foreach (var item in status)
            {
                ComboBoxItem objecto = new ComboBoxItem();
                {
                    objecto.Text = item.Estado;
                    objecto.Value = item.Id;
                }
                cbxEliminable.Items.Add(objecto);
            }
            cbxEliminable.SelectedIndex = 0;
        }
        private void loadGrupoEntidad()
        {
            var status = service.getAllGrupoEntidad();

            foreach (var item in status)
            {
                ComboBoxItem objecto = new ComboBoxItem();
                {
                    objecto.Text = item.Descripcion;
                    objecto.Value = item.IdGrupoEnitdad;
                }
                cbxGrupoEntidad.Items.Add(objecto);
            }
            cbxGrupoEntidad.SelectedIndex = 0;

        }

        private void loadStatus()
        {

            var status = service.getAllStatus();

            foreach (var item in status)
            {
                ComboBoxItem objecto = new ComboBoxItem();
                {
                    objecto.Text = item.Estado;
                    objecto.Value = item.Id;
                }
                cbxStatus.Items.Add(objecto);
            }

            cbxStatus.SelectedIndex = 0;

        }
       
        private void Rellenar(TipoEntidades item)
        {
            txtDescripcion.Text = item.Descripcion;
            txtComentario.Text = item.Comentario;

            foreach (ComboBoxItem comboBox in cbxGrupoEntidad.Items)
            {
                if((decimal)comboBox.Value == item.IdGrupoEntidad)
                {
                    cbxGrupoEntidad.SelectedItem = comboBox;
                }
            } 

            cbxStatus.SelectedIndex = (int)item.IdStatus - 1;
            
            if(item.IdNoEliminable)
            {
                cbxEliminable.SelectedIndex = 1;
            }
            else
            {
                cbxEliminable.SelectedIndex = 0;

            }

        }

       
        private void desmarcar()
        {
            dgvRegistrosTENT.ClearSelection();
            btnDeselect.Visible = false;

            txtComentario.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            cbxStatus.SelectedItem = default;
            cbxEliminable.SelectedItem = default;
            cbxGrupoEntidad.SelectedItem = default;
            id = 0;
        }
        private void Save()
        {
            TipoEntidades entidades = CreateTipoEntidad();

            if (id != 0)
            {
                UpdateTipoEntidad(entidades);
            }
            else
            {
                InsertTipoEntidad(entidades);
            }
        }
        private TipoEntidades CreateTipoEntidad()
        {
             itemStauts = cbxStatus.SelectedItem as ComboBoxItem;
             itemGrupos = cbxGrupoEntidad.SelectedItem as ComboBoxItem;
             itemNoEliminable = cbxEliminable.SelectedItem as ComboBoxItem;

            TipoEntidades entidad = new TipoEntidades();
            {
                entidad.Descripcion = txtDescripcion.Text;
                entidad.IdGrupoEntidad = Convert.ToDecimal(itemGrupos.Value);
                entidad.Comentario = txtComentario.Text;
                entidad.IdStatus = Convert.ToInt32(itemStauts.Value);
                entidad.IdNoEliminable = Convert.ToBoolean(itemNoEliminable.Value);
            }
            return entidad;
        }
        private void InsertTipoEntidad(TipoEntidades item)
        {
            bool value = Services_Tipo.CreateTipoEntidad(item);

            if (value)
            {
                MessageBox.Show("Se ha creado de manera correcta el tipo entidad en la base de datos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con el tipo entidad  cuando se estaba guardadno en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTipoEntidad(TipoEntidades item)
        {
            bool value = Services_Tipo.UpdateTipoEntidad(item,id);

            if (value)
            {
                MessageBox.Show("Se ha actualizado de manera correcta el tipo entidad en la base de datos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con el tipo entidad  cuando se estaba actualizando en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deleteTipoEntidad()
        {
            if (MessageBox.Show("Estas seguro de querer eliminar este registro ?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool value = Services_Tipo.deleteTipoEntidad(id);
                if (value)
                {
                    MessageBox.Show("Se ha eliminado de manera correcta el tipo entidad en la base de datos.", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error con el tipo entidad  cuando se estaba eliminando en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool Validar()
        {            
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor rellene el campo de descripcion para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtComentario.Text))
            {
                MessageBox.Show("Por favor rellene el campo de comentario para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbxGrupoEntidad.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor llene  el campo de grupo entidad para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbxStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor llene  el campo de status para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbxEliminable.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor llene  el campo de no eliminable para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool SelectRow()
        {
            if(id == 0)
            {
                MessageBox.Show("Por favor seleccione algun registro para poder continuar con esta opcion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void editTipoEntidad()
        {
            if (SelectRow())
            {
                TipoEntidades tipo = Services_Tipo.GetTipoEntidadesById(id);
                Rellenar(tipo);
            }
           
        }
        private void btnDeselect_Click(object sender, EventArgs e)
        {
            desmarcar();  
        }
        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Save();
                desmarcar();
                loadTable();
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (SelectRow())
            {
                deleteTipoEntidad();
                desmarcar();
                loadTable();
            }            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editTipoEntidad();
        }
        private void dgvRegistrosTENT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDeselect.Visible = true;
                id = Convert.ToInt32(dgvRegistrosTENT.CurrentRow.Cells[0].Value);
            }
        }
        private void Tipos_Entidades_Load(object sender, EventArgs e)
        {
            load();
        }

        private void Tipos_Entidades_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu_Principal.Intance.Show();            
        }
    }
}
