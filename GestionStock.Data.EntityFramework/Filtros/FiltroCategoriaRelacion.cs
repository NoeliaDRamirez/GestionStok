using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroCategoriaRelacion : FiltroBase<CategoriaRelacion>
    {
        public int? IdCategoriaRelacion { get; set; }
        public int? IdCategoriaPadre { get; set; }
        public int? IdCategoriaHijo { get; set; }

        public override IQueryable<CategoriaRelacion> AplicarOrdenamiento(IQueryable<CategoriaRelacion> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(CategoriaRelacion.IdCategoriaPadre):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdCategoriaPadre);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdCategoriaPadre);
                        }

                        break;
                    case nameof(CategoriaRelacion.IdCategoriaHijo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdCategoriaHijo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdCategoriaHijo);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdCategoriaRelacion);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdCategoriaRelacion);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdCategoriaRelacion);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdCategoriaRelacion);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<CategoriaRelacion> AplicarFiltro(IQueryable<CategoriaRelacion> consulta)
        {
            if (this.IdCategoriaRelacion != null)
            {
                consulta = consulta.Where(x => x.IdCategoriaRelacion == this.IdCategoriaRelacion);
            }
            if (this.IdCategoriaPadre != null)
            {
                consulta = consulta.Where(x => x.IdCategoriaPadre == this.IdCategoriaPadre);
            }
            if (this.IdCategoriaHijo != null)
            {
                consulta = consulta.Where(x => x.IdCategoriaHijo == this.IdCategoriaHijo);
            }
            return consulta;
        }

    }
}
