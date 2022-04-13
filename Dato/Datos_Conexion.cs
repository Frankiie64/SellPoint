using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dato
{
    internal class Datos_Conexion
    {
        public SqlConnection _connection = new SqlConnection("workstation id=Prog2Final.mssql.somee.com;packet size=4096;user id=Jesus12112002_SQLLogin_1;pwd=94z9r9vhjq;data source=Prog2Final.mssql.somee.com;persist security info=False;initial catalog=Prog2Final");

        //Abrir Conexion de Base de Datos
        public SqlConnection AbrirConexionBD()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open(); //Chequear sin Async
            }
            return _connection;
        }

        //Cerrar Conexion de Base de Datos
        public SqlConnection CerrarConexionBD()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close(); //Chequear sin Async
            }
            return _connection;
        }
    }
}
