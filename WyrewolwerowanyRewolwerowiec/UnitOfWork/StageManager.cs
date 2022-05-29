using System.Runtime.Versioning;
using PhilsLab.Dto.GameProgress;
using PhilsLab.Stages;

namespace PhilsLab.UnitOfWork
{
    [SupportedOSPlatform("windows")]
    public class StageManager
    {
        private static ProgressDto _progress;

        public StageManager(ProgressDto progress)
        {
            _progress = progress;
        }

        public void LetTheGameBegins(string[] args)
        {
            if (_progress.Player.Stage == 1)
            {
                var stage = new AlphaStage(_progress, args);
                stage.Start();
            }
        }
    }
}
