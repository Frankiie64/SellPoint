using Dato.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dato.Repositorios
{
    public class Repositorio_TipoEntidad_Politica
    {
        private SqlConnection _connection;

        public Repositorio_TipoEntidad_Politica(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<TipoEntidadPolitica> GetAllTipoEntidadPolitica()
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("Select * from TipoentidadPolitica", _connection);
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                TipoEntidadPolitica data;

                List<TipoEntidadPolitica> list = new List<TipoEntidadPolitica>();

                while (reader.Read())
                {
                    data = new TipoEntidadPolitica();
                    {
                        data.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        data.Rol = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    }

                    list.Add(data);
                }

                reader.Close();
                reader.Dispose();

                _connection.Close();

                return list;

            }
            catch (Exception ex)
            {
                _connection.Close();
                return null;
            }
        }


    }
}