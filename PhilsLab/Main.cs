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
            var mutex_id = "PhilsLab";
            using (Mutex mutex = new Mutex(false, mutex_id))
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
                    Console.Write($"There is a problem, I can not run myself! I got an exception! {ex.Message}");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
