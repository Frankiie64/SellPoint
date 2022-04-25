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
    public class Repositorio_Redes_Sociales
    {
        private SqlConnection _connection;

        public Repositorio_Redes_Sociales(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool CreateRedSocial(RedesSociales item)
        {
            try
            {
                _connection.Open();

                SqlCommand sqlCommand = new SqlCommand("SP_InsertRedSocial", _connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Urlfacebook", item.Urlfacebook);
                sqlCommand.Parameters.AddWithValue("@Urlinstagram", item.Urlinstagram);
                sqlCommand.Parameters.AddWithValue("@Urltwitter", item.Urltwitter);
                sqlCommand.Parameters.AddWithValue("@UrlpaginaWeb", item.UrlpaginaWeb);
                sqlCommand.Parameters.AddWithValue("@UrltikTok", item.UrltikTok);

                return ExecuteDml(sqlCommand);

            }
            catch
            {
                _connection.Close();
                return false;
            }
        }
        public int findLastIdRedSocial()
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT max(id) FROM RedesSociales", _connection);
                command.CommandType = CommandType.Text;


                SqlDataReader reader = command.ExecuteReader();

                RedesSociales data = new RedesSociales();

                while (reader.Read())
                {
                    data.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);                 
                }

                reader.Close();
                reader.Dispose();

                _connection.Close();

                return data.Id;

            }
            catch (Exception ex)
            {
                _connection.Close();
                return 0;
            }
        }
        public RedesSociales findById(int id)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("select * from RedesSociales where Id = @id", _connection);
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                RedesSociales data = new RedesSociales();

                while (reader.Read())
                {
                    data.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    data.UrlpaginaWeb = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    data.Urlfacebook = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    data.Urlinstagram = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    data.Urltwitter = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    data.UrltikTok = reader.IsDBNull(5) ? "" : reader.GetString(5);
                   
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
        private bool ExecuteDml(SqlCommand command)
        {
            try
            {

                command.ExecuteNonQuery();

                _connection.Close();

                return true;
            }
            catch
            {
                _connection.Close();
                return false;
            }

        }
    }
}
