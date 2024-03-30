using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Entidades
{
    public partial class ArticuloMedidaPosicionIdentificador : IIdentificable<ArticuloMedidaPosicion>
    {
        public bool ComprarIdentificador(ArticuloMedidaPosicion entidad, object identificador)
        {
            return entidad.IdArticuloMedidaPosicion == (int)identificador;
        }

        public void Copiar(ArticuloMedidaPosicion origen, ArticuloMedidaPosicion destino)
        {
            if (destino != null && origen != null)
            {
                destino.IdArticuloMedida = origen.IdArticuloMedida;
                destino.IdPosicion = origen.IdPosicion;
                destino.IdArticuloMedidaPosicion = origen.IdArticuloMedidaPosicion;
            }
        }

        public IQueryable<ArticuloMedidaPosicion> FiltarPorentidad(IQueryable<ArticuloMedidaPosicion> query, ArticuloMedidaPosicion Entidad)
        {
            return query.Where(x => x.IdArticuloMedidaPosicion == Entidad.IdArticuloMedidaPosicion);
        }

        public IQueryable<ArticuloMedidaPosicion> FiltrarPorCodigo(IQueryable<ArticuloMedidaPosicion> query, object Codigo)
        {
            return query;
        }

        public IQueryable<ArticuloMedidaPosicion> FiltrarPorIdentificador(IQueryable<ArticuloMedidaPosicion> query, object identificador)
        {
            return query.Where(x => x.IdArticuloMedidaPosicion == (int)identificador);
        }
    }
}
