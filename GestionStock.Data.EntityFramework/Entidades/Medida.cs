using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework.Entidades
{
    public partial class MedidaIdentificador : IIdentificable<Medida>
    {
        public bool ComprarIdentificador(Medida entidad, object identificador)
        {
            return entidad.IdMedida == (int)identificador;
        }

        public void Copiar(Medida origen, Medida destino)
        {
            if (destino != null && origen != null)
            {
                destino.IdMedida = origen.IdMedida;
                destino.IdTipoMedida = origen.IdTipoMedida;
                destino.Nombre = origen.Nombre;
                destino.Codigo = origen.Codigo;
                destino.Activo = origen.Activo;            
            }
        }

        public IQueryable<Medida> FiltarPorentidad(IQueryable<Medida> query, Medida Entidad)
        {
            return query.Where(x => x.IdMedida == Entidad.IdMedida);
        }

        public IQueryable<Medida> FiltrarPorCodigo(IQueryable<Medida> query, object Codigo)
        {
            return query;
        }

        public IQueryable<Medida> FiltrarPorIdentificador(IQueryable<Medida> query, object identificador)
        {
            return query.Where(x => x.IdMedida == (int)identificador);
        }
    }
}
