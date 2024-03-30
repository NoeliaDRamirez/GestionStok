using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroArticuloMedida : FiltroBase<ArticuloMedida>
    {
        public int? IdArticuloMedida { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdMedida { get; set; }

        public int? CantidaMinima { get; set; }
        public override IQueryable<ArticuloMedida> AplicarOrdenamiento(IQueryable<ArticuloMedida> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(ArticuloMedida.IdArticulo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticulo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticulo);
                        }

                        break;
                    case nameof(ArticuloMedida.IdMedida):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdMedida);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticuloMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticuloMedida);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdArticuloMedida);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdArticuloMedida);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<ArticuloMedida> AplicarFiltro(IQueryable<ArticuloMedida> consulta)
        {
            if (this.IdArticuloMedida != null)
            {
                consulta = consulta.Where(x => x.IdArticuloMedida == this.IdArticuloMedida);
            }
            if (this.IdArticulo != null)
            {
                consulta = consulta.Where(x => x.IdArticulo == this.IdArticulo);
            }
            if (this.IdMedida != null)
            {
                consulta = consulta.Where(x => x.IdMedida == this.IdMedida);
            }
            return consulta;
        }

    }
}
