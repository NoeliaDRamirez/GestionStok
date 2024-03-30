using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroVentaArticulo: FiltroBase<VentaArticulo>
    {
        public int? IdVentaArticulo { get; set; }
        public int? IdVenta { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdArticuloMedida { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Monto { get; set; }
        public decimal? MontoUnitario { get; set; }

        public override IQueryable<VentaArticulo> AplicarOrdenamiento(IQueryable<VentaArticulo> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(VentaArticulo.IdVenta):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdVenta);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdVenta);
                        }

                        break;
                    case nameof(VentaArticulo.IdArticulo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticulo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticulo);
                        }
                        break;
                    case nameof(VentaArticulo.IdArticuloMedida):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticuloMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticuloMedida);
                        }
                        break;
                    case nameof(VentaArticulo.Monto):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Monto);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Monto);
                        }
                        break;
                    case nameof(VentaArticulo.MontoUnitario):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.MontoUnitario);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.MontoUnitario);
                        }
                        break;
                    case nameof(VentaArticulo.Cantidad):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Cantidad);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Cantidad);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdVentaArticulo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdVentaArticulo);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdVentaArticulo);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdVentaArticulo);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<VentaArticulo> AplicarFiltro(IQueryable<VentaArticulo> consulta)
        {
            if (this.IdVentaArticulo != null)
            {
                consulta = consulta.Where(x => x.IdVentaArticulo == this.IdVentaArticulo);
            }
            if (this.IdVenta != null)
            {
                consulta = consulta.Where(x => x.IdVenta == this.IdVenta);
            }
            if (this.IdArticulo != null)
            {
                consulta = consulta.Where(x => x.IdArticulo == this.IdArticulo);
            }
            if (this.Monto != null)
            {
                consulta = consulta.Where(x => x.Monto == this.Monto);
            }
            if (this.MontoUnitario != null)
            {
                consulta = consulta.Where(x => x.Monto == this.MontoUnitario);
            }
            if (this.IdArticuloMedida != null)
            {
                consulta = consulta.Where(x => x.IdArticuloMedida == this.IdArticuloMedida);
            }
            if (this.Cantidad != null)
            {
                consulta = consulta.Where(x => x.Cantidad == this.Cantidad);
            }

            return consulta;
        }

    }
}
