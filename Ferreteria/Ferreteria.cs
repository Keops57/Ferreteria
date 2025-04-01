using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime;

namespace Ferreteria
{
    internal class Ferreteria
    {
        #region Atributos
        private class DatosCompletos
        {
            public List<Vendedor> Vendedores { get; set; }
            public List<Factura> Facturas { get; set; }
            public List<Producto> Productos { get; set; }
        }

        private static readonly string RUTA_ARCHIVO = Path.Combine(Directory.GetCurrentDirectory(), "ferreteria.json");
        public List<Vendedor> Vendedores { get; private set; } = new List<Vendedor>();
        public List<Factura> Facturas { get; private set; } = new List<Factura>();

        public Inventario Inventario { get; private set; } = new Inventario();
        #endregion

        #region Metodos
        public void AgregarVendedor()
        {
            try
            {
                Console.Clear();
                Titulos.MostrarContratar();
                Helpers.Borde(10, 9, 103, 18);
                Console.SetCursorPosition(11, 10); Console.Write("Quiere agregar un vendedor?/n <1> Si <2> No: ");
                if (!int.TryParse(Console.ReadLine(), out int opcion) || (opcion != 1 && opcion != 2))
                {
                    Helpers.MostrarError("Opción inválida. Intente nuevamente.");
                    return;
                }

                if (opcion == 2) return;

                int x = 11, y = 11;
                var nuevoVendedor = new Vendedor();

                nuevoVendedor.Nombre = Helpers.LeerDato("Nombre del Vendedor: ", x, ref y);
                nuevoVendedor.Codigo = Helpers.LeerDato("Código del Vendedor (Sigue la estructura V + 3numeros + 1letra): ", x, ref y);

                if (ValidarVendedor(nuevoVendedor))
                {
                    Vendedores.Add(nuevoVendedor);
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("¡Vendedor agregado exitosamente!");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Helpers.MostrarError($"Error: {ex.Message}");
            }
        }
        public void ListarVendedores()
        {
            try
            {
                Console.Clear();
                Titulos.MostrarTituloVendedores();
                Helpers.Borde(10, 9, 103, 18);

                Vendedores = Vendedores.OrderByDescending(v => v.NumeroVentas).ToList();

                int x = 12, y = 11; // Posición inicial del cursor

                // Título y encabezados
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== LISTADO DE VENDEDORES ===");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine($"Total registros: {Vendedores.Count}");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('═', 90));

                // Encabezados de columnas
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("CÓDIGO    NOMBRE".PadRight(30) +
                                 "NUMERO VENTAS".PadLeft(15));

                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('─', 90));

                // Lista de productos
                foreach (var vendedor in Vendedores)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine(
                        $"{vendedor.Codigo.PadRight(10)} " +
                        $"{vendedor.Nombre.PadRight(20)} " +
                        $"{vendedor.NumeroVentas.ToString().PadLeft(12)}");

                    if (y >= 26) // Control para no sobrepasar el borde inferior
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.Write("-- PRESIONE CUALQUIER TECLA PARA CONTINUAR --");
                        Console.ReadKey();
                        y = 11; // Resetear posición
                        Console.Clear();
                        Helpers.Borde(10, 9, 103, 18);
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine("=== LISTADO DE VENDEDORES ===");
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine($"Total registros: {Vendedores.Count}");
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(new string('═', 90));

                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine("CÓDIGO    NOMBRE".PadRight(30) +
                                         "NUMERO VENTAS".PadLeft(15) );

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
                Console.Write($"Error al listar vendedores: {ex.Message}");
                Console.ReadKey();
            }
        }
        public void EliminarVendedor()
        {
            try
            {
                Console.Clear();
                Titulos.MostrarDespedir();
                Helpers.Borde(10, 9, 103, 18);
                int x = 12, y = 11;

                // Mostrar encabezado
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== ELIMINAR VENDEDOR ===");
                Console.SetCursorPosition(x, y++);
                Console.Write("Ingrese el código del vendedor a eliminar: ");
                string codigo = Console.ReadLine();

                // Buscar producto
                Vendedor vendedorAEliminar = Vendedores.FirstOrDefault(v => v.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

                if (vendedorAEliminar == null)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.Write("❌ Vendedor no encontrado");
                    Console.ReadKey();
                    return;
                }

                // Confirmar eliminación
                Console.SetCursorPosition(x, y++);
                Console.Write($"¿Eliminar {vendedorAEliminar.Nombre} (Código: {vendedorAEliminar.Codigo})? [S/N]: ");
                string confirmacion = Console.ReadLine();

                if (confirmacion.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    // Eliminar de la lista en memoria
                    Vendedores.Remove(vendedorAEliminar);

                    // Actualizar JSON

                    Console.SetCursorPosition(x, y++);
                    Console.Write("✅ Vendedor eliminado correctamente");
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
                Console.Write($"Error al despedir empleado: {ex.Message}");
                Console.ReadKey();
            }
        }

        public void ListarVentas()
        {
            try
            {
                Console.Clear();
                Titulos.MostrarTituloVentas();
                Helpers.Borde(10, 9, 103, 18);

                int x = 12, y = 11; // Posición inicial del cursor

                // Título y encabezados
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("=== LISTADO DE VENTAS ===");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine($"Total ventas: {Facturas.Count}");
                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('═', 90));

                // Encabezados de columnas
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("CÓDIGO FACTURA    NOMBRE.P".PadRight(20) +
                                 "CANTIDAD.P".PadLeft(15) +
                                 "CODIGO.V".PadLeft(15) +
                                 "NOMBRE.V".PadLeft(15) +
                                 "TOTAL".PadLeft(15));

                Console.SetCursorPosition(x, y++);
                Console.WriteLine(new string('─', 90));

                // Lista de productos
                foreach (var factura in Facturas)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine(
                        $"{factura.CodigoFactura.PadRight(15)} " +
                        $"{factura.NombreProducto.PadRight(25)} " +
                        $"{factura.Cantidad.ToString().PadRight(5)} " +
                        $"{factura.CodigoVendedor.ToString().PadLeft(3)} " +
                        $"{factura.NombreVendedor.ToString().PadLeft(18)}" +
                        $"{factura.Total.ToString().PadLeft(10)}$");

                    if (y >= 26) // Control para no sobrepasar el borde inferior
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.Write("-- PRESIONE CUALQUIER TECLA PARA CONTINUAR --");
                        Console.ReadKey();
                        y = 11; // Resetear posición
                        Console.Clear();
                        Helpers.Borde(10, 9, 103, 18);
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine("=== LISTADO DE VENTAS ===");
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine($"Total ventas: {Facturas.Count}");
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(new string('═', 90));

                        // Encabezados de columnas
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine("CÓDIGO FACTURA    NOMBRE.P".PadRight(20) +
                                         "CANTIDAD.P".PadLeft(15) +
                                         "CODIGO.V".PadLeft(15) +
                                         "NOMBRE.V".PadLeft(15) +
                                         "TOTAL".PadLeft(15));

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
                Console.Write($"Error al listar ventas: {ex.Message}");
                Console.ReadKey();
            }
        }

