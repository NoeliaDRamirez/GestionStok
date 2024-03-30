using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroCatergoria : FiltroBase<Catergoria>
    {
        public int? IdCatergoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }        
        public bool? Activo
        {
            get; set;
        }

        public override IQueryable<Catergoria> AplicarOrdenamiento(IQueryable<Catergoria> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(Catergoria.Codigo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Codigo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Codigo);
                        }

                        break;
                    case nameof(Catergoria.Nombre):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Nombre);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Nombre);
                        }
                        break;
                    /*case nameof(Catergoria.Descripcion):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Descripcion);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Descripcion);
                        }
                        break;*/
                    case nameof(Catergoria.Activo):
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
                            consulta = consulta.OrderByDescending(x => x.IdCategoria);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdCategoria);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdCategoria);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdCategoria);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<Catergoria> AplicarFiltro(IQueryable<Catergoria> consulta)
        {
            if (this.IdCatergoria != null)
            {
                consulta = consulta.Where(x => x.IdCategoria == this.IdCatergoria);
            }
            if (this.Nombre != null)
            {
                consulta = consulta.Where(x => x.Nombre.Contains(this.Nombre));
            }
            if (this.Codigo != null)
            {
                consulta = consulta.Where(x => x.Codigo == this.Codigo);
            }
            if (this.Activo != null)
            {
                consulta = consulta.Where(x => x.Activo == this.Activo);
            }

            return consulta;
        }

    }
}
