using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroPosicion : FiltroBase<Posicion>
    {
        public int? IdPosicion { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool? Activo
        {
            get; set;
        }
        public override IQueryable<Posicion> AplicarOrdenamiento(IQueryable<Posicion> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(Posicion.Codigo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Codigo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Codigo);
                        }

                        break;
                    case nameof(Posicion.Nombre):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Nombre);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Nombre);
                        }
                        break;
                    
                    case nameof(Posicion.Activo):
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
                            consulta = consulta.OrderByDescending(x => x.IdPosicion);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdPosicion);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdPosicion);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdPosicion);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<Posicion> AplicarFiltro(IQueryable<Posicion> consulta)
        {
            if (this.IdPosicion != null)
            {
                consulta = consulta.Where(x => x.IdPosicion == this.IdPosicion);
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
