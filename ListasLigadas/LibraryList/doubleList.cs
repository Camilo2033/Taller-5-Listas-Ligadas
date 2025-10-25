using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryList
{
    public class DoubleList<T> where T : IComparable<T>
    {
        private Nodo<T> cabeza;
        private Nodo<T> cola;

        public void Adicionar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (cabeza == null)
            {
                cabeza = cola = nuevo;
                return;
            }

            Nodo<T> actual = cabeza;
            Nodo<T> anterior = null;

            while (actual != null && actual.Dato.CompareTo(dato) < 0)
            {
                anterior = actual;
                actual = actual.Siguiente;
            }

            if (anterior == null) // insertar al inicio
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
            else if (actual == null) // insertar al final
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
            else // insertar en medio
            {
                nuevo.Siguiente = actual;
                nuevo.Anterior = anterior;
                anterior.Siguiente = nuevo;
                actual.Anterior = nuevo;
            }
        }

        public void MostrarAdelante()
        {
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }

        public void MostrarAtras()
        {
            Nodo<T> actual = cola;
            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Anterior;
            }
            Console.WriteLine();
        }

        public void OrdenarDescendente()
        {
            if (cabeza == null) return;

            List<T> elementos = new List<T>();
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                elementos.Add(actual.Dato);
                actual = actual.Siguiente;
            }

            elementos.Sort();
            elementos.Reverse();

            cabeza = cola = null;
            foreach (var e in elementos)
                Adicionar(e);
        }

        public void MostrarModas()
        {
            List<T> elementos = new List<T>();
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                elementos.Add(actual.Dato);
                actual = actual.Siguiente;
            }

            var grupos = elementos.GroupBy(x => x)
                                  .Select(g => new { Valor = g.Key, Frecuencia = g.Count() })
                                  .ToList();

            int max = grupos.Max(g => g.Frecuencia);
            var modas = grupos.Where(g => g.Frecuencia == max).Select(g => g.Valor);

            Console.WriteLine("Moda(s): " + string.Join(", ", modas));
        }

        public bool Existe(T dato)
        {
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.CompareTo(dato) == 0)
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        public void EliminarUna(T dato)
        {
            Nodo<T> actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato.CompareTo(dato) == 0)
                {
                    if (actual.Anterior != null)
                        actual.Anterior.Siguiente = actual.Siguiente;
                    else
                        cabeza = actual.Siguiente;

                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;
                    else
                        cola = actual.Anterior;

                    return;
                }
                actual = actual.Siguiente;
            }
        }

        public void EliminarTodas(T dato)
        {
            while (Existe(dato))
                EliminarUna(dato);
        }

        public void MostrarGrafico()
        {
            List<T> elementos = new List<T>();
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                elementos.Add(actual.Dato);
                actual = actual.Siguiente;
            }

            var grupos = elementos.GroupBy(x => x)
                                  .Select(g => new { Valor = g.Key, Frecuencia = g.Count() })
                                  .OrderBy(g => g.Valor);

            foreach (var g in grupos)
            {
                Console.Write($"{g.Valor} ");
                for (int i = 0; i < g.Frecuencia; i++) Console.Write("*");
                Console.WriteLine();
            }
        }
    }
}
