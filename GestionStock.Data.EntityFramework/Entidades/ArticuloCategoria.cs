using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class ArticuloCategoriaIdentificador : IIdentificable<ArticuloCategoria>
    {
        public bool ComprarIdentificador(ArticuloCategoria entidad, object identificador)
        {
            return entidad.IdArticuloCategoria == (int)identificador;
        }

        public void Copiar(ArticuloCategoria origen, ArticuloCategoria destino)
        {
            if (destino != null && origen  != null)
            {
                destino.IdArticulo = origen.IdArticulo;
                destino.IdCategoria = origen.IdCategoria;
                destino.IdArticuloCategoria = origen.IdArticuloCategoria;
            }
        }

        public IQueryable<ArticuloCategoria> FiltarPorentidad(IQueryable<ArticuloCategoria> query, ArticuloCategoria Entidad)
        {
            return query.Where(x=> x.IdArticuloCategoria == Entidad.IdArticuloCategoria);
        }

        public IQueryable<ArticuloCategoria> FiltrarPorCodigo(IQueryable<ArticuloCategoria> query, object Codigo)
        {
            return query;
        }

        public IQueryable<ArticuloCategoria> FiltrarPorIdentificador(IQueryable<ArticuloCategoria> query, object identificador)
        {
            return query.Where(x => x.IdArticuloCategoria == (int)identificador);
        }
    }
}
