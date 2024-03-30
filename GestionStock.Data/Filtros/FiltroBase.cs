using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Data
{
    public abstract class FiltroBase
    {
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }
        public string Orden { get; set; }
        public bool Descendente { get; set; }
    }
}
