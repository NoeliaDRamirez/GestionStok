using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroArticuloMedidaPosicion : FiltroBase<ArticuloMedidaPosicion>
    {
        public int? IdArticuloMedidaPosicion { get; set; }
        public int? IdArticuloMedida { get; set; }
        public int? IdPosicion { get; set; }

        public override IQueryable<ArticuloMedidaPosicion> AplicarOrdenamiento(IQueryable<ArticuloMedidaPosicion> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(ArticuloMedidaPosicion.IdArticuloMedida):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticuloMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticuloMedida);
                        }

                        break;
                    case nameof(ArticuloMedidaPosicion.IdPosicion):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdPosicion);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdPosicion);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticuloMedidaPosicion);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticuloMedidaPosicion);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdArticuloMedidaPosicion);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdArticuloMedidaPosicion);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<ArticuloMedidaPosicion> AplicarFiltro(IQueryable<ArticuloMedidaPosicion> consulta)
        {
            if (this.IdArticuloMedidaPosicion != null)
            {
                consulta = consulta.Where(x => x.IdArticuloMedidaPosicion == this.IdArticuloMedidaPosicion);
            }
            if (this.IdArticuloMedida != null)
            {
                consulta = consulta.Where(x => x.IdArticuloMedida == this.IdArticuloMedida);
            }
            if (this.IdPosicion != null)
            {
                consulta = consulta.Where(x => x.IdPosicion == this.IdPosicion);
            }
            return consulta;
        }

    }
}
