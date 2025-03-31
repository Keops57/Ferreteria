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

        public string CodigoFactura { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NombreVendedor { get; set; }
        public string CodigoVendedor { get; set; }

        public int Cantidad { get; set; }
        public double Total { get; set; }
        #endregion
        public Factura()
        {
            CodigoFactura = GenerarCodigoAleatorio();
        }

        public string GenerarCodigoAleatorio()
        {
            Random random = new Random();
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return "F" +
                   random.Next(0, 10000).ToString("D4") +  // 4 dígitos con ceros a la izquierda
                   new string(Enumerable.Repeat(letras, 2)
                       .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

    
