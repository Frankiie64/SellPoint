using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dato;

namespace Negocio
{
    public class Negocio_GruposEntidades
    {
        public Datos_GruposEntidades datos_GrupoEntidades = new Datos_GruposEntidades();


        public DataTable MostrarGrupoEntidades()
        {
            DataTable tabla = new DataTable();
            tabla = datos_GrupoEntidades.Mostrar();
            return tabla;
        }

        public void Insertar_GrupoEntidades(string Descripcion, string Comentario, int IdStatus, bool IdNoEliminable, DateTime FechaRegistro)
        {
            datos_GrupoEntidades.Insertar(Descripcion, Comentario, Convert.ToInt32(IdStatus), Convert.ToBoolean(IdNoEliminable), Convert.ToDateTime(FechaRegistro));
        }

        public void Editar_GrupoEntidades(string Descripcion, string Comentario, int IdStatus, bool IdNoEliminable, DateTime FechaRegistro, string id)
        {
            datos_GrupoEntidades.Editar(Descripcion, Comentario, Convert.ToInt32(IdStatus), Convert.ToBoolean(IdNoEliminable), Convert.ToDateTime(FechaRegistro), Convert.ToInt32(id));
        }

        public void Eliminar_GrupoEntidades(string id)
        {
            datos_GrupoEntidades.Eliminar(Convert.ToInt32(id));
        }

    }
}
