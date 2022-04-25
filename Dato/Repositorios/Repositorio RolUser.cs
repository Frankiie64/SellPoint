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
    public class Repositorio_RolUser
    {
        private SqlConnection _connection;

        public Repositorio_RolUser(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<RolUserEntidad> GetAllRoles()
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("Select * from RolUserEntidad", _connection);
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                RolUserEntidad data;

                List<RolUserEntidad> list = new List<RolUserEntidad>();

                while (reader.Read())
                {
                    data = new RolUserEntidad();
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