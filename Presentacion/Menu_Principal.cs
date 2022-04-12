using Dato.Model;
using Negocio.ModelosDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class Menu_Principal : Form
    {

        //Dato.Model.Entidades _entidades = new Dato.Model.Entidades();
        EntidadLoginDto entidadLoginDto = new EntidadLoginDto();



        public Menu_Principal()
        {
            InitializeComponent();

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca_De acerca_De = new Acerca_De();
            acerca_De.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Text = "Hola";
            //labelNombreUsuario.Text = Dato.Model.Entidades.Id;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString("hh:mm:ss");
            labelFecha.Text = DateTime.Now.ToLongDateString();

        }

        private void gruposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grupos_Entidades grupos_Entidades = new Grupos_Entidades();
            grupos_Entidades.Show();
        }

        private void tiposEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tipos_Entidades tipos_Entidades = new Tipos_Entidades();
            tipos_Entidades.Show();
        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entidades entidades = new Entidades();
            entidades.Show();
        }

        private void labelNombreUsuario_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
