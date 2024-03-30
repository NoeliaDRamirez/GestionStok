using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroVenta : FiltroBase<Venta>
    {
        public int? IdVenta { get; set; }
        public int? IdCliente { get; set; }
        public DateTime Fecha  { get; set; }
        public decimal? Monto { get; set; }
        public int? IdForma { get; set; }

        public override IQueryable<Venta> AplicarOrdenamiento(IQueryable<Venta> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(Venta.IdCliente):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdCliente);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdCliente);
                        }

                        break;
                    case nameof(Venta.Fecha):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Fecha);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Fecha);
                        }
                        break;
                    
                    case nameof(Venta.Monto):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Monto);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Monto);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdVenta);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdVenta);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdVenta);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdVenta);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<Venta> AplicarFiltro(IQueryable<Venta> consulta)
        {
            if (this.IdVenta != null)
            {
                consulta = consulta.Where(x => x.IdVenta == this.IdVenta);
            }
            if (this.IdCliente != null)
            {
                consulta = consulta.Where(x => x.IdCliente==this.IdCliente);
            }
            if (this.Fecha != DateTime.MinValue)
            {
                consulta = consulta.Where(x => x.Fecha == this.Fecha);
            }
            if (this.Monto != null)
            {
                consulta = consulta.Where(x => x.Monto == this.Monto);
            }
            if (this.IdForma != null)
            {
                consulta = consulta.Where(x => x.IdForma == this.IdForma);
            }

            return consulta;
        }

    }
}
