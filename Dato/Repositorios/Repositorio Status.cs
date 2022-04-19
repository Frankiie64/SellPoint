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
    public class Repositorio_Status
    {
        private SqlConnection _connection;

        public Repositorio_Status(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<Status> GetAllStauts()
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("Select * from Status", _connection);
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                Status data;

                List<Status> list = new List<Status>();

                while (reader.Read())
                {
                    data = new Status();
                    {
                        data.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
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
