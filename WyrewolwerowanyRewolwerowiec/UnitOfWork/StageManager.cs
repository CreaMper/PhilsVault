using WyrewolwerowanyRewolwerowiec.Dto.GameProgress;
using WyrewolwerowanyRewolwerowiec.Stages;

namespace WyrewolwerowanyRewolwerowiec.UnitOfWork
{
    public class StageManager
    {
        private static ProgressDto _progress;

        public StageManager(ProgressDto progress)
        {
            _progress = progress;
        }

        public void LetTheGameBegins()
        {
            if (_progress.Player.Stage == 1)
            {
                var stage = new AlphaStage(_progress);
                stage.Start();
            }
        }
    }
}
