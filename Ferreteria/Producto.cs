using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria
{
    internal class Producto
    {

        #region Atributos

        public string Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock_Actual { get; set; }
        public int Stock_Minimo { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public Producto(string I, string N, double P, int SA, int SM, string D)
        {
            Precio = P;
            Nombre = N;
            Id = I;
            Stock_Actual = SA;
            Stock_Minimo = SM;
            Descripcion = D;
        }

        #endregion


        #region Metodos

            

        #endregion
    }
}
