using System;
using System.Threading;

namespace PhilsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var mutex_id = "PhilsLab";
            using (Mutex mutex = new Mutex(false, mutex_id))
            {
                if (!mutex.WaitOne(0, false))
                    Environment.Exit(0);
                Console.WriteLine("Loading data...");
                var factory = new Factory();
                try
                {
                    factory.WindowManager.Initialise();
                    factory.StageManager.LetTheGameBegins(args);
                }
                catch (Exception ex)
                {
                    Console.Write("There is a problem, I can not run myself! I got an exception!");
                }
            }
        }
    }
}
