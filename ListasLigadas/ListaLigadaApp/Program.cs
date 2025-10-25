using System;
using LibraryList;

namespace ListaLigadaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleList<string> lista = new DoubleList<string>();
            int opcion;
            do
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar modas");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese un elemento: ");
                        string dato = Console.ReadLine();
                        lista.Adicionar(dato);
                        break;
                    case 2:
                        lista.MostrarAdelante();
                        break;
                    case 3:
                        lista.MostrarAtras();
                        break;
                    case 4:
                        lista.OrdenarDescendente();
                        Console.WriteLine("Lista ordenada descendentemente.");
                        break;
                    case 5:
                        lista.MostrarModas();
                        break;
                    case 6:
                        lista.MostrarGrafico();
                        break;
                    case 7:
                        Console.Write("Ingrese elemento a buscar: ");
                        string buscado = Console.ReadLine();
                        Console.WriteLine(lista.Existe(buscado) ? "Existe" : "No existe");
                        break;
                    case 8:
                        Console.Write("Elemento a eliminar: ");
                        string eliminar = Console.ReadLine();
                        lista.EliminarUna(eliminar);
                        break;
                    case 9:
                        Console.Write("Elemento a eliminar (todas las ocurrencias): ");
                        string eliminarTodas = Console.ReadLine();
                        lista.EliminarTodas(eliminarTodas);
                        break;
                }

            } while (opcion != 0);
        }
    }
}
