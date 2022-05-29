using System;
using System.Threading;
using System.Security.Principal;

namespace PhilsLab
{
    class Program
    {
        static bool Admin => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        static readonly int _maxSleep = int.MaxValue;

        static void Main(string[] args)
        {
            if (!Admin)
            {
                Console.WriteLine("Hi! Sorry to bother you, but before we start I do need to be started with admin privilages!");
                Thread.Sleep(_maxSleep);
            }

            var factory = new Factory();

            factory.WindowManager.Initialise();
            factory.StageManager.LetTheGameBegins(args);
        }
    }
}
