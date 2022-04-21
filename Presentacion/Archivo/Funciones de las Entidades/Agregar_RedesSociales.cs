using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Archivo.Funciones_de_las_Entidades
{
    public partial class Agregar_RedesSociales : Form
    {
        public Agregar_RedesSociales()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //HACER LA CONFIGURACION PARA GUARDAR ABAJO DE ESTA LINEA
            //
            //
            //
            //

            Agregar_Entidad agregar_Entidades = new Agregar_Entidad();
            this.Hide();
            agregar_Entidades.Show();
        }
    }
}
