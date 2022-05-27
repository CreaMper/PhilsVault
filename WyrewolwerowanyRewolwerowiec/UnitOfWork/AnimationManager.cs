using System;
using WyrewolwerowanyRewolwerowiec.Utils;

namespace WyrewolwerowanyRewolwerowiec.UnitOfWork
{
    public class AnimationManager : WriteManager
    {

        public void Animate(AnimationType type)
        {
            if (type == AnimationType.FirstLaunch)
                FirstLaunch();
        }

        private void FirstLaunch()
        {
            var increment = 0;
            var tittleString = string.Empty;

            for (int i = 0; i < 400; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < increment; k++)
                        W("#");

                    WL("");
                }
                
                double flt = _rand.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                tittleString += Convert.ToChar(shift + 65);

                if (i % 60 == 0)
                    tittleString = string.Empty;

                Console.Title = tittleString;
                increment++;

                B(37 * i, 1);
            }
        }
    }
}
