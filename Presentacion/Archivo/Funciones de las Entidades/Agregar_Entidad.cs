using Negocio.Services;
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
    public partial class Agregar_Entidad : Form
    {
        private SqlConnection _connection;
        ComboBoxItem itemStauts;
        ComboBoxItem itemGrupos;
        ComboBoxItem itemNoEliminable;
        ComboBoxItem itemTipoEntidadPolitica;
        ComboBoxItem itemTipoDocumento;
        ComboBoxItem itemRol;
        ComboBoxItem itemTipoEntidad;

        private bool value = true;

        Entidades entidades;
        Services_defaults serviceDef;
        Services_Entidad services;

        public Agregar_Entidad(SqlConnection con)
        {
            InitializeComponent();
            _connection = con;
            services = new Services_Entidad(_connection);
            serviceDef = new Services_defaults(_connection);
        }

        #region Events
        private void Agregar_Entidad_Load(object sender, EventArgs e)
        {
            loadElimibable();
            loadGrupoEntidad();
            loadTipoEntidad();
            loadStatus();
            loadTipoEntidadPolitica();
            loadDocumento();
            loadRol();
            rellenar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            entidades = new Entidades(_connection);
            this.Close();
            entidades.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Agregar_Entidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalRepositoty.Instance.entidadad = null;
            GlobalRepositoty.Instance.RedesSociales = null;
            Menu_Principal menu = new Menu_Principal(_connection);

            menu.Show();
        }

        private void Agregar_Entidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (value)
            {
                if (MessageBox.Show("Estas seguro de querer salir ?, se perderan todos los datos que has ingresado hasta el momento. ", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region Metodos Privados

        private void rellenar()
        {
            if (GlobalRepositoty.Instance.IdEntidad != 0)
            {
                txtDescripcion.Text = GlobalRepositoty.Instance.entidadad.Descripcion;
                txtDireccion.Text = GlobalRepositoty.Instance.entidadad.Direccion;
                txtLocalidad.Text = GlobalRepositoty.Instance.entidadad.Localidad;
                txtTelefono.Text = GlobalRepositoty.Instance.entidadad.Télefono;
                txtUsernameEntidad.Text = GlobalRepositoty.Instance.entidadad.UsernameEntidad;
                txtPasswordEntidad.Text = GlobalRepositoty.Instance.entidadad.PasswordEntidad;
                txtLimiteCredito.Text = Convert.ToString(GlobalRepositoty.Instance.entidadad.LimiteCredito);
                txtComentario.Text = GlobalRepositoty.Instance.entidadad.Comentario;
                txtCorreo.Text = GlobalRepositoty.Instance.entidadad.Email;
                cbxTipoEntidadPolitica.SelectedIndex = (GlobalRepositoty.Instance.entidadad.IdTipoEntidadPolitica - 1);
                cbxTipoDocumento.SelectedValue = (GlobalRepositoty.Instance.entidadad.IdTipoDocumento - 1);
                cbxRolUserEntidad.SelectedIndex = (GlobalRepositoty.Instance.entidadad.IdRolUserEntidad - 1);

                foreach (ComboBoxItem item in cbxTipoEntidad.Items)
                {
                   if(GlobalRepositoty.Instance.entidadad.IdTipoEntidad == Convert.ToInt32(item.Value))
                    {
                        cbxTipoEntidad.SelectedItem = item;
                    }
                }
                foreach (ComboBoxItem item in cbxGrupoEntidad.Items)
                {
                    if (GlobalRepositoty.Instance.entidadad.IdGrupoEntidad == Convert.ToInt32(item.Value))
                    {
                        cbxGrupoEntidad.SelectedItem = item;
                    }
                }                
                cbxStatus.SelectedIndex = (GlobalRepositoty.Instance.entidadad.IdStatus - 1);
                cbxEliminable.SelectedIndex = GlobalRepositoty.Instance.entidadad.IdNoEliminable == false ? 0:1;
            }
        }
        private void Save()
        {
            if (!Validar())
            {
                return;
            }
            if (!ValidarUser(txtUsernameEntidad.Text))
            {
                return;
            }

            if(!createRedSocial())
            {
                return;
            }

            GlobalRepositoty.Instance.entidadad = createEntidad();

            if (GlobalRepositoty.Instance.IdEntidad != 0)
            {
                if (UpdateEntidadInDataBase())
                {
                    MessageBox.Show("Se ha actualizado de manera exitosa el registro.", "Noticacion", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
            }
            else if (GlobalRepositoty.Instance.IdEntidad == 0)
            {
                if (createEntidadInDataBase())
                {
                    MessageBox.Show("Se ha creado de manera exitosa el registro.", "Noticacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            value = false;

            this.Close();
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor rellene el campo de descripcion para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Por favor rellene el campo de direccion para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("Por favor rellene el campo de localidad para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!(txtTelefono.MaskFull))
            {
                MessageBox.Show("Por favor rellene el campo de telefono para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtUsernameEntidad.Text))
            {
                MessageBox.Show("Por favor rellene el campo de UserName para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPasswordEntidad.Text))
            {
                MessageBox.Show("Por favor rellene el campo de password para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!(txtLimiteCredito.MaskFull))
            {
                MessageBox.Show("Por favor rellene el campo de limite de credito para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtComentario.Text))
            {
                MessageBox.Show("Por favor rellene el campo de comentario para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Por favor rellene el campo de Email para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbxTipoEntidadPolitica.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor llene  el campo de Tipo Entidad Politica para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbxTipoDocumento.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor llene  el campo de Tipo Documento para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbxRolUserEntidad.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor llene  el campo de Rol User Entidad para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbxTipoEntidad.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor llene  el campo de Tipo Entidad para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ValidarUser(string user)
        {
            bool value =  services.ValidarUser(user);
            if (value )
            {
                if (GlobalRepositoty.Instance.entidadad.UsernameEntidad == txtUsernameEntidad.Text)
                {
                    return true;
                }
                MessageBox.Show("El UserName que acaba de colocar, ya esta siendo usado por favor ingrese otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsernameEntidad.Focus();
                return false;
            }
            return true;
        }
        private Dato.Model.Entidades createEntidad()
        {
            itemStauts = cbxStatus.SelectedItem as ComboBoxItem;
            itemGrupos = cbxGrupoEntidad.SelectedItem as ComboBoxItem;
            itemNoEliminable = cbxEliminable.SelectedItem as ComboBoxItem;
            itemTipoEntidadPolitica = cbxTipoEntidadPolitica.SelectedItem as ComboBoxItem;
             itemTipoDocumento = cbxTipoDocumento.SelectedItem as ComboBoxItem;
            itemRol = cbxRolUserEntidad.SelectedItem as ComboBoxItem;
            itemTipoEntidad = cbxTipoEntidad.SelectedItem as ComboBoxItem;

            Dato.Model.Entidades x = new Dato.Model.Entidades();
            {
                x.Descripcion = txtDescripcion.Text;
                x.Comentario = txtComentario.Text;
                x.UsernameEntidad = txtUsernameEntidad.Text;
                x.PasswordEntidad = txtPasswordEntidad.Text;
                x.Direccion = txtDireccion.Text;
                x.Localidad = txtLocalidad.Text;
                x.Télefono = txtTelefono.Text;
                x.LimiteCredito = Convert.ToDecimal(txtLimiteCredito.Text);
                x.Email = txtCorreo.Text;
                x.IdStatus = Convert.ToInt32(itemStauts.Value);
                x.IdNoEliminable = Convert.ToBoolean(itemNoEliminable.Value);
                x.IdGrupoEntidad = Convert.ToDecimal(itemGrupos.Value);
                x.IdTipoEntidadPolitica = Convert.ToInt32(itemTipoEntidadPolitica.Value);
                x.IdTipoDocumento = Convert.ToInt32(itemTipoDocumento.Value);
                x.IdRolUserEntidad = Convert.ToInt32(itemRol.Value);
                x.IdTipoEntidad = Convert.ToInt32(itemTipoEntidad.Value);
                x.IdRedesSociales = services.findLastIdRedSocial();
            };

            return x;
        }

        public bool createRedSocial()
        {
            bool valor = services.createRedSocial(GlobalRepositoty.Instance.RedesSociales);

            if (!valor)
            {
                MessageBox.Show("Ha ocurrido un problema cunado se estaba creando el registro de la red social, intente de nuevo por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool createEntidadInDataBase()
        {
            bool valor = services.createEntidad(GlobalRepositoty.Instance.entidadad);

            if (!valor)
            {
                MessageBox.Show("Ha ocurrido un problema cunado se estaba creando el registro de entidad , intente de nuevo por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool UpdateEntidadInDataBase()
        {
            bool valor = services.UpdateEntidad(GlobalRepositoty.Instance.entidadad,GlobalRepositoty.Instance.IdEntidad);

            if (!valor)
            {
                MessageBox.Show("Ha ocurrido un problema cunado se estaba actualizando el registro de entidad , intente de nuevo por favor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion



        #region Loads
        private void loadElimibable()
        {

            var status = serviceDef.getAllEliminable();

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
            var status = serviceDef.getAllGrupoEntidad();

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

            var status = serviceDef.getAllStatus();

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
        private void loadTipoEntidad()
        {

            var status = serviceDef.GetAllTipoEntidad();

            foreach (var item in status)
            {
                ComboBoxItem objecto = new ComboBoxItem();
                {
                    objecto.Text = item.Descripcion;
                    objecto.Value = item.IdTipoEntidades;
                }
                cbxTipoEntidad.Items.Add(objecto);
            }

            cbxTipoEntidad.SelectedIndex = 0;

        }
        private void loadTipoEntidadPolitica()
        {

            var status = serviceDef.getAllEntidadesPolitica();

            foreach (var item in status)
            {
                ComboBoxItem objecto = new ComboBoxItem();
                {
                    objecto.Text = item.Rol;
                    objecto.Value = item.Id;
                }
                cbxTipoEntidadPolitica.Items.Add(objecto);
            }

            cbxTipoEntidadPolitica.SelectedIndex = 0;

        }
        private void loadDocumento()
        {

            var status = serviceDef.getAllGrupoDocumento();

            foreach (var item in status)
            {
                ComboBoxItem objecto = new ComboBoxItem();
                {
                    objecto.Text = item.Documento;
                    objecto.Value = item.Id;
                }
                cbxTipoDocumento.Items.Add(objecto);
            }
            cbxTipoDocumento.SelectedIndex = 0;
        }
        private void loadRol()
        {

            var status = serviceDef.GetAllRoles();

            foreach (var item in status)
            {
                ComboBoxItem objecto = new ComboBoxItem();
                {
                    objecto.Text = item.Rol;
                    objecto.Value = item.Id;
                }
                cbxRolUserEntidad.Items.Add(objecto);
            }
            cbxRolUserEntidad.SelectedIndex = 0;
        }
        #endregion
    }
}
