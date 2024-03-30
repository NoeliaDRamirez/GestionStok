using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Entidades
{
    public partial class ArticuloMedidaIdentificador : IIdentificable<ArticuloMedida>
    {
        public bool ComprarIdentificador(ArticuloMedida entidad, object identificador)
        {
            return entidad.IdArticuloMedida == (int)identificador;
        }

        public void Copiar(ArticuloMedida origen, ArticuloMedida destino)
        {
            if (destino != null && origen != null)
            {
                destino.IdArticuloMedida = origen.IdArticuloMedida;
                destino.IdArticulo = origen.IdArticulo;
                destino.IdMedida = origen.IdMedida;
                destino.CantidadMinima = origen.CantidadMinima;
            }
        }

        public IQueryable<ArticuloMedida> FiltarPorentidad(IQueryable<ArticuloMedida> query, ArticuloMedida Entidad)
        {
            return query.Where(x => x.IdArticuloMedida == Entidad.IdArticuloMedida);
        }

        public IQueryable<ArticuloMedida> FiltrarPorCodigo(IQueryable<ArticuloMedida> query, object Codigo)
        {
            return query;
        }

        public IQueryable<ArticuloMedida> FiltrarPorIdentificador(IQueryable<ArticuloMedida> query, object identificador)
        {
            return query.Where(x => x.IdArticuloMedida == (int)identificador);
        }
    }
}
