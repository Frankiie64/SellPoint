using Dato.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dato.Repositorios
{
    public class Repositorio_TipoEntidad
    {
        private SqlConnection _connection;

        public Repositorio_TipoEntidad(SqlConnection connection)
        {
            _connection = connection;
        }
        public TipoEntidades findByIdTipoEntidad(int IdTipoEntidades)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("select * from TipoEntidades where IdTipoEntidades = @IdTipoEntidades", _connection);
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@IdTipoEntidades", IdTipoEntidades);

                SqlDataReader reader = command.ExecuteReader();

                TipoEntidades data = new TipoEntidades();

                while (reader.Read())
                {
                    data.IdTipoEntidades = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                    data.Descripcion = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    data.IdGrupoEntidad = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                    data.Comentario = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    data.IdStatus = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                    data.IdNoEliminable = reader.IsDBNull(5) ? false : reader.GetBoolean(5);
                    data.FechaRegistro = reader.IsDBNull(6) ? default : reader.GetDateTime(6);

                }

                reader.Close();
                reader.Dispose();

                _connection.Close();

                return data;

            }
            catch (Exception ex)
            {
                _connection.Close();
                return null;
            }
        }

        public DataTable GetAllTipoEntidad()
        {
            SqlCommand command = new SqlCommand("select * from  TipoEntidades", _connection);
            command.CommandType = CommandType.Text;

            SqlDataAdapter query = new SqlDataAdapter(command);

            return LoadTable(query);
        }

        private DataTable LoadTable(SqlDataAdapter Query)
        {
            try
            {

                DataTable Data = new DataTable();

                _connection.Open();

                Query.Fill(Data);

                _connection.Close();

                return Data;

            }
            catch (Exception ex)
            {

                return null;
            }

        }

    }
}
