using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class VentaIdentificador : IIdentificable<Venta>
    {
        public bool ComprarIdentificador(Venta entidad, object identificador)
        {
            return entidad.IdVenta == (int)identificador;
        }

        public void Copiar(Venta origen, Venta destino)
        {
            if (destino != null && origen != null)
            {
                destino.IdCliente = origen.IdCliente;
                destino.Fecha = origen.Fecha;
                destino.Monto = origen.Monto;
                destino.IdVenta = origen.IdVenta;
                destino.IdForma = origen.IdForma;
            }
        }

        public IQueryable<Venta> FiltarPorentidad(IQueryable<Venta> query, Venta Entidad)
        {
            return query.Where(x => x.IdVenta == Entidad.IdVenta);
        }

        public IQueryable<Venta> FiltrarPorCodigo(IQueryable<Venta> query, object Codigo)
        {
            return query;
        }

        public IQueryable<Venta> FiltrarPorIdentificador(IQueryable<Venta> query, object identificador)
        {
            return query.Where(x => x.IdVenta == (int)identificador);
        }
    }
}
