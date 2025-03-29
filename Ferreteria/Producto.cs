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
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string Descripcion { get; set; }
        public bool REPO { get; set; } = false;


        #endregion

        #region Constructores

        public Producto()
        {

        }

        #endregion


        #region Metodos

            

        #endregion
    }
}
