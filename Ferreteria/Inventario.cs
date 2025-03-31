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

        public void BuscarProducto()
        {
            try
            {
                Console.Clear();
                Titulos.MostrarBuscar();
                Helpers.Borde(10, 9, 103, 18);
                int x = 12, y = 11;

                // Mostrar encabezado
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== BUSCAR PRODUCTO ===");
                Console.SetCursorPosition(x, y++);
                Console.Write("Ingrese el código del producto a buscar: ");
                string codigo = Console.ReadLine();
                Console.SetCursorPosition(x, y++);
                Console.Write(new string('═', 90));

                // Encabezados de columnas
                Console.SetCursorPosition(x, y++);
                Console.Write("CÓDIGO    NOMBRE".PadRight(30) +
                                 "PRECIO".PadLeft(15) +
                                 "STOCK ACT".PadLeft(15) +
                                 "STOCK MÍN".PadLeft(15));

                Console.SetCursorPosition(x, y++);
                Console.Write(new string('─', 90));

                // Buscar producto
                Producto productoABuscar = Productos.FirstOrDefault(p => p.Id.Equals(codigo, StringComparison.OrdinalIgnoreCase));

                if (productoABuscar == null)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.Write("❌ Producto no encontrado");
                    Console.ReadKey();
                    return;
                }

                Console.SetCursorPosition(x, y++);
                Console.Write(
                    $"{productoABuscar.Id.PadRight(10)} " +
                    $"{productoABuscar.Nombre.PadRight(20)} " +
                    $"{productoABuscar.Precio.ToString().PadLeft(12)}$" +
                    $"{productoABuscar.StockActual.ToString().PadLeft(12)} " +
                    $"{productoABuscar.StockMinimo.ToString().PadLeft(12)}");

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(12, 24);
                Console.Write($"Error al encontrar producto: {ex.Message}");
                Console.ReadKey();
            }
        }

        public void ActualizarProducto()
        {
            try
            {
                Console.Clear();
                Titulos.MostrarActualizar();
                Helpers.Borde(10, 9, 103, 18);
                int x = 12, y = 11;

                // Mostrar encabezado
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== ACTUALIZAR PRODUCTO ===");
                Console.SetCursorPosition(x, y++);
                Console.Write("Ingrese el código del producto a actualizar: ");
                string codigo = Console.ReadLine();

                // Buscar producto
                Producto productoAEditar = Productos.FirstOrDefault(p => p.Id.Equals(codigo, StringComparison.OrdinalIgnoreCase));

                if (productoAEditar == null)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.Write("❌ Producto no encontrado");
                    Console.ReadKey();
                    return;
                }
                Console.SetCursorPosition(x, y++);
                productoAEditar.StockActual = int.Parse(Helpers.LeerDato("Stock Actual: ", x, ref y));
                Console.SetCursorPosition(x, y++);
                productoAEditar.Precio = double.Parse(Helpers.LeerDato("Precio: ", x, ref y));



                // Confirmar Actualizacion
                Console.SetCursorPosition(x, y++);
                Console.Write($"¿Editar {productoAEditar.Nombre} (Código: {productoAEditar.Id})? [S/N]: ");
                string confirmacion = Console.ReadLine();

                if (confirmacion.Equals("S", StringComparison.OrdinalIgnoreCase) && ValidarProducto(productoAEditar))
                {

                    Console.SetCursorPosition(x ,y++);
                    Console.Write("✅ Producto actualizado correctamente");
                }
                else
                {
                    Console.Clear();
                    Helpers.Borde(10, 9, 103, 18);
                    Console.SetCursorPosition(x+35, y++);
                    Console.Write("❌ Actualizacion cancelada");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(12, 24);
                Console.Write($"Error al actualizar producto: {ex.Message}");
                Console.ReadKey();
            }
        }
        public void EliminarProductoPorCodigo()
        {
            try
            {
                Console.Clear();
                Titulos.MostrarEliminar();
                Helpers.Borde(10, 9, 103, 18);
                int x = 12, y = 11;

                // Mostrar encabezado
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== ELIMINAR PRODUCTO ===");
                Console.SetCursorPosition(x, y++);
                Console.Write("Ingrese el código del producto a eliminar: ");
                string codigo = Console.ReadLine();

                // Buscar producto
                Producto productoAEliminar = Productos.FirstOrDefault(p => p.Id.Equals(codigo, StringComparison.OrdinalIgnoreCase));

                if (productoAEliminar == null)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.Write("❌ Producto no encontrado");
                    Console.ReadKey();
                    return;
                }

                // Confirmar eliminación
                Console.SetCursorPosition(x, y++);
                Console.Write($"¿Eliminar {productoAEliminar.Nombre} (Código: {productoAEliminar.Id})? [S/N]: ");
                string confirmacion = Console.ReadLine();

                if (confirmacion.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    // Eliminar de la lista en memoria
                    Productos.Remove(productoAEliminar);

                    // Actualizar JSON

                    Console.SetCursorPosition(x, y++);
                    Console.Write("✅ Producto eliminado correctamente");
                }
                else
                {
                    Console.SetCursorPosition(x, y++);
                    Console.Write("❌ Eliminación cancelada");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(12, 24);
                Console.Write($"Error al eliminar producto: {ex.Message}");
                Console.ReadKey();
            }
        }
        public void ListarProductos()
        {
            try
            {
                Console.Clear();
                Helpers.Borde(10, 9, 103, 18);

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
                        Helpers.Borde(10, 9, 103, 18);
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
            try
            {
                Console.Clear();
                Helpers.Borde(10, 9, 103, 18);

                int x = 12, y = 11; // Posición inicial del cursor

                // Título y encabezados
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== TOP 3 PRODUCTOS ===");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("Los 3 productos mas vendidos");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('═', 90));

                // Encabezados de columnas
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("POSICIÓN  CÓDIGO    NOMBRE".PadRight(30) +
                                 "VENTAS".PadLeft(15) +
                                 "% DEL TOTAL".PadLeft(15));

                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('─', 90));

                var productosMasVendidos = Productos.OrderByDescending(p => p.CantidadVendido)
                                              .Take(3)
                                              .ToList();

                int totalVentas = Productos.Sum(p => p.CantidadVendido);

                

                for (int i = 0; i< productosMasVendidos.Count;i++)
                {
                    var producto = productosMasVendidos[i];

                    double porcentaje = totalVentas > 0 ? (producto.CantidadVendido * 100.0) / totalVentas : 0;

                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine(
                        $"{i + 1,-9} " +  // Posición (1°, 2°, 3°)
                        $"{producto.Id.PadRight(10)} " +
                        $"{producto.Nombre.PadRight(20)} " +
                        $"{producto.CantidadVendido.ToString().PadLeft(12)} " +
                        $"{porcentaje.ToString("F2").PadLeft(12)}%");
                }

                if (!productosMasVendidos.Any())
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine("No hay productos que se hayan vendido aun");
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

        public void ListarProductosMenosVendidos()
        {
            try
            {
                Console.Clear();
                Helpers.Borde(10, 9, 103, 18);

                int x = 12, y = 11; // Posición inicial del cursor

                // Título y encabezados
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== BOTTOM 3 PRODUCTOS ===");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("Los 3 productos menos vendidos");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('═', 90));

                // Encabezados de columnas
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("POSICIÓN  CÓDIGO    NOMBRE".PadRight(30) +
                                 "VENTAS".PadLeft(15) +
                                 "% DEL TOTAL".PadLeft(15));

                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('─', 90));

                var productosMenosVendidos = Productos.OrderBy(p => p.CantidadVendido)
                                              .Take(3)
                                              .ToList();

                int totalVentas = Productos.Sum(p => p.CantidadVendido);



                for (int i = 0; i < productosMenosVendidos.Count; i++)
                {
                    var producto = productosMenosVendidos[i];

                    double porcentaje = totalVentas > 0 ? (producto.CantidadVendido * 100.0) / totalVentas : 0;

                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine(
                        $"{i + 1,-9} " +  // Posición (1°, 2°, 3°)
                        $"{producto.Id.PadRight(10)} " +
                        $"{producto.Nombre.PadRight(20)} " +
                        $"{producto.CantidadVendido.ToString().PadLeft(12)} " +
                        $"{porcentaje.ToString("F2").PadLeft(12)}%");
                }

                if (!productosMenosVendidos.Any())
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine("No hay productos que se hayan vendido aun");
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

        public void ListarProductosREPO()
        {
            try
            {
                Console.Clear();
                Helpers.Borde(10, 9, 103, 18);

                int x = 12, y = 11; // Posición inicial del cursor

                // Título y encabezados
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== PRODUCTOS A SURTIR ===");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("(Stock actual <= Stock mínimo)");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('═', 90));

                // Encabezados de columnas
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("CÓDIGO    NOMBRE".PadRight(30) +
                                 "STOCK ACT".PadLeft(15) +
                                 "STOCK MIN".PadLeft(15) +
                                 "A REPONER".PadLeft(15));

                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('─', 90));

                // Filtrar y listar productos que necesitan reposición
                var productosReponer = Productos.Where(p => p.REPO) // Determina las condiciones para agregar elementos
                                              .OrderByDescending(p => p.StockActual) 
                                              .ToList();

                foreach (var producto in productosReponer)
                {
                    int reponer = producto.StockMinimo + 1 - producto.StockActual;

                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine(
                        $"{producto.Id.PadRight(10)} " +
                        $"{producto.Nombre.PadRight(20)} " +
                        $"{producto.StockActual.ToString().PadLeft(12)} " +
                        $"{producto.StockMinimo.ToString().PadLeft(12)} " +
                        $"{reponer.ToString().PadLeft(12)}");

                    if (y >= 26)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.Write("-- PRESIONE CUALQUIER TECLA PARA CONTINUAR --");
                        Console.ReadKey();
                        y = 11; // Resetear posición
                        Console.Clear();
                        Helpers.Borde(10, 9, 103, 18);

                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine("=== PRODUCTOS A SURTIR ===");
                    }
                }

                if (!productosReponer.Any())
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine("No hay productos que requieran reponerse");
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

        #endregion


    }
}
