using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroProveedor : FiltroBase<Proveedor>
    {
        public int? IdProveedor { get; set; }
        public string Codigo { get; set; }

        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool? Activo
        {
            get; set;
        }
        public int PlazoEstimadoDeEntrega { get; set; }
        public override IQueryable<Proveedor> AplicarOrdenamiento(IQueryable<Proveedor> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(Proveedor.Codigo):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Codigo);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Codigo);
                        }

                        break;
                    case nameof(Proveedor.Nombre):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Nombre);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Nombre);
                        }
                        break;
                    case nameof(Proveedor.Activo):
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
                            consulta = consulta.OrderByDescending(x => x.IdProveedor);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdProveedor);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdProveedor);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdProveedor);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<Proveedor> AplicarFiltro(IQueryable<Proveedor> consulta)
        {
            if (this.IdProveedor != null)
            {
                consulta = consulta.Where(x => x.IdProveedor == this.IdProveedor);
            }
            if (this.Nombre != null)
            {
                consulta = consulta.Where(x => x.Nombre.Contains(this.Nombre));
            }
            if (this.Codigo != null)
            {
                consulta = consulta.Where(x => x.Codigo == this.Codigo);
            }
            if (this.Email != null)
            {
                consulta = consulta.Where(x => x.Email.Contains(this.Email));
            }
            if (this.Activo != null)
            {
                consulta = consulta.Where(x => x.Activo == this.Activo);
            }

            return consulta;
        }

    }
}
