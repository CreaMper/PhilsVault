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

                var factory = new Factory();

                factory.WindowManager.Initialise();
                factory.StageManager.LetTheGameBegins(args);
            }
        }
    }
}
