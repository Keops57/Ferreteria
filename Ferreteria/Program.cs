using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria
{
    internal class Program : Ferreteria
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Ferreteria Ferreteria = new Ferreteria();

            Ferreteria.Run();
        }
    }
}
