using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dato
{
    public class Datos_GruposEntidades
    {
        //public SqlConnection _connection;
        private Datos_Conexion connection = new Datos_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()  //Mostrar la tabla
        {
            comando.Connection = connection.AbrirConexionBD();
            comando.CommandText = "MostrarGruposEntidades";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            connection.CerrarConexionBD();
            return tabla;
        }

        //CREATE
        public void Insertar(string Descripcion, string Comentario, int IdStatus, bool IdNoEliminable, DateTime FechaRegistro) //Metodo Insertar
        {
            //"insert into GruposEntidades values('" + Descripcion + "', '" + Comentario + "', " + IdStatus + ", '" + IdNoEliminable + "', '" + FechaRegistro + "')"
            comando.Connection = connection.AbrirConexionBD();
            comando.CommandText = "InsertarGruposEntidades";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Comentario", Comentario);
            comando.Parameters.AddWithValue("@IdStatus", IdStatus);
            comando.Parameters.AddWithValue("@IdNoEliminable", IdNoEliminable);
            comando.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }



        //Editar
        public void Editar(string Descripcion, string Comentario, int IdStatus, bool IdNoEliminable, DateTime FechaRegistro, int id) //Metodo Insertar
        {
            //"insert into GruposEntidades values('" + Descripcion + "', '" + Comentario + "', " + IdStatus + ", '" + IdNoEliminable + "', '" + FechaRegistro + "')"
            comando.Connection = connection.AbrirConexionBD();
            comando.CommandText = "EditarGruposEntidades";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Comentario", Comentario);
            comando.Parameters.AddWithValue("@IdStatus", IdStatus);
            comando.Parameters.AddWithValue("@IdNoEliminable", IdNoEliminable);
            comando.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        //Eliminar
        public void Eliminar(int id)
        {
            comando.Connection = connection.AbrirConexionBD();
            comando.CommandText = "EliminarGrupoEntidades";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }


    }
}
