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
        //public DateTime Fecha { get; set; } = DateTime.Now;
        public double Total { get; set; }
        #endregion
        public Factura()
        {
            CodigoFactura = GenerarCodigoAleatorio();
        }

        public string GenerarCodigoAleatorio()
        {
            Random random = new Random();
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(caracteres, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

    
