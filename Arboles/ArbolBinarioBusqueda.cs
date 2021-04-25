using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    class ArbolBinarioBusqueda:ArbolBinario
    {

        public ArbolBinarioBusqueda():base()
        {
        }

        public ArbolBinarioBusqueda(Nodo nodo):base(nodo)
        {
        }

        public Nodo Buscar(Object buscado)
        {
            Comparador dato;
            dato = (Comparador)buscado;
            if (raiz == null)
                return null;
            else
                return buscar(raizArbol(), dato);
        }

        protected Nodo buscar(Nodo raizSub, Comparador buscado)
        {
            if (raizSub == null)
                return null;
            else if (buscado.igualQue(raizSub.valorNodo()))
                return raizSub;
            else if (buscado.menorQue(raizSub.valorNodo()))
                return buscar(raizSub.subarbolIzdo(), buscado);
            else
                return buscar(raizSub.subarbolDcho(), buscado);
        }

        public Nodo buscarIterativo(Object buscado)
        {
            Comparador dato;
            bool encontrado = false;
            Nodo raizSub = raiz;
            dato = (Comparador)buscado;
            while (!encontrado && raizSub != null)
            {
                if (dato.igualQue(raizSub.valorNodo()))
                    encontrado = true;
                else if (dato.menorQue(raizSub.valorNodo()))
                    raizSub = raizSub.subarbolIzdo();
                else
                    raizSub = raizSub.subarbolDcho();      
            }
            return raizSub;
        }

        public void insertar(Object valor)
        {
            Comparador dato;
            dato = (Comparador)valor;
            raiz = insertar(raiz, dato);
        }

        protected Nodo insertar(Nodo raizSub, Comparador dato)
        {
            if (raizSub == null)
                raizSub = new Nodo(dato);
            else if (dato.menorQueId(raizSub.valorNodo()))
            {
                Nodo iz;
                iz = insertar(raizSub.subarbolIzdo(), dato);
                raizSub.ramaIzdo(iz);
            }
            else if (dato.mayorQueId(raizSub.valorNodo()))
            {
                Nodo de;
                de = insertar(raizSub.subarbolDcho(), dato);
                raizSub.ramaDcho(de);
            }
            else throw new Exception("Nodo Duplicado");
            return raizSub;
        }
    }
}
