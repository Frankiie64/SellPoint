using Negocio.Services;
using Presentacion.Archivo.Funciones_de_las_Entidades;
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

namespace Presentacion
{
    public partial class Entidades : Form
    {
        SqlConnection _con;
        Agregar_RedesSociales agregar_RedesSociales;
        Services_Entidad services;

        private bool value = true;
        private int Id = 0;
        private int IdRedSocial = 0;
        public Entidades(SqlConnection con)
        {
            InitializeComponent();
            _con = con;
            agregar_RedesSociales = new Agregar_RedesSociales(_con);
            services = new Services_Entidad(_con);
        }

        private void load()
        {

            dgvEntidades.DataSource = services.GetAllEntidad();
            dgvEntidades.ClearSelection();

            dgvEntidades.Columns[0].Visible = false;
            dgvEntidades.Columns[1].Visible = false;

            desmarcar();
            
        }
        private void update()
        {
            if (Id == 0)
            {
                MessageBox.Show("Por favor selecione el registro que desea eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GlobalRepositoty.Instance.entidadad = GetEntidad(Id);

            if (string.IsNullOrEmpty(GlobalRepositoty.Instance.entidadad.UsernameEntidad))
            {
                MessageBox.Show("Hubo un error en la busqueda de este registro intentelo mas tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GlobalRepositoty.Instance.RedesSociales = GetRedById(IdRedSocial);

            if (GlobalRepositoty.Instance.RedesSociales.Id == 0)
            {
                MessageBox.Show("Hubo un error en la busqueda de este registro intentelo mas tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GlobalRepositoty.Instance.IdRedSocial = GlobalRepositoty.Instance.RedesSociales.Id;
            GlobalRepositoty.Instance.IdEntidad = GlobalRepositoty.Instance.entidadad.Id;
            value = false;
            this.Close();
            agregar_RedesSociales.Show();

        }
        private Dato.Model.Entidades GetEntidad(int id)
        {
            return services.GetEntidad(id);
        }
        private Dato.Model.RedesSociales GetRedById(int id)
        {
            return services.findByIdRedes(id);
        }

        private void delete()
        {
            if (Id == 0)
            {
                MessageBox.Show("Por favor selecione el registro que desea eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show("Estas seguro de querer eliminar este registro ?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (!deleteOnDataBase())
                {
                    MessageBox.Show("Ha ocurrido un error en la base de datos, cuando se intento eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void desmarcar()
        {
            dgvEntidades.ClearSelection();
            btnDeselect.Visible = false;
            Id = 0;
            IdRedSocial = 0;
            GlobalRepositoty.Instance.IdRedSocial = 0;
            GlobalRepositoty.Instance.IdEntidad = 0;
            GlobalRepositoty.Instance.RedesSociales = null;
            GlobalRepositoty.Instance.entidadad = null;
        }

        private bool deleteOnDataBase()
        {
            return services.deleteEntidad(Id);
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            value = false;
            this.Close();            
            agregar_RedesSociales.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            delete();
            load();
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            desmarcar();
            load();
        }

        private void Entidades_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (value)
            {
                Menu_Principal menu = new Menu_Principal(_con);

                menu.Show();
            }           
        }

        private void Entidades_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dgvEntidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDeselect.Visible = true;
                Id = Convert.ToInt32(dgvEntidades.CurrentRow.Cells[0].Value); 
                IdRedSocial = Convert.ToInt32(dgvEntidades.CurrentRow.Cells[1].Value);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            update();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvEntidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            desmarcar();
            load();
        }

        private void btnModificar_MouseEnter(object sender, EventArgs e)
        {
            Color purple1 = Color.FromArgb(106, 90, 205);
            btnModificar.BackColor = purple1;
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.Transparent;
        }

        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            Color purple1 = Color.FromArgb(106, 90, 205);
            btnAgregar.BackColor = purple1;
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.Transparent;
        }

        private void buttonEliminar_MouseEnter(object sender, EventArgs e)
        {
            Color purple1 = Color.FromArgb(106, 90, 205);
            buttonEliminar.BackColor = purple1;
        }

        private void buttonEliminar_MouseLeave(object sender, EventArgs e)
        {
            buttonEliminar.BackColor = Color.Transparent;
        }

        private void btnDeselect1_MouseEnter(object sender, EventArgs e)
        {
            Color purple1 = Color.FromArgb(106, 90, 205);
            btnDeselect1.BackColor = purple1;
        }

        private void btnDeselect1_MouseLeave(object sender, EventArgs e)
        {
            btnDeselect1.BackColor = Color.Transparent;
        }
    }
}
