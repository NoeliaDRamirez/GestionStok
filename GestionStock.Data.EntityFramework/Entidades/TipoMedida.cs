using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class TipoMedidaIdentificador : IIdentificable<TipoMedida>
    {
        public bool ComprarIdentificador(TipoMedida entidad, object identificador)
        {
            return entidad.IdTipoMedida == (int)identificador;
        }

        public void Copiar(TipoMedida origen, TipoMedida destino)
        {
            if (destino != null && origen  != null)
            {               
                destino.Codigo = origen.Codigo;               
                destino.IdTipoMedida = origen.IdTipoMedida;
                destino.Nombre = origen.Nombre;
            }
        }

        public IQueryable<TipoMedida> FiltarPorentidad(IQueryable<TipoMedida> query, TipoMedida Entidad)
        {
            return query.Where(x=> x.IdTipoMedida == Entidad.IdTipoMedida);
        }

        public IQueryable<TipoMedida> FiltrarPorCodigo(IQueryable<TipoMedida> query, object Codigo)
        {
            return query.Where(x => x.Codigo == (Codigo as string));
        }

        public IQueryable<TipoMedida> FiltrarPorIdentificador(IQueryable<TipoMedida> query, object identificador)
        {
            return query.Where(x => x.IdTipoMedida == (int)identificador);
        }
    }
}
