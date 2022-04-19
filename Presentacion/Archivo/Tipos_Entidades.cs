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
        private void Tipos_Entidades_Load(object sender, EventArgs e)
        {
            load();
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

        private void dgvRegistrosTENT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                btnDeselect.Visible = true;

                TipoEntidades tipo = Services_Tipo.GetTipoEntidadesById(Convert.ToInt32(dgvRegistrosTENT.CurrentRow.Cells[0].Value));

                Rellenar(tipo);
            }            
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            dgvRegistrosTENT.ClearSelection();
            btnDeselect.Visible = false;

            txtComentario.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            cbxStatus.SelectedItem = default;
            cbxEliminable.SelectedItem = default;
            cbxGrupoEntidad.SelectedItem = default;
        }
    }
}
