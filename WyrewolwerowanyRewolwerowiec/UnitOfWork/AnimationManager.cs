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

            for (int i = 0; i < 400; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < increment; k++)
                    {
                        W("#");
                    }
                    WL("");
                }
                increment++;
                B(37 * i, 1);
            }
        }
    }
}
