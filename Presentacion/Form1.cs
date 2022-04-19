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
    public partial class Form1 : Form
    {
        private SqlConnection _con;
        public Form1(SqlConnection con)
        {
            InitializeComponent();
            _con = con;
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
