using WyrewolwerowanyRewolwerowiec.Dto.GameProgress;
using WyrewolwerowanyRewolwerowiec.UnitOfWork;

namespace WyrewolwerowanyRewolwerowiec.Stages
{
    public class AlphaStage : WriteManager
    {
        private static ProgressDto _progress;
        
        public AlphaStage(ProgressDto progress)
        {
            _progress = progress;
        }

        public void Start()
        {

        }
    }
}
