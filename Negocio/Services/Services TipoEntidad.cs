using Dato;
using Dato.Model;
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
    public class Services_TipoEntidad
    {
        private SqlConnection _connection;
        private Repositorio_TipoEntidad data;
        private Datos_GruposEntidades _repoGrupo;

        public Services_TipoEntidad(SqlConnection connection)
        {
            _connection = connection;
            data = new Repositorio_TipoEntidad(_connection);
        }

        public TipoEntidades GetTipoEntidadesById(int id)
        {
            return data.findByIdTipoEntidad(id);
        }
        public GruposEntidades GetGrupoEntidadesById(int id)
        {
            return _repoGrupo.GetGrupoEntidadesById(id);
        }

        public bool CreateTipoEntidad(TipoEntidades item)
        {
            return data.CreateTipoEntidad(item);
        }
        public bool UpdateTipoEntidad(TipoEntidades item,int id)
        {
            return data.updateTipoEntidad(item,id);
        }
        public bool deleteTipoEntidad(int id)
        {
            return data.deleteTipoEntidad(id);
        }
        public DataTable loadTable()
        {
            return data.GetAllTipoEntidad();
        }
    }
}
