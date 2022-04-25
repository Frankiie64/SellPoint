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
    public class Repositorio_TipoDocumento
    {
        private SqlConnection _connection;

        public Repositorio_TipoDocumento(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<TipoDocumento> GetAllTipoEntidadPolitica()
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("Select * from tipoDocumento", _connection);
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                TipoDocumento data;

                List<TipoDocumento> list = new List<TipoDocumento>();

                while (reader.Read())
                {
                    data = new TipoDocumento();
                    {
                        data.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        data.Documento = reader.IsDBNull(1) ? "" : reader.GetString(1);
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