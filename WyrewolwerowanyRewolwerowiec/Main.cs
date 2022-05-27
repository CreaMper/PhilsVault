using System;
using System.Runtime.Versioning;
using System.Threading;

namespace WyrewolwerowanyRewolwerowiec
{
    [SupportedOSPlatform("windows")]
    class Program
    {
        static void Main(string[] args)
        {
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
