using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DVD_screen_saver
{
    class Program
    {
        //gets an x coordinate to start draw dvd logo line and the number of dvd logo line to draw
        //puts vertical pole and spaces before and after
        public static void RenderDVDLine(int horizontal_start, string dvdlogoline)
        {
            string last_spacer = "";
            string first_spacer = new string(' ', horizontal_start);
            first_spacer = "║" + first_spacer + dvdlogoline;
            //handles case where the left side of the logo is next to the right border
            //if won't be presented we'll get an out of bounds error
            if (horizontal_start == 57)
            {
                last_spacer = new string(' ', (82 - first_spacer.Length));
                if (last_spacer.Length != 0)
                {
                    last_spacer = last_spacer.Substring(0, last_spacer.Length - 1);
                }

            }
            else
            {
                last_spacer = new string(' ', (82 - first_spacer.Length - 1));
            }

            first_spacer = first_spacer + last_spacer + "║";
            Console.WriteLine(first_spacer);
        }
        //renders the whole image, calling 'RenderDVDLine' in order to draw the logo itself inside the matrix
        //checks the y and than passes the x
        public static void Render(int x, int y)
        {
            //global variables borders
            string UPPER_BORDER = "╔════════════════════════════════════════════════════════════════════════════════╗";//length 82
            string BUTTOM_BORDER = "╚════════════════════════════════════════════════════════════════════════════════╝";//length 82
            string EMPTY_ROW = "║                                                                                ║";//length 82

            //initial DVD logo
            string[] dvdmatrix = new string[4];
            dvdmatrix[0] = "8888b. Yb    dP 8888b.";
            dvdmatrix[1] = "8I   Yb Yb  dP  8I   Yb";
            dvdmatrix[2] = "8I   dY  YbdP   8I   dY";
            dvdmatrix[3] = "8888Y\"    YP    8888Y\"";


            Console.WriteLine(UPPER_BORDER);
            for (int i = 0; i < 25; i++)
            {
                if (i == y)
                {
                    RenderDVDLine(x, dvdmatrix[0]);
                    continue;
                }
                if (i == y + 1)
                {
                    RenderDVDLine(x, dvdmatrix[1]);
                    continue;
                }
                if (i == y + 2)
                {
                    RenderDVDLine(x, dvdmatrix[2]);
                    continue;
                }
                if (i == y + 3)
                {
                    RenderDVDLine(x, dvdmatrix[3]);
                    continue;
                }
                else
                {
                    Console.WriteLine(EMPTY_ROW);
                }

            }
            Console.WriteLine(BUTTOM_BORDER);
            Console.WriteLine("meister 13/3/2023");

        }
        public static int Random1orMinus1()
        {
            Random rnd = new Random();
            if (rnd.Next(2) == 1)
            {
                return (1);
            }
            else
            {
                return (-1);
            }
        }
        //an infinity loop which on each iteration calls the render function with different coordinates
        //also incharge on rendering responsibly without getting out of bounds
        public static void DVD_movment()
        {
            Random RandomColor = new Random();

            ConsoleColor[] colors = new ConsoleColor[]
            {
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkMagenta,
                ConsoleColor.DarkYellow,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Red,
                ConsoleColor.Magenta,
                ConsoleColor.Yellow,
            };
            Random rndStartLocation = new Random();
            //x is 0-57
            //y is 0-21
            int x = rndStartLocation.Next(0, 58);
            int y = rndStartLocation.Next(0, 22);
            int dir_x = Random1orMinus1();
            int dir_y = Random1orMinus1();
            while (true)
            {
                Render(x, y);
                Thread.Sleep(55);
                Console.Clear();
                if (x == 57 || x == 0) { dir_x *= -1; Console.ForegroundColor = colors[RandomColor.Next(colors.Length)]; }
                if (y == 0 || y == 21) { dir_y *= -1; Console.ForegroundColor = colors[RandomColor.Next(colors.Length)]; }

                x += dir_x;
                y += dir_y;
            }

        }
        static void Main(string[] args)
        {
            DVD_movment();
        }

    }
}

