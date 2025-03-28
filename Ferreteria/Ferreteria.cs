using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria
{
    internal class Ferreteria
    {
        #region Atributos
        public List<Vendedor> Vendedores { get; private set; } = new List<Vendedor>();
        public List<Factura> Facturas { get; private set; } = new List<Factura>();
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

        public void Run()
        {
            Inventario Inventario = new Inventario();
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
                            break;

                        case 2: //Salir
                            key = false;
                            Console.Clear();
                            Helpers.Borde(20, 17, 80, 7);
                            Console.SetCursorPosition(55, 21); Console.WriteLine("Adios :D");
                            break;

                        case 3://Sub Menu
                            do
                            {
                                Helpers.SubInterfaz();
                                if (!int.TryParse(Console.ReadLine(), out op)) op = 0;
                                switch (op)
                                {
                                    case 1://Print Random
                                        key = false;
                                        break;
                                    case 2://Salir
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
