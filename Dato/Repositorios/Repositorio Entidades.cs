using Dato.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dato.Repositorio
{
    public class Repositorio_Entidades
    {

        private SqlConnection _connection;

        public Repositorio_Entidades(SqlConnection connection)
        {
            _connection = connection;
        }

        public Entidades findByUsuario(string usuario)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SP_BuscarUsario", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@user", usuario);

                SqlDataReader reader = command.ExecuteReader();

                Entidades data = new Entidades();

                while (reader.Read())
                {
                    data.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    data.UsernameEntidad = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    data.PasswordEntidad = reader.IsDBNull(12) ? "" : reader.GetString(12);
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


    }
}
