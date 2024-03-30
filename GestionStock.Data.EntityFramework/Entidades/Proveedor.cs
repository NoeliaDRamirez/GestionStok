using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Entidades
{
    public partial class ProveedorIdentificador : IIdentificable<Proveedor>
    {
        public bool ComprarIdentificador(Proveedor entidad, object identificador)
        {
            return entidad.IdProveedor == (int)identificador;
        }

        public void Copiar(Proveedor origen, Proveedor destino)
        {
            if (destino != null && origen != null)
            {
                destino.Activo = origen.Activo;
                destino.Codigo = origen.Codigo;
                destino.Email = origen.Email;
                destino.IdProveedor = origen.IdProveedor;
                destino.Nombre = origen.Nombre;
                destino.Telefono = origen.Telefono;
                destino.PlazoEstimadoDeEntrega = origen.PlazoEstimadoDeEntrega;
            }
        }

        public IQueryable<Proveedor> FiltarPorentidad(IQueryable<Proveedor> query, Proveedor Entidad)
        {
            return query.Where(x => x.IdProveedor == Entidad.IdProveedor);
        }

        public IQueryable<Proveedor> FiltrarPorCodigo(IQueryable<Proveedor> query, object Codigo)
        {
            return query.Where(x => x.Codigo == (Codigo as string));
        }

        public IQueryable<Proveedor> FiltrarPorIdentificador(IQueryable<Proveedor> query, object identificador)
        {
            return query.Where(x => x.IdProveedor == (int)identificador);
        }
    }
}
