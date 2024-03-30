using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data
{
    public interface IIdentificable<TEntidad>
    {
        IQueryable<TEntidad> FiltrarPorCodigo(IQueryable<TEntidad> query, object Codigo);
        IQueryable<TEntidad> FiltarPorentidad(IQueryable<TEntidad> query, TEntidad Entidad);
        IQueryable<TEntidad> FiltrarPorIdentificador(IQueryable<TEntidad> query, object identificador);
        void Copiar(TEntidad origen, TEntidad destino);
        bool ComprarIdentificador(TEntidad entidad, object identificador);

    }
}
