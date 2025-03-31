using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ferreteria
{
    internal static class Helpers
    {

        // Expresiones regulares para los formatos de codigos en tanto Productos como Vendedores
        public static readonly Regex regexProducto = new Regex(@"^P\d{3}[A-Za-z]$");  // P + 3 números + 1 letra
        public static readonly Regex regexVendedor = new Regex(@"^V\d{3}[A-Za-z]$"); // V + 3 números + 1 letra
        public static Random rnd = new Random(); // Codigo Random

        #region Validaciones codigos
        public static bool ValidarCodigoVendedor(string codigo)
        {
            return !string.IsNullOrWhiteSpace(codigo) && regexVendedor.IsMatch(codigo);
        }

        public static bool ValidarCodigoProducto(string codigo)
        {
            return !string.IsNullOrWhiteSpace(codigo) && regexProducto.IsMatch(codigo);
        }

        public static string GenerarEjemploVendedor()
        {
            char letra = (char)('A' + rnd.Next(0, 26));
            return $"V{rnd.Next(100, 999)}{letra}";
        }

        public static string GenerarEjemploProducto()
        {
            char letra = (char)('A' + rnd.Next(0, 26));
            return $"P{rnd.Next(100, 999)}{letra}";
        }

        #endregion

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

            Titulos.MostrarTituloMenuSimple();

            Borde(10, 9, 103, 18);
            Console.SetCursorPosition(x, y++); Console.Write("Bienvenido al menu de opciones, ¿Qué quiere hacer?");
            Console.SetCursorPosition(x, y++); Console.Write("<1> Agregar un Producto al Inventario");
            Console.SetCursorPosition(x, y++); Console.Write("<2> Buscar un Producto por Codigo");
            Console.SetCursorPosition(x, y++); Console.Write("<3> Modificar Datos de un Producto");
            Console.SetCursorPosition(x, y++); Console.Write("<4> Procesar una Venta");
            Console.SetCursorPosition(x, y++); Console.Write("<5> Eliminar un Producto usando el Codigo");
            Console.SetCursorPosition(x, y++); Console.Write("<6> Contratar a un Vendedor");
            Console.SetCursorPosition(x, y++); Console.Write("<7> Despedir a un Vendedor");
            Console.SetCursorPosition(x, y++); Console.Write("<8> Listas");
            Console.SetCursorPosition(x, y++); Console.Write("<9> Salir");
            Console.SetCursorPosition(x, y++); Console.Write("Ingrese su opcion: ");
        }
        public static void SubInterfaz()
        {
            int x = 11, y = 10;
            Console.Clear();

            Titulos.MostrarTituloSecundario();

            Borde(10, 9, 103, 18);
            Console.SetCursorPosition(x, y++); Console.Write("Opciones: ");
            Console.SetCursorPosition(x, y++); Console.Write("<1> Listar todos los productos");
            Console.SetCursorPosition(x, y++); Console.Write("<2> Listar los productos mas vendidos");
            Console.SetCursorPosition(x, y++); Console.Write("<3> Listar los productos menos vendidos");
            Console.SetCursorPosition(x, y++); Console.Write("<4> Listar los productos que necesitan reponerse");
            Console.SetCursorPosition(x, y++); Console.Write("<5> Listar las ventas realizadas");
            Console.SetCursorPosition(x, y++); Console.Write("<6> Listar los trabajadores y sus ventas");
            Console.SetCursorPosition(x, y++); Console.Write("<7> Salir");
            Console.SetCursorPosition(x, ++y); Console.Write("Ingrese su eleccion: ");
        }
        public static void MostrarError(string mensaje)
        {
            // Funcion que permite el mostrar errores de forma general en cualquier parte del codigo
            Console.SetCursorPosition(35, 22);
            Console.Write(mensaje);
            Console.ReadKey();
        }

        public static string LeerDato(string prompt, int x, ref int y)
        {
            // Funcion que permite el leer datos de forma general en cualquier parte del codigo
            Console.SetCursorPosition(x, y++);
            Console.Write(prompt);
            return Console.ReadLine();
        }


    }
}
