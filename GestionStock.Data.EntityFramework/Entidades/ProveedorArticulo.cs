using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Entidades
{
    public partial class ProveedorArticuloIdentificador : IIdentificable<ProveedorArticulo>
    {
        public bool ComprarIdentificador(ProveedorArticulo entidad, object identificador)
        {
            return entidad.IdProveedorArticulo == (int)identificador;
        }

        public void Copiar(ProveedorArticulo origen, ProveedorArticulo destino)
        {
            if (destino != null && origen != null)
            {
                destino.IdProveedorArticulo = origen.IdProveedorArticulo;
                destino.IdProveedor = origen.IdProveedor;
                destino.IdArticuloMedida = origen.IdArticuloMedida;
                destino.IdForma = origen.IdForma;
                destino.Precio = origen.Precio;
                destino.Cantidad = origen.Cantidad;
                destino.FechaCompra =   origen.FechaCompra;
                destino.FechaPedido = origen.FechaPedido;
                destino.Entregado = origen.Entregado;
                destino.PlazoPactado = origen.PlazoPactado;
            }
        }

        public IQueryable<ProveedorArticulo> FiltarPorentidad(IQueryable<ProveedorArticulo> query, ProveedorArticulo Entidad)
        {
            return query.Where(x => x.IdProveedorArticulo == Entidad.IdProveedorArticulo);
        }

        public IQueryable<ProveedorArticulo> FiltrarPorCodigo(IQueryable<ProveedorArticulo> query, object Codigo)
        {
            return query;
        }

        public IQueryable<ProveedorArticulo> FiltrarPorIdentificador(IQueryable<ProveedorArticulo> query, object identificador)
        {
            return query.Where(x => x.IdProveedorArticulo == (int)identificador);
        }
    }
}
