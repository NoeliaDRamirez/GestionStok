using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Entidades
{
    public partial class MovimientoIdentificador : IIdentificable<Movimiento>
    {
        public bool ComprarIdentificador(Movimiento entidad, object identificador)
        {
            return entidad.IdMovimiento == (int)identificador;
        }

        public void Copiar(Movimiento origen, Movimiento destino)
        {
            if (destino != null && origen != null)
            {
                destino.IdMovimiento = origen.IdMovimiento;
                destino.IdTipoMovimiento = origen.IdTipoMovimiento;
                destino.IdArticuloMedida = origen.IdArticuloMedida;
                destino.IdPosicionOrigen= origen.IdPosicionOrigen;
                destino.IdProveedorOrigen = origen.IdProveedorOrigen;
                destino.IdVentaOrigen = origen.IdVentaOrigen;
                destino.IdPosicionDestino = origen.IdPosicionDestino;
                destino.IdProveedorDestino= origen.IdProveedorDestino;
                destino.IdVentaDestino= origen.IdVentaDestino; ;
                destino.Cantidad = origen.Cantidad;
                destino.Fecha = origen.Fecha;

            }
        }

        public IQueryable<Movimiento> FiltarPorentidad(IQueryable<Movimiento> query, Movimiento Entidad)
        {
            return query.Where(x => x.IdMovimiento == Entidad.IdMovimiento);
        }

        public IQueryable<Movimiento> FiltrarPorCodigo(IQueryable<Movimiento> query, object Codigo)
        {
            return query;
        }

        public IQueryable<Movimiento> FiltrarPorIdentificador(IQueryable<Movimiento> query, object identificador)
        {
            return query.Where(x => x.IdMovimiento == (int)identificador);
        }
    }
}