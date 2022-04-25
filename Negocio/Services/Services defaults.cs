using Dato;
using Dato.Model;
using Dato.Repositorios;
using Negocio.ModelosDto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class Services_defaults
    {
        private SqlConnection _connection;

        Repositorio_Status _repoStatus;
        Repositorio_Eliminable _repoEliminable;
        Datos_GruposEntidades _repoGrupoEnitdad;
        Repositorio_TipoDocumento _repoDocumento;
        Repositorio_TipoEntidad_Politica _repoPolitica;
        Repositorio_TipoEntidad _repoTipoEntidad;
        Repositorio_RolUser _repoRolUser;


        public Services_defaults(SqlConnection connection)
        {
            _connection = connection;
            _repoStatus = new Repositorio_Status(_connection);
            _repoEliminable = new Repositorio_Eliminable(_connection);
            _repoGrupoEnitdad = new Datos_GruposEntidades(_connection);
            _repoDocumento = new Repositorio_TipoDocumento(_connection);
             _repoPolitica = new Repositorio_TipoEntidad_Politica(_connection);
             _repoTipoEntidad = new Repositorio_TipoEntidad(_connection);
            _repoRolUser = new Repositorio_RolUser(_connection);
        }

        public List<StatusDto> getAllStatus()
        {
            List<StatusDto> listdto = new List<StatusDto>();
            List<Status> statuses = _repoStatus.GetAllStauts();

            foreach(Status item in statuses)
            {
                StatusDto itemdto = new StatusDto() {
                    Id = item.Id,
                    Estado = item.Estado
                };

                listdto.Add(itemdto);
            }

            return listdto;
        }
        public List<NoEliminableDto> getAllEliminable()
        {
            List<NoEliminableDto> listdto = new List<NoEliminableDto>();
            List<NoEliminable> NoEliminable = _repoEliminable.GetAllEliminable();

            foreach(NoEliminable item in NoEliminable)
            {
                NoEliminableDto itemdto = new NoEliminableDto()
                {
                    Id = item.Id,
                    Estado = item.Estado
                };

                listdto.Add(itemdto);
            }
            
            return listdto;
        }
        public List<TipoDocumento> getAllGrupoDocumento()
        {
            return _repoDocumento.GetAllTipoEntidadPolitica();
        }
        public List<TipoEntidadPolitica> getAllEntidadesPolitica()
        {
            return _repoPolitica.GetAllTipoEntidadPolitica();
        }
        public List<RolUserEntidad> GetAllRoles()
        {
            return _repoRolUser.GetAllRoles();
        }
        public List<TipoEntidades> GetAllTipoEntidad()
        {
            return _repoTipoEntidad.findAllTipoEntidad();
        }

        public List<GruposEntidadesDto> getAllGrupoEntidad()
        {
            List<GruposEntidadesDto> listdto = new List<GruposEntidadesDto>();
            List<GruposEntidades> gruposEntidades = _repoGrupoEnitdad.GetAllGrupoEntidades();

            foreach (GruposEntidades item in gruposEntidades)
            {
                GruposEntidadesDto itemdto = new GruposEntidadesDto()
                {
                    IdGrupoEnitdad = item.IdGrupoEnitdad,
                    Descripcion = item.Descripcion,
                    Comentario = item.Comentario,
                    IdStatus = item.IdStatus,
                    IdNoEliminable = item.IdNoEliminable
                };

                listdto.Add(itemdto);
            }

            return listdto;
        }



    }
}
