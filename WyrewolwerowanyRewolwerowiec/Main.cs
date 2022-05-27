using System;
using System.Runtime.Versioning;
using System.Threading;
using System.Security.Principal;

namespace WyrewolwerowanyRewolwerowiec
{
    [SupportedOSPlatform("windows")]
    class Program
    {
        static bool _admin => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        static void Main(string[] args)
        {
            //Check for admin
            if (!_admin)
            {
                Console.WriteLine("Hi! Sorry to bother you, but before we start I do need to be started with admin privilages!");
                Thread.Sleep(100000);
                Environment.Exit(0);
            }

            //Game factory load
            var factory = new Factory();

            //Console initalisation
            factory.WindowManager.Initialise();

            //Stage selection
            factory.StageManager.LetTheGameBegins();
            Thread.Sleep(100000);

        }
    }
}
