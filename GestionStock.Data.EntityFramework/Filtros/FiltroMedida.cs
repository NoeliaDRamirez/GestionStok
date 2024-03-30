using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroMedida : FiltroBase<Medida>
    {
        public int? IdMedida { get; set; }
        public int? IdTipoMedida { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool? Activo
        {
            get; set;
        }

        public override IQueryable<Medida> AplicarOrdenamiento(IQueryable<Medida> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(Medida.IdTipoMedida):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdTipoMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdTipoMedida);
                        }

                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdMedida);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdMedida);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdMedida);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdMedida);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<Medida> AplicarFiltro(IQueryable<Medida> consulta)
        {
            if (this.IdMedida != null)
            {
                consulta = consulta.Where(x => x.IdMedida == this.IdMedida);
            }
            if (this.IdTipoMedida != null)
            {
                consulta = consulta.Where(x => x.IdTipoMedida == this.IdTipoMedida);
            }
            return consulta;
        }

    }
}
