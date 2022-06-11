using PhilsLab.Dto.GameProgress;
using PhilsLab.Stages;
using PhilsLab.Stages.Legacy;

namespace PhilsLab.UnitOfWork
{
    public class StageManager
    {
        private static ProgressDto _progress;
        private AssetManager _assetManager;
        private WindowManager _windowManager;

        public StageManager(ProgressDto progress, AssetManager assetManager, WindowManager windowManager)
        {
            _progress = progress;
            _assetManager = assetManager;
            _windowManager = windowManager;
        }

        public void LetTheGameBegins(string[] args)
        {
            if (!_progress.Introduction.Completed)
            {
                _windowManager.Introduction();
                var stage = new Introduction(_progress, args, _assetManager);
                stage.Start();
            }

            if (_progress.Player.Stage == 1)
            {
                _windowManager.StageOne(_progress);
                var stage = new StageOne(_progress, args, _assetManager);
                stage.Start();
            }

            //Legacy stages
            if (_progress.Player.Stage == 888888)
            {
                _windowManager.AlphaStage();
                var stage = new AlphaStage(_progress, args, _assetManager);
                stage.Start();
            }
        }
    }
}
