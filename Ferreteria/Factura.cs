using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria
{
    internal class Factura
    {
        #region Atributos
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NombreVendedor { get; set; }
        public int Cantidad { get; set; }
        //public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        #endregion
    }
}
