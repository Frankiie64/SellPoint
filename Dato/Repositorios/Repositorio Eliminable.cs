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
    public class Repositorio_Eliminable
    {
        private SqlConnection _connection;

        public Repositorio_Eliminable(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<NoEliminable> GetAllEliminable()
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("Select * from NoEliminable", _connection);
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                NoEliminable data;

                List<NoEliminable> list = new List<NoEliminable>();

                while (reader.Read())
                {
                    data = new NoEliminable();
                    {
                        data.Id = reader.IsDBNull(0) ? false : reader.GetBoolean(0);
                        data.Estado = reader.IsDBNull(1) ? "" : reader.GetString(1);
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
