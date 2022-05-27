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
            
        }
    }
}
