using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    class NodoAvl:Nodo
    {
        public int fe;
        public NodoAvl(Object valor) : base(valor)
        {
            fe = 0;
        }

        public NodoAvl(Object valor, NodoAvl ramaIzda, NodoAvl ramaDcha) : base(ramaIzda, valor, ramaDcha)
        {
            fe = 0; 
        }
    }
}
