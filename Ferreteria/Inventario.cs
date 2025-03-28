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
        public List<Producto> Productos { get; private set; } = new List<Producto>();

        #endregion


        #region Constructores
        public Inventario() 
        {
        }
        #endregion 

        #region Metodos
        public void AgregarProducto()
        {
            int x = 11, y = 10;
            Console.Clear();
            Helpers.Borde(10, 9, 103, 18);
            Console.SetCursorPosition(x, y++); Console.Write("Quiere agregar un producto?/n <1> Si <2> No: ");
            int op;
            if (!int.TryParse(Console.ReadLine(), out op)) op = 0;
            switch (op)
                    {
                        case 1: //Agregar Producto
                            break;

                        case 2: //Salir

                            break;

                        default:
                            Console.SetCursorPosition(40, 22); Console.Write("Valor invalido, intente de nuevo! ");
                            Console.ReadKey();
                            break;
                    }
                
            

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
