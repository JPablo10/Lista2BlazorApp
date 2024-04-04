// ListaEnlazaSimple.cs
using Lista2BlazorApp.Models;
using System.Collections;

namespace Lista2BlazorApp.Services
{
    public class ListaEnlazadaSimple : IEnumerable
    {
        public Nodo PrimerNodo { get; set; }
        public Nodo UltimoNodo { get; set; }

        public ListaEnlazadaSimple()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        public bool ListaVacia()
        {
            return PrimerNodo == null;
        }

        public string InsertarNodo(Nodo nuevoNodo)
        {
            if (PrimerNodo == null)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Liga = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Nodo Insertado!!!";
        }

        public string EliminarNodoAlInicio()
        {
            if (ListaVacia()) return "La lista está vacía, no puede continuar!!!";

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo NodoTemporal;
                NodoTemporal = PrimerNodo;

                //Ligar El Segundo Como Primer Nodo
                PrimerNodo = PrimerNodo.Liga;
                NodoTemporal = null;
            }
            return "Nodo Eliminado!!!";
        }

        public string EliminarNodoAlFinal()
        {
            if (ListaVacia()) return "La lista está vacía, no puede continuar!!!";

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo NodoActual;
                Nodo NodoSiguiente;

                NodoActual = PrimerNodo;
                NodoSiguiente = NodoActual.Liga;

                while (NodoSiguiente.Liga != null)
                {
                    NodoActual = NodoActual.Liga;
                    NodoSiguiente = NodoActual.Liga;
                }
                NodoSiguiente = null;
                NodoActual.Liga = null;
                UltimoNodo = NodoActual;
            }
            return "Nodo Eliminado!!!";
        }

        public string EliminarElementoX(object valorReferencia)
        {
            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;

            while (nodoActual != null && !nodoActual.Valor.Equals(valorReferencia))
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Liga;
            }

            if (nodoActual != null)
            {
                if (nodoActual == PrimerNodo)
                {
                    // El nodo con información X es el primer nodo de la lista
                    EliminarNodoAlInicio();
                }
                else
                {
                    // El nodo con información X no es el primer nodo de la lista
                    nodoAnterior.Liga = nodoActual.Liga;
                    nodoActual = null;
                }
                return $"Elemento con información '{valorReferencia}' eliminado!!!";
            }
            else
            {
                return $"El elemento con información '{valorReferencia}' no fue encontrado en la lista!!!";
            }
        }

        public string EliminarNodoAntesDeX(object valorReferencia)
        {
            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;
            Nodo nodoAnterior2 = null;

            while (nodoActual != null && !nodoActual.Valor.Equals(valorReferencia))
            {
                nodoAnterior2 = nodoAnterior;
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Liga;
            }

            if (nodoActual != null)
            {
                if (nodoAnterior == null)
                {
                    return $"No hay nodos para eliminar antes del dato de referencia.";
                }
                else if (nodoAnterior == PrimerNodo)
                {
                    PrimerNodo = nodoActual;
                }
                else
                {
                    nodoAnterior2.Liga = nodoActual;
                }
                return $"Nodo antes del dato de referencia eliminado!!!";
            }
            else
            {
                return $"El valor de referencia no fue encontrado!!!";
            }
        }

        public string EliminarNodoDespuesDeX(object valorReferencia)
        {
            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null && !nodoActual.Valor.Equals(valorReferencia))
            {
                nodoActual = nodoActual.Liga;
            }

            if (nodoActual != null && nodoActual.Liga != null)
            {
                Nodo nodoSiguiente = nodoActual.Liga;
                nodoActual.Liga = nodoSiguiente.Liga;
                nodoSiguiente = null;
                return $"Nodo después del dato de referencia eliminado!!!";
            }
            else
            {
                return $"El valor de referencia no fue encontrado o no hay nodos después de este!!!";
            }
        }


        public void Ordenar()
        {
            if (PrimerNodo == null || PrimerNodo.Liga == null)
                return;
            Nodo actual = PrimerNodo.Liga;
            Nodo previo = PrimerNodo;
            while (actual != null)
            {
                Nodo siguiente = actual.Liga;
                Nodo comparador = PrimerNodo;
                Nodo anteriorComparador = null;
                while (comparador != actual)
                {
                    if ((int)comparador.Valor > (int)actual.Valor)
                    {
                        previo.Liga = siguiente;
                        actual.Liga = comparador;
                        if (anteriorComparador == null)
                            PrimerNodo = actual;
                        else
                            anteriorComparador.Liga = actual;
                        break;
                    }
                    anteriorComparador = comparador;
                    comparador = comparador.Liga;
                }
                if (comparador == actual)
                    previo = actual;
                actual = siguiente;
            }
        }

        public IEnumerator GetEnumerator()
        {
            Nodo nodoAuxiliar = PrimerNodo;

            while (nodoAuxiliar != null)
            {
                yield return nodoAuxiliar;
                nodoAuxiliar = nodoAuxiliar.Liga;
            }
        }
    }
}
