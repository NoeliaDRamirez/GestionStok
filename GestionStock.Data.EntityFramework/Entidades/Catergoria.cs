using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public partial class CatergoriaIdentificador : IIdentificable<Catergoria>
    {
        public bool ComprarIdentificador(Catergoria entidad, object identificador)
        {
            return entidad.IdCategoria == (int)identificador;
        }

        public void Copiar(Catergoria origen, Catergoria destino)
        {
            if (destino != null && origen  != null)
            {
                destino.Activo = origen.Activo;
                destino.Codigo = origen.Codigo;                
                destino.IdCategoria = origen.IdCategoria;
                destino.Nombre = origen.Nombre;
            }
        }

        public IQueryable<Catergoria> FiltarPorentidad(IQueryable<Catergoria> query, Catergoria Entidad)
        {
            return query.Where(x=> x.IdCategoria == Entidad.IdCategoria);
        }

        public IQueryable<Catergoria> FiltrarPorCodigo(IQueryable<Catergoria> query, object Codigo)
        {
            return query.Where(x => x.Codigo == (Codigo as string));
        }

        public IQueryable<Catergoria> FiltrarPorIdentificador(IQueryable<Catergoria> query, object identificador)
        {
            return query.Where(x => x.IdCategoria == (int)identificador);
        }
    }
}
