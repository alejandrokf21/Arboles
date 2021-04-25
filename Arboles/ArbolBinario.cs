using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    class ArbolBinario
    {
        protected Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public ArbolBinario(Nodo raiz)
        {
            this.raiz = raiz;
        }

        public Nodo raizArbol()
        {
            return raiz;
        }

        bool esVacio()
        {
            return raiz == null;
        }

        public static Nodo nuevoArbol(Nodo ramaIzq, Object dato, Nodo ramaDer)
        {
            return new Nodo(ramaIzq, dato, ramaDer);
        }

        //Recorrido arbol binario en preorden
        public static string preOrden(Nodo r)
        {
            if (r != null)
            {
                return r.visitar() + preOrden(r.subarbolIzdo()) + preOrden(r.subarbolDcho());
            }
            return "";
        }

        //Recorrido arbol binario en inorden
        public static string inOrden(Nodo r)
        {
            if (r != null)
            {
                return  inOrden(r.subarbolIzdo()) + r.visitar() + inOrden(r.subarbolDcho());
            }
            return "";
        }

        //Recorrido arbol binario en postorden
        public static string postOrden(Nodo r)
        {
            if (r != null)
            {
                return postOrden(r.subarbolIzdo()) + postOrden(r.subarbolDcho()) + r.visitar();
            }
            return "";
        }

        //Devuelve el numero de Nodos que tiene el arbol
        public static int numNodos(Nodo raiz)
        {
            if (raiz == null)
                return 0;
            else
                return 1 + numNodos(raiz.subarbolIzdo()) + numNodos(raiz.subarbolDcho());            
        }

    }
}
