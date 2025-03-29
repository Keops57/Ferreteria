using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria
{
    internal class Inventario
    {
        #region Atributos
        public List<Producto> Productos { get; set; } = new List<Producto>();

        #endregion

        #region Constructores
        public Inventario() 
        {
        }
        #endregion 

        #region Metodos
        public void AgregarProducto()
        {
            try
            {
                Console.Clear();
                Helpers.Borde(10, 9, 103, 18);
                Console.SetCursorPosition(11, 10); Console.Write("Quiere agregar un producto?/n <1> Si <2> No: ");
                if (!int.TryParse(Console.ReadLine(), out int opcion) || (opcion != 1 && opcion != 2))
                {
                    Helpers.MostrarError("Opción inválida. Intente nuevamente.");
                    return;
                }

                if (opcion == 2) return;

                int x = 11, y = 11;
                var nuevoProducto = new Producto();

                nuevoProducto.Nombre = Helpers.LeerDato("Nombre del Producto: ", x, ref y);
                nuevoProducto.Id = Helpers.LeerDato("Código del Producto: ", x, ref y);
                nuevoProducto.Precio = double.Parse(Helpers.LeerDato("Precio del Producto: ", x, ref y));
                nuevoProducto.StockActual = int.Parse(Helpers.LeerDato("Stock Actual: ", x, ref y));
                nuevoProducto.StockMinimo = int.Parse(Helpers.LeerDato("Stock Mínimo: ", x, ref y));
                nuevoProducto.Descripcion = Helpers.LeerDato("Descripcion: ", x, ref y);

                if (ValidarProducto(nuevoProducto))
                {
                    Productos.Add(nuevoProducto);
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("¡Producto agregado exitosamente!");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Helpers.MostrarError($"Error: {ex.Message}");
            }
        }

        private bool ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                Helpers.MostrarError("El nombre no puede estar vacío");
                return false;
            }

            if (producto.Precio <= 0)
            {
                Helpers.MostrarError("El precio debe ser mayor que cero");
                return false;
            }

            if (producto.StockActual <= 0 || producto.StockMinimo <= 0)
            {
                Helpers.MostrarError("El ningun stock puede ser menor o igual a 0");
                return false;
            }

            if (producto.StockActual < producto.StockMinimo)
            {
                Helpers.MostrarError("El stock actual tiene que ser mayor o igual al minimo");
                return false;
            }
            
            if (Productos.Any(p => p.Id == producto.Id))
            {
                Helpers.MostrarError("Ya existe un producto con este código");
                return false;
            }

            return true;
        }

        public void BuscarProducto(string id)
        {

        }

        public void ActualizarProducto(string id)
        {

        }
        public void EliminarProducto(string id)
        {

        }

        public void ListarProductos()
        {
            try
            {
                Console.Clear();
                Helpers.Borde(10, 8, 103, 20);

                int x = 12, y = 11; // Posición inicial del cursor

                // Título y encabezados
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== LISTADO DE PRODUCTOS ===");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine($"Total registros: {Productos.Count}");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('═', 90));

                // Encabezados de columnas
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("CÓDIGO    NOMBRE".PadRight(30) +
                                 "PRECIO".PadLeft(15) +
                                 "STOCK ACT".PadLeft(15) +
                                 "STOCK MÍN".PadLeft(15));

                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('─', 90));

                // Lista de productos
                foreach (var producto in Productos)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine(
                        $"{producto.Id.PadRight(10)} " +
                        $"{producto.Nombre.PadRight(20)} " +
                        $"{producto.Precio.ToString().PadLeft(12)}$" +
                        $"{producto.StockActual.ToString().PadLeft(12)} " +
                        $"{producto.StockMinimo.ToString().PadLeft(12)}");

                    if (y >= 26) // Control para no sobrepasar el borde inferior
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.Write("-- PRESIONE CUALQUIER TECLA PARA CONTINUAR --");
                        Console.ReadKey();
                        y = 11; // Resetear posición
                        Console.Clear();
                        Helpers.Borde(10, 8, 103, 20);
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine("=== LISTADO DE PRODUCTOS ===");
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine($"Total registros: {Productos.Count}");
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(new string('═', 90));

                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine("CÓDIGO    NOMBRE".PadRight(30) +
                                         "PRECIO".PadLeft(15) +
                                         "STOCK ACT".PadLeft(15) +
                                         "STOCK MÍN".PadLeft(15));

                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(new string('─', 90));
                    }
                }

                Console.SetCursorPosition(x, y + 2);
                Console.Write("-- PRESIONE CUALQUIER TECLA PARA VOLVER AL MENÚ --");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(12, 24);
                Console.Write($"Error al listar productos: {ex.Message}");
                Console.ReadKey();
            }
        }

        public void ListarProductosMasVendidos()
        {

        }

        public void ListarProductosMenosVendidos()
        {

        }

        public void ListarProductosREPO()
        {

        }

        #endregion


    }
}
