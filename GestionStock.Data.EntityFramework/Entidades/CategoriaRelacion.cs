using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class CategoriaRelacionIdentificador : IIdentificable<CategoriaRelacion>
    {
        public bool ComprarIdentificador(CategoriaRelacion entidad, object identificador)
        {
            return entidad.IdCategoriaRelacion == (int)identificador;
        }

        public void Copiar(CategoriaRelacion origen, CategoriaRelacion destino)
        {
            if (destino != null && origen  != null)
            {
                destino.IdCategoriaHijo = origen.IdCategoriaHijo;
                destino.IdCategoriaPadre = origen.IdCategoriaPadre;
            }
        }

        public IQueryable<CategoriaRelacion> FiltarPorentidad(IQueryable<CategoriaRelacion> query, CategoriaRelacion Entidad)
        {
            return query.Where(x=> x.IdCategoriaRelacion == Entidad.IdCategoriaRelacion);
        }

        public IQueryable<CategoriaRelacion> FiltrarPorCodigo(IQueryable<CategoriaRelacion> query, object Codigo)
        {
            return query;
        }

        public IQueryable<CategoriaRelacion> FiltrarPorIdentificador(IQueryable<CategoriaRelacion> query, object identificador)
        {
            return query.Where(x => x.IdCategoriaRelacion == (int)identificador);
        }
    }
}
