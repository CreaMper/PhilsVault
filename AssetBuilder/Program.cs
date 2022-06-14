using System;
using System.Linq;

namespace AssetBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var packEngine = new Pack();

            if (args.Contains("instant"))
            {
                packEngine.PackAssests(true);
            }
            else 
            {
                WL("Phil's Lab assets builder!");
                WL(@"[P] - Pack files at *\Assets directory to binary");
                var key = Console.ReadKey(true);

                Console.WriteLine("=================");
                if (key.Key == ConsoleKey.P)
                {
                    packEngine.PackAssests();
                }
                else
                {
                    WL("Wrong option!");
                    Console.ReadKey(false);
                }
            }
        }

        private static void WL(string str)
        {
            Console.WriteLine(str);
        }
    }
}
