using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class TipoMovimientoIdentificador : IIdentificable<TipoMovimiento>
    {
        public bool ComprarIdentificador(TipoMovimiento entidad, object identificador)
        {
            return entidad.IdTipoMovimiento == (int)identificador;
        }

        public void Copiar(TipoMovimiento origen, TipoMovimiento destino)
        {
            if (destino != null && origen != null)
            {
                destino.Codigo = origen.Codigo;
                destino.IdTipoMovimiento = origen.IdTipoMovimiento;
                destino.Nombre = origen.Nombre;
            }
        }

        public IQueryable<TipoMovimiento> FiltarPorentidad(IQueryable<TipoMovimiento> query, TipoMovimiento Entidad)
        {
            return query.Where(x => x.IdTipoMovimiento == Entidad.IdTipoMovimiento);
        }

        public IQueryable<TipoMovimiento> FiltrarPorCodigo(IQueryable<TipoMovimiento> query, object Codigo)
        {
            return query.Where(x => x.Codigo == (Codigo as string));
        }

        public IQueryable<TipoMovimiento> FiltrarPorIdentificador(IQueryable<TipoMovimiento> query, object identificador)
        {
            return query.Where(x => x.IdTipoMovimiento == (int)identificador);
        }
    }
}
