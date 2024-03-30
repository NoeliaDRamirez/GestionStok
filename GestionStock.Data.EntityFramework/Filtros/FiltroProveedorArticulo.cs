using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroProveedorArticulo : FiltroBase<ProveedorArticulo>
    {
        public int? IdProveedorArticulo { get; set; }
        public int? IdArticuloMedida { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdForma{ get; set; }
        public decimal? Precio{ get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateTime? FechaPedido { get; set; }
        public int? PlazoPactado { get; set; }
        public bool? Entregado { get; set; }
        public int? Cantidad{ get; set; }

        public override IQueryable<ProveedorArticulo> AplicarOrdenamiento(IQueryable<ProveedorArticulo> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(ProveedorArticulo.IdArticuloMedida):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticuloMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticuloMedida);
                        }

                        break;
                    case nameof(ProveedorArticulo.IdProveedor):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdProveedor);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdProveedor);
                        }
                        break;
                    case nameof(ProveedorArticulo.IdForma):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdForma);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdForma);
                        }
                        break;
                    case nameof(ProveedorArticulo.Precio):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Precio);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Precio);
                        }
                        break;
                    case nameof(ProveedorArticulo.Cantidad):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Cantidad);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Cantidad);
                        }
                        break;
                    case nameof(ProveedorArticulo.FechaCompra):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.FechaCompra);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.FechaCompra);
                        }
                        break;
                    case nameof(ProveedorArticulo.FechaPedido):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.FechaPedido);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.FechaPedido);
                        }
                        break;
                    case nameof(ProveedorArticulo.Entregado):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Entregado);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Entregado);
                        }
                        break;
                    case nameof(ProveedorArticulo.PlazoPactado):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.PlazoPactado);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.PlazoPactado);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdProveedorArticulo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdProveedorArticulo);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdProveedorArticulo);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdProveedorArticulo);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<ProveedorArticulo> AplicarFiltro(IQueryable<ProveedorArticulo> consulta)
        {
            if (this.IdProveedorArticulo != null)
            {
                consulta = consulta.Where(x => x.IdProveedorArticulo == this.IdProveedorArticulo);
            }
            if (this.IdArticuloMedida != null)
            {
                consulta = consulta.Where(x => x.IdArticuloMedida == this.IdArticuloMedida);
            }
            if (this.IdProveedor != null)
            {
                consulta = consulta.Where(x => x.IdProveedor == this.IdProveedor);
            }
            if (this.IdForma != null)
            {
                consulta = consulta.Where(x => x.IdForma == this.IdForma);
            }
            if (this.Precio!= null)
            {
                consulta = consulta.Where(x => x.Precio == this.Precio);
            }
            if (this.Cantidad != null)
            {
                consulta = consulta.Where(x => x.Cantidad == this.Cantidad);
            }
            if (this.FechaCompra != DateTime.MinValue)
            {
                consulta = consulta.Where(x => x.FechaCompra == this.FechaCompra);
            }
            if (this.FechaPedido != DateTime.MinValue)
            {
                consulta = consulta.Where(x => x.FechaPedido == this.FechaPedido);
            }
            if (this.Entregado != null)
            {
                consulta = consulta.Where(x => x.Entregado == this.Entregado);
            }
            if (this.PlazoPactado != null)
            {
                consulta = consulta.Where(x => x.PlazoPactado == this.PlazoPactado);
            }

            return consulta;
        }

    }
}
