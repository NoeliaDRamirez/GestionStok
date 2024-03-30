using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class PosicionIdentificador : IIdentificable<Posicion>
    {
        public bool ComprarIdentificador(Posicion entidad, object identificador)
        {
            return entidad.IdPosicion == (int)identificador;
        }

        public void Copiar(Posicion origen, Posicion destino)
        {
            if (destino != null && origen != null)
            {
                destino.Activo = origen.Activo;
                destino.Codigo = origen.Codigo;
                destino.IdPosicion = origen.IdPosicion;
                destino.Nombre = origen.Nombre;
            }
        }

        public IQueryable<Posicion> FiltarPorentidad(IQueryable<Posicion> query, Posicion Entidad)
        {
            return query.Where(x => x.IdPosicion == Entidad.IdPosicion);
        }

        public IQueryable<Posicion> FiltrarPorCodigo(IQueryable<Posicion> query, object Codigo)
        {
            return query.Where(x => x.Codigo == (Codigo as string));
        }

        public IQueryable<Posicion> FiltrarPorIdentificador(IQueryable<Posicion> query, object identificador)
        {
            return query.Where(x => x.IdPosicion == (int)identificador);
        }
    }
}
