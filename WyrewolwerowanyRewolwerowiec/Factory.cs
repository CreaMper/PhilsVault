
using WyrewolwerowanyRewolwerowiec.UnitOfWork;

namespace WyrewolwerowanyRewolwerowiec
{
    public class Factory
    {
        public ProgressManager ProgressManager;
        public WindowManager WindowManager;

        public Factory()
        {
            ProgressManager = new ProgressManager();
            WindowManager = new WindowManager();
        }
    }
}
