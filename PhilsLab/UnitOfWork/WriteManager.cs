using System;
using System.Threading;

namespace PhilsLab.UnitOfWork
{
    public class WriteManager
    {
        public Random _rand = new Random();

        public enum T 
        {
            W,
            WL
        }

        public void W (string str)
        {
            Console.Write(str);
        }

        public void WL(string str = null)
        {
            Console.Write($"\n\r{str}");
        }

        public void S(int time)
        {
            if (time == 0)
                Thread.Sleep(int.MaxValue);

            Thread.Sleep(time);
        }

        public void C()
        {
            Console.Clear();
        }

        public void B(int freq = 0, int durat = 0)
        {
            if (freq == 0 || durat == 0)
                Console.Beep();
            else
                Console.Beep(freq, durat);
        }

        public void ConsoleType(string str, int speed, T type = T.W, bool randomise = true)
        {
            var stepTime = Convert.ToInt32(Math.Round((double)speed / (double)str.Length, 0));

            if (type == T.WL)
                W("\n\r");

            foreach (var character in str)
            {
                W(character.ToString());

                if (randomise)
                {
                    //var randomisedStep = Convert.ToInt32(stepTime * 1+((double)_rand.Next(0, 40)/100.0));
                    var randomisedStep = 1 - _rand.Next(20, 80)/100.0;

                    Thread.Sleep(Convert.ToInt32(stepTime * randomisedStep));
                }

                Thread.Sleep(stepTime);
            }
        }
    }
}
