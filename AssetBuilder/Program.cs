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
                Console.WriteLine("Phil's Lab assets builder!");
                Console.WriteLine("[P] - Pack files at *\\Assets directory to binary");
                var key = Console.ReadKey(true);

                Console.WriteLine("=================");
                if (key.Key == ConsoleKey.P)
                {
                    packEngine.PackAssests();
                }
                else
                {
                    Console.WriteLine("Wrong option!");
                    Console.ReadKey(false);
                }
            }
        }
    }
}
