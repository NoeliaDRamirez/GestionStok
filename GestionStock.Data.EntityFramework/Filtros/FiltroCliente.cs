using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Filtros
{
    public class FiltroCliente : FiltroBase<Cliente>
    {
        public int? IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Calle { get; set; }
        public int? Numero { get; set; }
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
        public override IQueryable<Cliente> AplicarOrdenamiento(IQueryable<Cliente> consulta)
        {
            if (this.Orden != null)
            {
                switch (this.Orden)
                {
                    case nameof(Cliente.Documento):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Documento);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Documento);
                        }

                        break;
                    case nameof(Cliente.Nombre):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Nombre);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Nombre);
                        }
                        break;
                    case nameof(Cliente.Apellido):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Apellido);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Apellido);
                        }
                        break;
                    case nameof(Cliente.Calle):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Calle);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Calle);
                        }
                        break;
                    case nameof(Cliente.Numero):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Numero);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Numero);
                        }
                        break;
                    case nameof(Cliente.Telefono):
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.Telefono);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.Telefono);
                        }
                        break;
                    default:
                        if (this.Descendente)
                        {
                            consulta = consulta.OrderByDescending(x => x.IdCliente);
                        }
                        else
                        {
                            consulta = consulta.OrderBy(x => x.IdCliente);
                        }
                        break;
                }
            }
            else
            {
                if (this.Descendente)
                {
                    consulta = consulta.OrderByDescending(x => x.IdCliente);
                }
                else
                {
                    consulta = consulta.OrderBy(x => x.IdCliente);
                }
            }
            if (this.TamanioPagina > 0)
            {
                consulta = consulta.Skip(this.NumeroPagina * this.TamanioPagina).Take(this.TamanioPagina);
            }

            return consulta;
        }

        public override IQueryable<Cliente> AplicarFiltro(IQueryable<Cliente> consulta)
        {
            if (this.IdCliente != null)
            {
                consulta = consulta.Where(x => x.IdCliente == this.IdCliente);
            }
            if (this.Nombre != null)
            {
                consulta = consulta.Where(x => x.Nombre.Contains(this.Nombre));
            }
            if (this.Documento != null)
            {
                consulta = consulta.Where(x => x.Documento == this.Documento);
            }
            if (this.Apellido != null)
            {
                consulta = consulta.Where(x => x.Apellido.Contains(this.Apellido));
            }
            if (this.Numero != null)
            {
                consulta = consulta.Where(x => x.Numero == this.Numero);
            }

            if (this.Observaciones != null)
            {
                consulta = consulta.Where(x => x.Observaciones.Contains(this.Observaciones));
            }
            if (this.Calle != null)
            {
                consulta = consulta.Where(x => x.Observaciones.Contains(this.Calle));
            }
            return consulta;
        }
    }
}
