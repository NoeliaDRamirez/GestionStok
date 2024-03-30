using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class FormaPagoIdentificador : IIdentificable<FormaPago>
    {
        public bool ComprarIdentificador(FormaPago entidad, object identificador)
        {
            return entidad.IdForma == (int)identificador;
        }

        public void Copiar(FormaPago origen, FormaPago destino)
        {
            if (destino != null && origen != null)
            {
                destino.Codigo = origen.Codigo;
                destino.FechaCreacion = origen.FechaCreacion;
                destino.IdForma = origen.IdForma;
                destino.Nombre = origen.Nombre;
            }
        }

        public IQueryable<FormaPago> FiltarPorentidad(IQueryable<FormaPago> query, FormaPago Entidad)
        {
            return query.Where(x => x.IdForma == Entidad.IdForma);
        }

        public IQueryable<FormaPago> FiltrarPorCodigo(IQueryable<FormaPago> query, object Codigo)
        {
            return query.Where(x => x.Codigo == (Codigo as string));
        }

        public IQueryable<FormaPago> FiltrarPorIdentificador(IQueryable<FormaPago> query, object identificador)
        {
            return query.Where(x => x.IdForma == (int)identificador);
        }
    }
}
