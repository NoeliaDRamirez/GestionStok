using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroFormaPago : FiltroBase<FormaPago>
    {
        public int? IdForma{ get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaCreacion { get; set; }
        

        public override IQueryable<FormaPago> AplicarOrdenamiento(IQueryable<FormaPago> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(FormaPago.Codigo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Codigo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Codigo);
                        }

                        break;
                    case nameof(FormaPago.Nombre):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Nombre);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Nombre);
                        }
                        break;
                    
                    case nameof(FormaPago.FechaCreacion):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.FechaCreacion);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.FechaCreacion);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdForma);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdForma);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdForma);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdForma);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<FormaPago> AplicarFiltro(IQueryable<FormaPago> consulta)
        {
            if (this.IdForma != null)
            {
                consulta = consulta.Where(x => x.IdForma == this.IdForma);
            }
            if (this.Nombre != null)
            {
                consulta = consulta.Where(x => x.Nombre.Contains(this.Nombre));
            }
            if (this.Codigo != null)
            {
                consulta = consulta.Where(x => x.Codigo == this.Codigo);
            }
            if (this.FechaCreacion != DateTime.MinValue)
            {
                consulta = consulta.Where(x => x.FechaCreacion==this.FechaCreacion);
            }
            

            return consulta;
        }

    }
}

