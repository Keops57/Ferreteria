using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria
{
    internal static class Titulos
    {
        //Esto si que es full GPT, no me da el diseñador grafico interno para hacer esto bien yo solo xD

        public static void DibujarTituloPersonalizado(string[] arteAscii, ConsoleColor[] gradiente, int ajusteHorizontal = 0)
        {
            // Configuración inicial
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int centroHorizontal = Console.WindowWidth / 2;
            int startY = 2; // Posición vertical inicial

            // Calcular posición horizontal centrada con ajuste
            int maxLength = arteAscii.Max(linea => linea.Length);
            int startX = centroHorizontal - (maxLength / 2) + ajusteHorizontal;

            // Dibujar cada línea con su color correspondiente
            for (int i = 0; i < arteAscii.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i);

                // Seleccionar color del gradiente (cicla si hay más líneas que colores)
                ConsoleColor color = gradiente[i % gradiente.Length];
                Console.ForegroundColor = color;

                Console.WriteLine(arteAscii[i]);
            }
            Console.ResetColor();
        }

        public static void MostrarTituloMenuSimple()
        {
            string[] asciiArt = {
        "███╗   ███╗███████╗███╗   ██╗██╗   ██╗",
        "████╗ ████║██╔════╝████╗  ██║██║   ██║",
        "██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║",
        "██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║",
        "██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝",
        "╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝"
    };

            ConsoleColor[] gradiente = {
        ConsoleColor.DarkYellow,
        ConsoleColor.Yellow,
        ConsoleColor.White
    };

            DibujarTituloPersonalizado(asciiArt, gradiente, 3);
        }

        public static void MostrarTituloSecundario()
        {
            string[] asciiArt = {
        "███████╗██╗   ██╗██████╗       ███╗   ███╗███████╗███╗   ██╗██╗   ██╗",
        "██╔════╝██║   ██║██╔══██╗      ████╗ ████║██╔════╝████╗  ██║██║   ██║",
        "███████╗██║   ██║██████╔╝█████╗██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║",
        "╚════██║██║   ██║██╔══██╗╚════╝██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║",
        "███████║╚██████╔╝██████╔╝      ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝",
        "╚══════╝ ╚═════╝ ╚═════╝       ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ "
    };

            ConsoleColor[] gradiente = {
        ConsoleColor.Cyan,
        ConsoleColor.Blue,
        ConsoleColor.DarkBlue,
        ConsoleColor.Magenta,
        ConsoleColor.DarkMagenta
    };

            DibujarTituloPersonalizado(asciiArt, gradiente, 0);
        }

        public static void MostrarBuscar()
        {
            string[] asciiArt = {
        "██████╗ ██╗   ██╗███████╗ ██████╗ █████╗ ██████╗ ",
        "██╔══██╗██║   ██║██╔════╝██╔════╝██╔══██╗██╔══██╗",
        "██████╔╝██║   ██║███████╗██║     ███████║██████╔╝",
        "██╔══██╗██║   ██║╚════██║██║     ██╔══██║██╔══██╗",
        "██████╔╝╚██████╔╝███████║╚██████╗██║  ██║██║  ██║",
        "╚═════╝  ╚═════╝ ╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝"
    };

            ConsoleColor[] gradiente = {
        ConsoleColor.DarkBlue,
        ConsoleColor.Blue,
        ConsoleColor.Cyan,
        ConsoleColor.White
    };

            DibujarTituloPersonalizado(asciiArt, gradiente, -2); // Ajuste horizontal de -2
        }

        public static void MostrarActualizar()
        {
            string[] asciiArt = {
        "█████╗  ██████╗████████╗██╗   ██╗ █████╗ ██╗     ██╗███████╗ █████╗ ██████╗ ",
        "██╔══██╗██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║     ██║╚══███╔╝██╔══██╗██╔══██╗",
        "███████║██║        ██║   ██║   ██║███████║██║     ██║  ███╔╝ ███████║██████╔╝",
        "██╔══██║██║        ██║   ██║   ██║██╔══██║██║     ██║ ███╔╝  ██╔══██║██╔══██╗",
        "██║  ██║╚██████╗   ██║   ╚██████╔╝██║  ██║███████╗██║███████╗██║  ██║██║  ██║",
        "╚═╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝"
    };

            ConsoleColor[] gradiente = {
        ConsoleColor.DarkYellow,
        ConsoleColor.Yellow,
        ConsoleColor.White,
        ConsoleColor.Gray,
        ConsoleColor.DarkGray,
        ConsoleColor.White
    };

            DibujarTituloPersonalizado(asciiArt, gradiente, 0); // Ajuste horizontal aumentado a -5
        }

        public static void MostrarVender()
        {
            string[] asciiArt = {
        "██╗   ██╗███████╗███╗   ██╗██████╗ ███████╗██████╗ ",
        "██║   ██║██╔════╝████╗  ██║██╔══██╗██╔════╝██╔══██╗",
        "██║   ██║█████╗  ██╔██╗ ██║██║  ██║█████╗  ██████╔╝",
        "╚██╗ ██╔╝██╔══╝  ██║╚██╗██║██║  ██║██╔══╝  ██╔══██╗",
        " ╚████╔╝ ███████╗██║ ╚████║██████╔╝███████╗██║  ██║",
        "  ╚═══╝  ╚══════╝╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝  ╚═╝"
    };

            ConsoleColor[] gradiente = {
        ConsoleColor.DarkRed,
        ConsoleColor.Red,
        ConsoleColor.Yellow,
        ConsoleColor.White,
        ConsoleColor.DarkYellow,
        ConsoleColor.Red
    };

            DibujarTituloPersonalizado(asciiArt, gradiente, -3);
        }

        public static void MostrarEliminar()
        {
            string[] asciiArt = {
        "███████╗██╗     ██╗███╗   ███╗██╗███╗   ██╗ █████╗ ██████╗ ",
        "██╔════╝██║     ██║████╗ ████║██║████╗  ██║██╔══██╗██╔══██╗",
        "█████╗  ██║     ██║██╔████╔██║██║██╔██╗ ██║███████║██████╔╝",
        "██╔══╝  ██║     ██║██║╚██╔╝██║██║██║╚██╗██║██╔══██║██╔══██╗",
        "███████╗███████╗██║██║ ╚═╝ ██║██║██║ ╚████║██║  ██║██║  ██║",
        "╚══════╝╚══════╝╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝"
    };

            ConsoleColor[] gradiente = {
        ConsoleColor.DarkRed,
        ConsoleColor.Red,
        ConsoleColor.DarkMagenta,
        ConsoleColor.Magenta,
        ConsoleColor.Red,
        ConsoleColor.DarkRed
    };

            DibujarTituloPersonalizado(asciiArt, gradiente, -5);
        }

        public static void MostrarTituloVentas()
        {
            string[] asciiArt = {
        "██╗   ██╗███████╗███╗   ██╗████████╗ █████╗ ███████╗",
        "██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔══██╗██╔════╝",
        "██║   ██║█████╗  ██╔██╗ ██║   ██║   ███████║███████╗",
        "╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║   ██╔══██║╚════██║",
        " ╚████╔╝ ███████╗██║ ╚████║   ██║   ██║  ██║███████║",
        "  ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝╚══════╝"
    };

            ConsoleColor[] gradiente = {
        ConsoleColor.DarkRed,
        ConsoleColor.Red,
        ConsoleColor.Yellow,
        ConsoleColor.White
    };

            DibujarTituloPersonalizado(asciiArt, gradiente, -3);
        }

        public static void MostrarTituloVendedores()
        {
            string[] asciiArt = {
        "██╗   ██╗███████╗███╗   ██╗██████╗ ███████╗██████╗ ███████╗███████╗",
        "██║   ██║██╔════╝████╗  ██║██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝",
        "██║   ██║█████╗  ██╔██╗ ██║██║  ██║█████╗  ██████╔╝█████╗  ███████╗",
        "╚██╗ ██╔╝██╔══╝  ██║╚██╗██║██║  ██║██╔══╝  ██╔══██╗██╔══╝  ╚════██║",
        " ╚████╔╝ ███████╗██║ ╚████║██████╔╝███████╗██║  ██║███████╗███████║",
        "  ╚═══╝  ╚══════╝╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝"
    };

            ConsoleColor[] gradiente = {
        ConsoleColor.DarkCyan,
        ConsoleColor.Cyan,
        ConsoleColor.White,
        ConsoleColor.Gray
    };

            DibujarTituloPersonalizado(asciiArt, gradiente, -5);
        }

    }
}
