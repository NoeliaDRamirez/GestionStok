using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroTipoMovimiento : FiltroBase<TipoMovimiento>
    {
        public int? IdTipoMovimiento { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        
        public override IQueryable<TipoMovimiento> AplicarOrdenamiento(IQueryable<TipoMovimiento> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(TipoMovimiento.Codigo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Codigo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Codigo);
                        }

                        break;
                    case nameof(TipoMovimiento.Nombre):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Nombre);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Nombre);
                        }
                        break;

                    
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdTipoMovimiento);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdTipoMovimiento);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdTipoMovimiento);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdTipoMovimiento);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<TipoMovimiento> AplicarFiltro(IQueryable<TipoMovimiento> consulta)
        {
            if (this.IdTipoMovimiento != null)
            {
                consulta = consulta.Where(x => x.IdTipoMovimiento == this.IdTipoMovimiento);
            }
            if (this.Nombre != null)
            {
                consulta = consulta.Where(x => x.Nombre.Contains(this.Nombre));
            }
            if (this.Codigo != null)
            {
                consulta = consulta.Where(x => x.Codigo == this.Codigo);
            }
            

            return consulta;
        }
    }
    
}
