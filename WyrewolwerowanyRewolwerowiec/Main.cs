using System;

namespace WyrewolwerowanyRewolwerowiec
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game factory load
            var factory = new Factory();

            //Game progress load
            var progress = factory.ProgressManager.Load();

            //Console initalisation
            factory.WindowManager.Initialise(progress);

            //Stage
            Console.WriteLine("asdasd");
        }
    }
}
