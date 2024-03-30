using GestionStock.Data.EntityFramework.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data.EntityFramework
{
    public class Repositorio<TEntidad> where TEntidad : class
    {
        private readonly IIdentificable<TEntidad> _identificador;
        public Repositorio(IIdentificable<TEntidad> identificador)
        {
            _identificador = identificador;
        }
        public List<TEntidad> Listar(FiltroBase<TEntidad> filtro, out int totalElemntos)
        {
            using (GestionStock2022Entities contexto = new GestionStock2022Entities())
            {
                var tabla = contexto.Set<TEntidad>();//devuelve una referencia a la tabla de la entidad
                var consulta = filtro.AplicarFiltro(tabla);
                totalElemntos = consulta.Count();
                consulta = filtro.AplicarOrdenamiento(consulta);
                return consulta.ToList();
            }
        }

        public TEntidad ObtenerPorCodigo(string Codigo)
        {
            TEntidad resultado = null;
            using (GestionStock2022Entities contexto = new GestionStock2022Entities())
            {
                resultado = _identificador.FiltrarPorCodigo(contexto.Set<TEntidad>(), Codigo).FirstOrDefault();
            };
            return resultado;
        }

        public TEntidad ObtenerPorId(int IdTEntidad)
        {
            TEntidad resultado = null;
            using (GestionStock2022Entities contexto = new GestionStock2022Entities())
            {
                resultado = _identificador.FiltrarPorIdentificador(contexto.Set<TEntidad>(), IdTEntidad).FirstOrDefault();
            };
            return resultado;
        }

        public void Guardar(TEntidad art)
        {
            if (_identificador.ComprarIdentificador(art, 0))
            {
                Agregar(art);
            }
            else
            {
                Actualizar(art);
            }
        }

        public void Agregar(TEntidad art)
        {
            using (GestionStock2022Entities contexto = new GestionStock2022Entities())
            {
                contexto.Set<TEntidad>().Add(art);
                contexto.SaveChanges();
            };
        }

        public bool Actualizar(TEntidad art)
        {
            using (GestionStock2022Entities contexto = new GestionStock2022Entities())
            {
                var resultado = _identificador.FiltarPorentidad(contexto.Set<TEntidad>(), art).FirstOrDefault();
                if (resultado != null)
                {
                    _identificador.Copiar(art, resultado);
                    contexto.Entry(resultado).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                    return true;
                }
            };
            return false;
        }
        public bool Eliminar(TEntidad art)
        {
            using (GestionStock2022Entities contexto = new GestionStock2022Entities())
            {
                var resultado = _identificador.FiltarPorentidad(contexto.Set<TEntidad>(), art).FirstOrDefault();
                if (resultado != null)
                {
                    //contexto.Entry(resultado).State = System.Data.Entity.EntityState.Deleted;
                    contexto.Set<TEntidad>().Remove(resultado);
                    contexto.SaveChanges();
                    return true;
                }
            };
            return false;
        }


        public bool Eliminar(FiltroBase<TEntidad> art)
        {
            using (GestionStock2022Entities contexto = new GestionStock2022Entities())
            {
                var consulta = art.AplicarFiltro(contexto.Set<TEntidad>());
                var cantidad = consulta.Count();
                contexto.Set<TEntidad>().RemoveRange(consulta);
                contexto.SaveChanges();
                return cantidad > 0;
            }
        }
    }
}
