using System;

namespace AssetBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Phil's Lab assets builder!");
            Console.WriteLine("[P] - Pack files at *\\Assets directory to binary");
            Console.WriteLine("[U] - Unpack files at *\\Assets directory");
            var key = Console.ReadKey(true);

            Console.WriteLine("=================");
            if (key.Key == ConsoleKey.P)
            {
                var packEngine = new Pack();
                packEngine.PackAssests();
            }
            else if (key.Key == ConsoleKey.U)
            {

            }
            else
            {
                Console.WriteLine("Wrong option!");
            }

            Console.ReadKey(false);
        }
    }
}
