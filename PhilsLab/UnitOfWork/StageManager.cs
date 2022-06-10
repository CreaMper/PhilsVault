using PhilsLab.Dto.GameProgress;
using PhilsLab.Stages;

namespace PhilsLab.UnitOfWork
{
    public class StageManager
    {
        private static ProgressDto _progress;
        private AssetManager _assetManager;
        public StageManager(ProgressDto progress, AssetManager assetManager)
        {
            _progress = progress;
            _assetManager = assetManager;
        }

        public void LetTheGameBegins(string[] args)
        {
            if (_progress.Player.Stage == 1)
            {
                var stage = new AlphaStage(_progress, args, _assetManager);
                stage.Start();
            }
        }
    }
}
