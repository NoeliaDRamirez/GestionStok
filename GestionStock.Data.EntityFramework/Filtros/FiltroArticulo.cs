using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroArticulo : FiltroBase<Articulo>
    {
        public int? IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo
        {
            get; set;
        }

        public override IQueryable<Articulo> AplicarOrdenamiento(IQueryable<Articulo> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(Articulo.Codigo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Codigo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Codigo);
                        }

                        break;
                    case nameof(Articulo.Nombre):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Nombre);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Nombre);
                        }
                        break;
                    /*case nameof(Articulo.Descripcion):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Descripcion);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Descripcion);
                        }
                        break;*/
                    case nameof(Articulo.Activo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Activo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Activo);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdArticulo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdArticulo);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdArticulo);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdArticulo);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public  override  IQueryable<Articulo> AplicarFiltro(IQueryable<Articulo> consulta)
        {
            if (this.IdArticulo != null)
            {
                consulta = consulta.Where(x => x.IdArticulo == this.IdArticulo);
            }
            if (this.Nombre != null)
            {
                consulta = consulta.Where(x => x.Nombre.Contains(this.Nombre));
            }
            if (this.Codigo != null)
            {
                consulta = consulta.Where(x => x.Codigo == this.Codigo);
            }
            if (this.Descripcion != null)
            {
                consulta = consulta.Where(x => x.Descripcion.Contains(this.Descripcion));
            }
            if (this.Activo != null)
            {
                consulta = consulta.Where(x => x.Activo == this.Activo);
            }

            return consulta;
        }

    }
}
