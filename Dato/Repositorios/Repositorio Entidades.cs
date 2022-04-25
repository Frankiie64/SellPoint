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
        public bool CreateTipoEntidad(Entidades item)
        {
            try
            {
                _connection.Open();

                SqlCommand sqlCommand = new SqlCommand("SP_InsertIntoEntidades", _connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                sqlCommand.Parameters.AddWithValue("@Direccion", item.Direccion);
                sqlCommand.Parameters.AddWithValue("@IdTipoEntidadPolitica", item.IdTipoEntidadPolitica);
                sqlCommand.Parameters.AddWithValue("@IdTipoDocumento", item.IdTipoDocumento);
                sqlCommand.Parameters.AddWithValue("@Localidad", item.Localidad);
                sqlCommand.Parameters.AddWithValue("@telefono", item.Télefono);
                sqlCommand.Parameters.AddWithValue("@IdRedesSociales", item.IdRedesSociales);
                sqlCommand.Parameters.AddWithValue("@IdTipoEntidad", item.IdTipoEntidad);
                sqlCommand.Parameters.AddWithValue("@limiteCredito", item.LimiteCredito);
                sqlCommand.Parameters.AddWithValue("@Username", item.UsernameEntidad);
                sqlCommand.Parameters.AddWithValue("@Password", item.PasswordEntidad);
                sqlCommand.Parameters.AddWithValue("@IdRolUserEntidad", item.IdRolUserEntidad);
                sqlCommand.Parameters.AddWithValue("@Email", item.Email);
                sqlCommand.Parameters.AddWithValue("@IdGrupoEntidad", item.IdGrupoEntidad);
                sqlCommand.Parameters.AddWithValue("@Comentario", item.Comentario);
                sqlCommand.Parameters.AddWithValue("@IdStatus", item.IdStatus);
                sqlCommand.Parameters.AddWithValue("@IdNoEliminable", item.IdNoEliminable);

                return ExecuteDml(sqlCommand);
            }
            catch
            {
                _connection.Close();
                return false;
            }
        }
        public bool UpdateEntidad(Entidades item,int id)
        {
            try
            {
                _connection.Open();

                SqlCommand sqlCommand = new SqlCommand("SP_UpdateEntidades", _connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                sqlCommand.Parameters.AddWithValue("@Direccion", item.Direccion);
                sqlCommand.Parameters.AddWithValue("@IdTipoEntidadPolitica", item.IdTipoEntidadPolitica);
                sqlCommand.Parameters.AddWithValue("@IdTipoDocumento", item.IdTipoDocumento);
                sqlCommand.Parameters.AddWithValue("@Localidad", item.Localidad);
                sqlCommand.Parameters.AddWithValue("@telefono", item.Télefono);
                sqlCommand.Parameters.AddWithValue("@IdRedesSociales", item.IdRedesSociales);
                sqlCommand.Parameters.AddWithValue("@IdTipoEntidad", item.IdTipoEntidad);
                sqlCommand.Parameters.AddWithValue("@limiteCredito", item.LimiteCredito);
                sqlCommand.Parameters.AddWithValue("@Username", item.UsernameEntidad);
                sqlCommand.Parameters.AddWithValue("@Password", item.PasswordEntidad);
                sqlCommand.Parameters.AddWithValue("@IdRolUserEntidad", item.IdRolUserEntidad);
                sqlCommand.Parameters.AddWithValue("@Email", item.Email);
                sqlCommand.Parameters.AddWithValue("@IdGrupoEntidad", item.IdGrupoEntidad);
                sqlCommand.Parameters.AddWithValue("@Comentario", item.Comentario);
                sqlCommand.Parameters.AddWithValue("@IdStatus", item.IdStatus);
                sqlCommand.Parameters.AddWithValue("@IdNoEliminable", item.IdNoEliminable);
                
                return ExecuteDml(sqlCommand);
            }
            catch
            {
                _connection.Close();
                return false;
            }
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
                    data.Descripcion = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    data.Direccion = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    data.Localidad = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    data.IdTipoEntidadPolitica = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                    data.IdTipoDocumento = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                    data.Télefono = reader.IsDBNull(6) ? "" : reader.GetString(6);
                    data.IdRedesSociales = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                    data.IdGrupoEntidad = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
                    data.IdTipoEntidad = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9);
                    data.LimiteCredito = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10);                  
                    data.UsernameEntidad = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    data.PasswordEntidad = reader.IsDBNull(12) ? "" : reader.GetString(12);
                    data.IdRolUserEntidad = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
                    data.Comentario = reader.IsDBNull(14) ? "" : reader.GetString(14);
                    data.IdStatus = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                    data.IdNoEliminable = reader.IsDBNull(16) ? false : reader.GetBoolean(16);
                    data.Email = reader.IsDBNull(18) ? "" : reader.GetString(18);


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
        public Entidades findByUsuario(int id)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("select * from Entidades where Id = @id", _connection);
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                Entidades data = new Entidades();

                while (reader.Read())
                {
                    data.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    data.Descripcion = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    data.Direccion = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    data.Localidad = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    data.IdTipoEntidadPolitica = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                    data.IdTipoDocumento = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                    data.Télefono = reader.IsDBNull(6) ? "" : reader.GetString(6);
                    data.IdRedesSociales = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                    data.IdGrupoEntidad = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
                    data.IdTipoEntidad = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9);
                    data.LimiteCredito = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10);
                    data.UsernameEntidad = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    data.PasswordEntidad = reader.IsDBNull(12) ? "" : reader.GetString(12);
                    data.IdRolUserEntidad = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
                    data.Comentario = reader.IsDBNull(14) ? "" : reader.GetString(14);
                    data.IdStatus = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                    data.IdNoEliminable = reader.IsDBNull(16) ? false : reader.GetBoolean(16);
                    data.Email = reader.IsDBNull(18) ? "" : reader.GetString(18);
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
        public bool deleteEntidad(int id)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SP_DeleteEntidad", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);                             

                 return ExecuteDml(command);                
            }
            catch (Exception ex)
            {
                _connection.Close();
                return false;
            }
        }
        public DataTable GetAllEntidad()
        {
            SqlCommand command = new SqlCommand("View_Entidad", _connection);
            command.CommandType = CommandType.StoredProcedure;

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
