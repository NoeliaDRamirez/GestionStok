using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class ArticuloIdentificador : IIdentificable<Articulo>
    {
        public bool ComprarIdentificador(Articulo entidad, object identificador)
        {
            return entidad.IdArticulo == (int)identificador;
        }

        public void Copiar(Articulo origen, Articulo destino)
        {
            if (destino != null && origen  != null)
            {
                destino.Activo = origen.Activo;
                destino.Codigo = origen.Codigo;
                destino.Descripcion = origen.Descripcion;
                destino.IdArticulo = origen.IdArticulo;
                destino.Nombre = origen.Nombre;
            }
        }

        public IQueryable<Articulo> FiltarPorentidad(IQueryable<Articulo> query, Articulo Entidad)
        {
            return query.Where(x=> x.IdArticulo == Entidad.IdArticulo);
        }

        public IQueryable<Articulo> FiltrarPorCodigo(IQueryable<Articulo> query, object Codigo)
        {
            return query.Where(x => x.Codigo == (Codigo as string));
        }

        public IQueryable<Articulo> FiltrarPorIdentificador(IQueryable<Articulo> query, object identificador)
        {
            return query.Where(x => x.IdArticulo == (int)identificador);
        }
    }
}
