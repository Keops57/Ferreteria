using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria
{
    internal static class Helpers
    {
        public static void Borde(int x, int y, int b, int h)
        {
            int j;
            for (int i = 0; i <= b; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("╔");
                    for (j = 1; j <= h; j++)
                    {
                        Console.SetCursorPosition(x, y + j);
                        Console.Write("║");
                    }
                    Console.SetCursorPosition(x++, y + j);
                    Console.Write("╚");
                }
                else if (i == b)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("╗");
                    for (j = 1; j <= h; j++)
                    {
                        Console.SetCursorPosition(x, y + j);
                        Console.Write("║");
                    }
                    Console.SetCursorPosition(x++, y + j);
                    Console.Write("╝");
                }
                else
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("═");
                    Console.SetCursorPosition(x++, y + h + 1);
                    Console.Write("═");
                }

            }
        }
        public static void InterfazP()
        {
            int x = 11, y = 10;
            Console.Clear();
            Borde(10, 9, 103, 18);
            Console.SetCursorPosition(x, y++); Console.Write("Bienvenido al menu de opciones, ¿Qué quiere hacer?");
            Console.SetCursorPosition(x, y++); Console.Write("<1> Agregar un Producto al Inventario");
            Console.SetCursorPosition(x, y++); Console.Write("<2> Salir");
            Console.SetCursorPosition(x, y++); Console.Write("Ingrese su opcion: ");
        }
        public static void SubInterfaz()
        {
            int x = 11, y = 10;
            Console.Clear();
            Borde(10, 9, 103, 18);
            Console.SetCursorPosition(x, y++); Console.Write("Opciones: ");
            Console.SetCursorPosition(x, y++); Console.Write("<1> Npi");
            Console.SetCursorPosition(x, y++); Console.Write("<2> Salir");
            Console.SetCursorPosition(x, ++y); Console.Write("Ingrese su eleccion: ");
        }

    }
}
