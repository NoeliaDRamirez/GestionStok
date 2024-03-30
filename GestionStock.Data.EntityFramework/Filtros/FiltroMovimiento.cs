using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroMovimiento : FiltroBase<Movimiento>
    {
        public int? IdMovimiento { get; set; }
        public int? IdTipoMovimiento { get; set; }
        public int? IdArticuloMedida { get; set; }
        public Nullable<int> IdPosicionOrigen { get; set; }
        public Nullable<int> IdProveedorOrigen { get; set; }
        public Nullable<int> IdVentaOrigen { get; set; }
        public Nullable<int> IdPosicionDestino { get; set; }
        public Nullable<int> IdProveedorDestino { get; set; }
        public Nullable<int> IdVentaDestino { get; set; }
        public int? Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public override IQueryable<Movimiento> AplicarOrdenamiento(IQueryable<Movimiento> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(Movimiento.IdMovimiento):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdMovimiento);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdMovimiento);
                        }

                        break;
                    case nameof(Movimiento.IdTipoMovimiento):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdTipoMovimiento);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdTipoMovimiento);
                        }
                        break;
                    case nameof(Movimiento.IdArticuloMedida):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticuloMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticuloMedida);
                        }
                        break;
                    case nameof(Movimiento.IdPosicionOrigen):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdPosicionOrigen);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdPosicionOrigen);
                        }
                        break;
                    case nameof(Movimiento.IdProveedorOrigen):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdProveedorOrigen);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdProveedorOrigen);
                        }
                        break;
                    case nameof(Movimiento.IdVentaOrigen):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdVentaOrigen);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdVentaOrigen);
                        }
                        break;
                    case nameof(Movimiento.IdPosicionDestino):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdPosicionDestino);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdPosicionDestino);
                        }
                        break;
                    case nameof(Movimiento.IdProveedorDestino):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdProveedorDestino);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdProveedorDestino);
                        }
                        break;
                    case nameof(Movimiento.IdVentaDestino):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdVentaDestino);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdVentaDestino);
                        }
                        break;
                    case nameof(Movimiento.Cantidad):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Cantidad);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Cantidad);
                        }
                        break;
                    case nameof(Movimiento.Fecha):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Fecha);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Fecha);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdMovimiento);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdMovimiento);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdMovimiento);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdMovimiento);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<Movimiento> AplicarFiltro(IQueryable<Movimiento> consulta)
        {
            if (this.IdMovimiento != null)
            {
                consulta = consulta.Where(x => x.IdMovimiento == this.IdMovimiento);
            }
            if (this.IdTipoMovimiento != null)
            {
                consulta = consulta.Where(x => x.IdTipoMovimiento == this.IdTipoMovimiento);
            }
            if (this.IdArticuloMedida != null)
            {
                consulta = consulta.Where(x => x.IdArticuloMedida == this.IdArticuloMedida);
            }
            if (this.IdPosicionOrigen != null)
            {
                consulta = consulta.Where(x => x.IdPosicionOrigen == this.IdPosicionOrigen);
            }
            if (this.IdPosicionDestino != null)
            {
                consulta = consulta.Where(x => x.IdPosicionDestino == this.IdPosicionDestino);
            }
            if (this.IdProveedorOrigen != null)
            {
                consulta = consulta.Where(x => x.IdProveedorOrigen == this.IdProveedorOrigen);
            }
            if (this.IdProveedorDestino != null)
            {
                consulta = consulta.Where(x => x.IdProveedorDestino == this.IdProveedorDestino);
            }
            if (this.IdVentaOrigen != null)
            {
                consulta = consulta.Where(x => x.IdVentaOrigen == this.IdVentaOrigen);
            }
            if (this.IdVentaDestino != null)
            {
                consulta = consulta.Where(x => x.IdVentaDestino == this.IdVentaDestino);
            }
            if (this.Cantidad != null)
            {
                consulta = consulta.Where(x => x.Cantidad == this.Cantidad);
            }
            if (this.Fecha != DateTime.MinValue)
            {
                consulta = consulta.Where(x => x.Fecha == this.Fecha);
            }

            return consulta;
        }
    }
}
