using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public abstract class FiltroBase<TEntidad> : FiltroBase
    {
        public abstract IQueryable<TEntidad> AplicarOrdenamiento(IQueryable<TEntidad> consulta);
        public abstract IQueryable<TEntidad> AplicarFiltro(IQueryable<TEntidad> consulta);
    }
}
