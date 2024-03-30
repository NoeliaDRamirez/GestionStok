using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroTipoMedida: FiltroBase<TipoMedida>
    {
        public int? IdTipoMedida{ get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        


        public override IQueryable<TipoMedida> AplicarOrdenamiento(IQueryable<TipoMedida> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(TipoMedida.Codigo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Codigo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Codigo);
                        }

                        break;
                    case nameof(TipoMedida.Nombre):
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
                            consulta = consulta.OrderByDescending(x => x.IdTipoMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdTipoMedida);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdTipoMedida);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdTipoMedida);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<TipoMedida> AplicarFiltro(IQueryable<TipoMedida> consulta)
        {
            if (this.IdTipoMedida != null)
            {
                consulta = consulta.Where(x => x.IdTipoMedida == this.IdTipoMedida);
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
