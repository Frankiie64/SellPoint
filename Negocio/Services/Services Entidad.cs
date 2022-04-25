using Dato.Model;
using Dato.Repositorio;
using Dato.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class Services_Entidad
    {
        private SqlConnection _connection;
        Repositorio_Entidades data;
        Repositorio_Redes_Sociales _Redes_Sociales;
        public Services_Entidad(SqlConnection connection)
        {
            _connection = connection;
            data = new Repositorio_Entidades(_connection);
            _Redes_Sociales = new Repositorio_Redes_Sociales(_connection);
        }

        public bool ValidarUser(string user)
        {
            Entidades item =  data.findByUsuario(user);

            if (item.UsernameEntidad == null)
            {
                return false;
            }
            return true;
        }
        public Entidades GetEntidad(int id)
        {
            return data.findByUsuario(id);
        }
        public RedesSociales findByIdRedes(int id)
        {
            return _Redes_Sociales.findById(id);
        }
        public bool createRedSocial(RedesSociales item)
        {
            return _Redes_Sociales.CreateRedSocial(item);
        }
        public bool createEntidad(Entidades item)
        {
            return data.CreateTipoEntidad(item);
        }
        public bool UpdateEntidad(Entidades item,int id)
        {
            return data.UpdateEntidad(item,id);
        }
        public bool deleteEntidad(int id)
        {
            return data.deleteEntidad(id);
        }
        public DataTable GetAllEntidad()
        {
            return data.GetAllEntidad();
        }
        public int findLastIdRedSocial()
        {
            return _Redes_Sociales.findLastIdRedSocial();
        }

    }
}
