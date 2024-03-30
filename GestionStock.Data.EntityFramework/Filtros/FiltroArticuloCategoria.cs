using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroArticuloCategoria : FiltroBase<ArticuloCategoria>
    {
        public int? IdArticuloCategoria { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdCategoria { get; set; }

        public override IQueryable<ArticuloCategoria> AplicarOrdenamiento(IQueryable<ArticuloCategoria> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(ArticuloCategoria.IdArticulo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticulo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticulo);
                        }

                        break;
                    case nameof(ArticuloCategoria.IdCategoria):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdCategoria);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdCategoria);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticuloCategoria);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticuloCategoria);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdArticuloCategoria);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdArticuloCategoria);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public  override  IQueryable<ArticuloCategoria> AplicarFiltro(IQueryable<ArticuloCategoria> consulta)
        {
            if (this.IdArticuloCategoria != null)
            {
                consulta = consulta.Where(x => x.IdArticuloCategoria == this.IdArticuloCategoria);
            }
            if (this.IdArticulo != null)
            {
                consulta = consulta.Where(x => x.IdArticulo == this.IdArticulo);
            }
            if (this.IdCategoria != null)
            {
                consulta = consulta.Where(x => x.IdCategoria == this.IdCategoria);
            }
            return consulta;
        }

    }
}
