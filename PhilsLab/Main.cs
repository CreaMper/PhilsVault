using PhilsVault.Dto.GameProgress;
using PhilsVault.Managers;
using System;
using System.Threading;

namespace PhilsVault
{
    class Program
    {
        static void Main(string[] args)
        {
            var mutex_id = "Phil's Vault";
            using (var mutex = new Mutex(false, mutex_id))
            {
                if (!mutex.WaitOne(0, false))
                    Environment.Exit(0);

                //Quick window initialize to avoid graphical bugs
                var windowManager = new WindowManager(new ProgressDto());

                try
                {
                    var factory = new Factory();
                    factory.StageManager.LetTheGameBegins(args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"[Real exception] Something went wrong.... :  {ex.Message}");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
