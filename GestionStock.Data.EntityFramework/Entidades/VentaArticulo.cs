using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Entidades
{
    public partial class VentaArticuloIdentificador : IIdentificable<VentaArticulo>
    {
        public bool ComprarIdentificador(VentaArticulo entidad, object identificador)
        {
            return entidad.IdVentaArticulo == (int)identificador;
        }

        public void Copiar(VentaArticulo origen, VentaArticulo destino)
        {
            if (destino != null && origen != null)
            {
                destino.IdVenta = origen.IdVenta;
                destino.IdVentaArticulo = origen.IdVentaArticulo;
                destino.IdArticulo = origen.IdArticulo;
                destino.IdArticuloMedida = origen.IdArticuloMedida;
                destino.Cantidad= origen.Cantidad;
                destino.Monto = origen.Monto;
                destino.MontoUnitario = origen.MontoUnitario;

            }
        }

        public IQueryable<VentaArticulo> FiltarPorentidad(IQueryable<VentaArticulo> query, VentaArticulo Entidad)
        {
            return query.Where(x => x.IdVentaArticulo == Entidad.IdVentaArticulo);
        }

        public IQueryable<VentaArticulo> FiltrarPorCodigo(IQueryable<VentaArticulo> query, object Codigo)
        {
            return query;
        }

        public IQueryable<VentaArticulo> FiltrarPorIdentificador(IQueryable<VentaArticulo> query, object identificador)
        {
            return query.Where(x => x.IdVentaArticulo == (int)identificador);
        }
    }
}
