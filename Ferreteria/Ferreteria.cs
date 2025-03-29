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

        public void ListarVendedores()
        {

        }

        public void EliminarVenderor()
        {

        }

        public void ListarVentas()
        {

        }

        #endregion

        public void GuardarDatos(int x,int y)
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
                            break;

                        case 3: //Modificar un producto
                            break;

                        case 4: // Procesar una Venta
                            break;

                        case 5: // Eliminar un Producto
                            Inventario.EliminarProductoPorCodigo();
                            GuardarDatos(20, 22);
                            break;

                        case 6: // Despedir a un empleado
                            break;

                        case 7://Listas
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
                                        break;

                                    case 3: //Listar los productos menos vendidos
                                        break;

                                    case 4: // Listar los productos que necesitan reponerse
                                        break;

                                    case 5: // Listar las ventas realizadas
                                        break;

                                    case 6: // Listar los trabajadores y sus ventas
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

                        case 8: //Salir
                            key = false;
                            Console.Clear();
                            Helpers.Borde(20, 17, 80, 7);
                            GuardarDatos(55, 19);
                            Console.SetCursorPosition(55, 21); Console.WriteLine("Adios :D");
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