        public void Vender()
        {

            try
            {
                Console.Clear();
                Titulos.MostrarVender();
                Helpers.Borde(10, 9, 103, 18);
                Console.SetCursorPosition(11, 10); Console.Write("Quiere confirmar una venta?/n <1> Si <2> No: ");
                if (!int.TryParse(Console.ReadLine(), out int opcion) || (opcion != 1 && opcion != 2))
                {
                    Helpers.MostrarError("Opción inválida. Intente nuevamente.");
                    return;
                }

                if (opcion == 2) return;

                int x = 11, y = 11;
                var nuevaVenta = new Factura();

                nuevaVenta.CodigoProducto = Helpers.LeerDato("Codigo del Producto: ", x, ref y);
                nuevaVenta.Cantidad = int.Parse(Helpers.LeerDato("Cantidad del Producto a vender: ", x, ref y));
                nuevaVenta.CodigoVendedor = Helpers.LeerDato("Codigo del Vendedor: ", x, ref y);


                Producto productoAVender = Inventario.Productos.FirstOrDefault(p => p.Id.Equals(nuevaVenta.CodigoProducto, StringComparison.OrdinalIgnoreCase));

                Vendedor vendedorAtendiendo = Vendedores.FirstOrDefault(v => v.Codigo.Equals(nuevaVenta.CodigoVendedor, StringComparison.OrdinalIgnoreCase));


                if (ValidarVenta(nuevaVenta,productoAVender,vendedorAtendiendo))
                {
                    nuevaVenta.NombreProducto = productoAVender.Nombre;
                    nuevaVenta.NombreVendedor = vendedorAtendiendo.Nombre;

                    nuevaVenta.Total = productoAVender.Precio * nuevaVenta.Cantidad;

                    productoAVender.StockActual -= nuevaVenta.Cantidad;
                    productoAVender.CantidadVendido += nuevaVenta.Cantidad;
                    vendedorAtendiendo.NumeroVentas += 1;

                    vendedorAtendiendo.NumeroVentas += 1;

                    if (productoAVender.StockActual <= productoAVender.StockMinimo) productoAVender.REPO = true;

                    Facturas.Add(nuevaVenta);
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("¡Venta agregada exitosamente!");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Helpers.MostrarError($"Error: {ex.Message}");
            }

            
        }

        #region Validaciones
        private bool ValidarVendedor(Vendedor vendedor)
        {
            if (string.IsNullOrWhiteSpace(vendedor.Nombre))
            {
                Helpers.MostrarError("El nombre no puede estar vacío");
                return false;
            }

            if (!Helpers.ValidarCodigoVendedor(vendedor.Codigo))
            {
                string ejemplo = Helpers.GenerarEjemploVendedor();
                Helpers.MostrarError($"Formato inválido. Use V + 3 números + 1 letra. Ej: {ejemplo}");
                return false;
            }

            if (Vendedores.Any(v => v.Codigo.Equals(vendedor.Codigo, StringComparison.OrdinalIgnoreCase)))
            {
                Helpers.MostrarError("Ya existe un vendedor con este código");
                return false;
            }

            return true;
        }

        private bool ValidarVenta(Factura factura, Producto producto, Vendedor vendedor)
        {
            if (string.IsNullOrWhiteSpace(factura.CodigoProducto))
            {
                Helpers.MostrarError("El codigo no puede estar vacío");
                return false;
            }

            if (Facturas.Any(f => f.CodigoFactura == factura.CodigoFactura))
            {
                Helpers.MostrarError("Ya existe una factura con este código");
                return false;
            }

            if (producto == null)
            {
                Helpers.MostrarError("El producto a vender no existe");
                return false;
            }

            if (producto.StockActual - factura.Cantidad < 0)
            {
                Helpers.MostrarError("El producto a vender no tiene stock suficiente para vender");
                return false;
            }

            if (vendedor == null)
            {
                Helpers.MostrarError("El vendedor no está en al nómina");
                return false;
            }

            return true;
        }

        #endregion

        public void GuardarDatos(int x, int y)
        {
            try
            {
                var datos = new
                {
                    Vendedores,
                    Facturas,
                    Productos = Inventario.Productos
                };

                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                // Asegurar que el directorio existe
                Directory.CreateDirectory(Path.GetDirectoryName(RUTA_ARCHIVO));

                // Guardar el archivo
                File.WriteAllText(RUTA_ARCHIVO, json);

                Console.SetCursorPosition(x, y); Console.WriteLine($"Datos guardados");
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(x, y); Console.WriteLine($"Error al guardar datos: {ex.Message}");
            }
        }

        public void CargarDatos()
        {
            if (File.Exists(RUTA_ARCHIVO))
            {
                string json = File.ReadAllText(RUTA_ARCHIVO);
                var datos = JsonConvert.DeserializeObject<DatosCompletos>(json);

                Vendedores = datos.Vendedores ?? new List<Vendedor>();
                Facturas = datos.Facturas ?? new List<Factura>();
                Inventario.Productos = datos.Productos ?? new List<Producto>();
            }
        }

        #endregion


        public void Run()
        {
            CargarDatos();
            bool key = true;
            while (key)
            {
                try
                {
                    int op;
                    Helpers.InterfazP();
                    if (!int.TryParse(Console.ReadLine(), out op)) op = 0;
                    switch (op)
                    {
                        case 1: //Agregar Producto
                            Inventario.AgregarProducto();
                            GuardarDatos(20,22);
                            break;

                        case 2: // Buscar un producto

                            Inventario.BuscarProducto();
                            break;

                        case 3: //Modificar un producto
                            Inventario.ActualizarProducto();
                            GuardarDatos(20, 22);
                            break;

                        case 4: // Procesar una Venta
                            Vender();
                            GuardarDatos(20, 22);
                            break;

                        case 5: // Eliminar un Producto
                            Inventario.EliminarProductoPorCodigo();
                            GuardarDatos(20, 22);
                            break;

                        case 6: // Contratar a un empleado
                            AgregarVendedor();
                            GuardarDatos(20, 22);
                            break;

                        case 7: // Despedir a un empleado
                            EliminarVendedor();
                            GuardarDatos(20, 22);
                            break;

                        case 8://Listas
                            do
                            {
                                Helpers.SubInterfaz();
                                if (!int.TryParse(Console.ReadLine(), out op)) op = 0;
                                switch (op)
                                {
                                    case 1://Listar todos los productos
                                        Inventario.ListarProductos();
                                        break;

                                    case 2: // Listar los productos mas vendidos
                                        Inventario.ListarProductosMasVendidos();
                                        break;

                                    case 3: //Listar los productos menos vendidos
                                        Inventario.ListarProductosMenosVendidos();
                                        break;

                                    case 4: // Listar los productos que necesitan reponerse
                                        Inventario.ListarProductosREPO();
                                        break;

                                    case 5: // Listar las ventas realizadas
                                        ListarVentas();
                                        break;

                                    case 6: // Listar los trabajadores y sus ventas
                                        ListarVendedores();
                                        break;

                                    case 7:// Salir
                                        key = false;
                                        break;

                                    default:
                                        Console.SetCursorPosition(40, 22); Console.Write("Valor invalido, intente de nuevo! ");
                                        Console.ReadKey();
                                        break;
                                }
                            } while (key);
                            Console.Clear();
                            key = true;
                            break;

                        case 9: //Salir
                            key = false;
                            Console.Clear();
                            Titulos.USMLogo(35, 2, 100);
                            Helpers.Borde(20, 17, 80, 7);
                            GuardarDatos(45, 19);
                            Console.SetCursorPosition(45, 21); Console.WriteLine("Adios :D");
                            Console.SetCursorPosition(45, 23);
                            break;
                        default:
                            Console.SetCursorPosition(40, 22); Console.Write("Valor invalido, intente de nuevo! ");
                            Console.ReadKey();
                            key = true;
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    key = true;
                }


            }

        }
    }
}
