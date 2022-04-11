using Dato.Model;
using Dato.Repositorio;
using Negocio.ModelosDto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class Services_Login
    {
        private SqlConnection _connection;
        Repositorio_Entidades data;
        

        public Services_Login(SqlConnection connection)
        {
            _connection = connection;
            data = new Repositorio_Entidades(_connection);

        }

        public bool Login(EntidadLoginDto usario)
        {
            if(usario == null)
            {
                return false;
            }

            Entidades UserFinded = new Entidades();

            UserFinded = data.findByUsuario(usario.Username);

            if(UserFinded == null)
            {
                return false;
            }
            if(usario.Password != UserFinded.PasswordEntidad)
            {
                return false;
            }

            return true;
        }
    }
}
