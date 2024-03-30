using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class ClienteIdentificador : IIdentificable<Cliente>
    {
        public bool ComprarIdentificador(Cliente entidad, object identificador)
        {
            return entidad.IdCliente == (int)identificador;
        }

        public void Copiar(Cliente origen, Cliente destino)
        {
            if (origen != null && destino != null)
            {
                destino.Apellido = origen.Apellido;
                destino.Calle = origen.Calle;
                destino.Documento = origen.Documento;
                destino.IdCliente = origen.IdCliente;
                destino.Nombre = origen.Nombre;
                destino.Numero = origen.Numero;
                destino.Observaciones = origen.Observaciones;
                destino.Telefono = origen.Telefono;
            }
        }

        public IQueryable<Cliente> FiltarPorentidad(IQueryable<Cliente> query, Cliente Entidad)
        {
            return query.Where(x => x.IdCliente == Entidad.IdCliente);
        }

        public IQueryable<Cliente> FiltrarPorCodigo(IQueryable<Cliente> query, object Codigo)
        {
            return query.Where(x => x.Documento == (Codigo as string));
        }

        public IQueryable<Cliente> FiltrarPorIdentificador(IQueryable<Cliente> query, object identificador)
        {
            return query.Where(x => x.IdCliente == (int)identificador);
        }
    }
}
