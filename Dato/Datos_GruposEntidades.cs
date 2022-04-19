using Dato.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dato
{
    public class Datos_GruposEntidades
    {
        //public SqlConnection _connection;
        private Datos_Conexion connection = new Datos_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        SqlConnection _con;

        public Datos_GruposEntidades(SqlConnection con)
        {
            _con = con;
        }

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
        public GruposEntidades GetGrupoEntidadesById(int Id) //Leer los registros
        {
            try
            {
                _con.Open();

                SqlCommand command = new SqlCommand("select * from GruposEntidades where IdGrupoEnitdad = @IdGrupoEnitdad", _con);
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@IdGrupoEnitdad", Id);

                SqlDataReader reader = command.ExecuteReader();

                GruposEntidades data = new GruposEntidades();


                while (reader.Read())
                {

                    data.IdGrupoEnitdad = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                    data.Descripcion = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    data.Comentario = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    data.IdStatus = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                    data.IdNoEliminable = reader.IsDBNull(4) ? false : reader.GetBoolean(4);


                }
                reader.Close();
                reader.Dispose();

                _con.Close();

                return data;

            }
            catch (Exception ex)
            {
                _con.Close();
                return null;
            }
        }

        public List<GruposEntidades> GetAllGrupoEntidades() //Leer los registros
        {
            try
            {
                _con.Open();

                SqlCommand command = new SqlCommand("select * from GruposEntidades", _con);
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                GruposEntidades data;

                List<GruposEntidades> list = new List<GruposEntidades>();

                while (reader.Read())
                {
                    data = new GruposEntidades();
                    {
                        data.IdGrupoEnitdad = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                        data.Descripcion = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        data.Comentario = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        data.IdStatus = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        data.IdNoEliminable = reader.IsDBNull(4) ? false : reader.GetBoolean(4);
                    }

                    list.Add(data);
                }

                reader.Close();
                reader.Dispose();

                _con.Close();

                return list;

            }
            catch (Exception ex)
            {
                _con.Close();
                return null;
            }
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
