using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    class ArbolAVL
    {
        protected NodoAvl raiz;
        public int contadorNodosRecorridos { get; set; }

        public ArbolAVL()
        {
            raiz = null;
        }

        public NodoAvl raizArbol()
        {
            return raiz;
        }
       
        private NodoAvl rotacionII(NodoAvl n, NodoAvl n1)
        {
            n.ramaIzdo(n1.subarbolDcho());
            n1.ramaDcho(n);

            if (n1.fe == -1)
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = -1;
                n1.fe = 1;
            }
            return n1;
        }

        private NodoAvl rotacionDD(NodoAvl n, NodoAvl n1)
        {
            n.ramaDcho(n1.subarbolIzdo());
            n1.ramaIzdo(n);

            if (n1.fe == +1)
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = +1;
                n1.fe = -1;
            }
            return n1;
        }

        private NodoAvl rotacionID(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.subarbolDcho();
            n.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n);
            n1.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n1);

            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;
            if (n2.fe == -1)
                n1.fe = 1;
            else
                n.fe = 0;
            n2.fe = 0;               
            return n2;
        }

        private NodoAvl rotacionDI(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.subarbolIzdo();
            n.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n);
            n1.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n1);

            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;
            if (n2.fe == -1)
                n1.fe = 1;
            else
                n.fe = 0;
            n2.fe = 0;
            return n2;
        }

        public void insertar(Object valor)
        {
            Comparador dato;
            Logical h = new Logical(false);
            dato = (Comparador)valor;
            raiz = insertarAvl(raiz, dato, h);
        }

        private NodoAvl insertarAvl(NodoAvl raiz, Comparador dato, Logical h)
        {
            NodoAvl n1;
            if(raiz == null)
            {
                raiz = new NodoAvl(dato);
                h.setLogical(true);
            }
            else if (dato.menorQueId(raiz.valorNodo()))
            {
                NodoAvl iz;
                iz = insertarAvl((NodoAvl)raiz.subarbolIzdo(), dato, h);
                raiz.ramaIzdo(iz);
                if (h.booleanValue())
                {
                    switch (raiz.fe)
                    {
                        case 1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                        case 0:
                            raiz.fe = -1;
                            break;
                        case -1:
                            n1 = (NodoAvl)raiz.subarbolIzdo();
                            if (n1.fe == -1)
                                raiz = rotacionII(raiz, n1);
                            else
                                raiz = rotacionID(raiz, n1);
                            h.setLogical(false);
                            break;                        
                    }
                }
            }
            else if (dato.mayorQueId(raiz.valorNodo()))
            {
                NodoAvl dr;
                dr = insertarAvl((NodoAvl)raiz.subarbolDcho(), dato, h);
                raiz.ramaDcho(dr);
                if (h.booleanValue())
                {
                    switch (raiz.fe)
                    {
                        case 1:
                            n1 = (NodoAvl)raiz.subarbolDcho();
                            if (n1.fe == +1)
                                raiz = rotacionDD(raiz, n1);
                            else
                                raiz = rotacionDI(raiz, n1);
                            h.setLogical(false);                            
                            break;
                        case 0:
                            raiz.fe = +1;
                            break;
                        case -1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                    }
                }

            }
            else throw new Exception("Nodo Duplicado");
            return raiz;
        }

        private NodoAvl reemplazar(NodoAvl n, NodoAvl act, Logical cambiaAltura)
        {
            if (act.subarbolDcho() != null)
            {
                NodoAvl d;
                d = reemplazar(n, (NodoAvl)act.subarbolDcho(), cambiaAltura);
                act.ramaDcho(d);
                if (cambiaAltura.booleanValue())
                    act = equilibrar2(act, cambiaAltura);
            }
            else
            {
                n.nuevoValor(act.valorNodo());
                n = act;
                act = (NodoAvl)act.subarbolIzdo();
                n = null;
                cambiaAltura.setLogical(true);
            }
            return act;
        }

        private NodoAvl equilibrar1(NodoAvl n, Logical cambiaAltura)
        {
            NodoAvl n1;
            switch (n.fe)
            {
                case +1:
                    n1 = (NodoAvl)n.subarbolDcho();
                    if (n1.fe >= 0)
                    {
                        if (n1.fe == 0)
                            cambiaAltura.setLogical(false);
                        n = rotacionDD(n, n1);
                    }
                    else
                        n = rotacionDI(n, n1);
                    break;
                case 0:
                    n.fe = 1;
                    cambiaAltura.setLogical(false);
                    break;
                case -1:
                    n.fe = 0;
                    break;
                
            }
            return n;
        }

        private NodoAvl equilibrar2(NodoAvl n, Logical cambiaAltura)
        {
            NodoAvl n1;
            switch (n.fe)
            {
                case +1:
                    n.fe = 0;
                    break;
                case 0:
                    n.fe = -1;
                    cambiaAltura.setLogical(false);
                    break;
                case -1:
                    n1 = (NodoAvl)n.subarbolIzdo();
                    if (n1.fe<=0)
                    {
                        if (n1.fe == 0)
                            cambiaAltura.setLogical(false);
                        n = rotacionII(n, n1);
                    }
                    else
                        n = rotacionID(n, n1);
                    break;
               
            }
            return n;
        }

        bool esVacio()
        {
            return raiz == null;
        }

        public static NodoAvl nuevoArbol(NodoAvl ramaIzqda, Object dato, NodoAvl ramaDrcha)
        {
            return new NodoAvl(dato, ramaIzqda, ramaDrcha);
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
                return inOrden(r.subarbolIzdo()) + r.visitar() + inOrden(r.subarbolDcho());
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

        public Nodo buscar(Object buscado)
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
            {
                contadorNodosRecorridos++;
                return raizSub;
            }
            else if (buscado.menorQue(raizSub.valorNodo()))
            {
                contadorNodosRecorridos++;
                return buscar(raizSub.subarbolIzdo(), buscado);
            }
            else
            {
                contadorNodosRecorridos++;
                return buscar(raizSub.subarbolDcho(), buscado);
            }
        }
    }
}

