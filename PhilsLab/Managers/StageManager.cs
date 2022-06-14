using PhilsVault.Dto.GameProgress;
using PhilsVault.Stages;
using System;

namespace PhilsVault.Managers
{
    public class StageManager
    {
        private static ProgressDto _progress;
        private readonly AssetManager _assetManager;
        private readonly WindowManager _windowManager;

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
                var stage = new Introduction(_assetManager, _progress);
                stage.Start();
            }

            if (_progress.Player.Stage == 1)
            {
                _windowManager.StageOne(_progress);
                var stage = new StageOne(_progress, args, _assetManager);
                stage.Start();
            }

            Console.Clear();
            Console.WriteLine("There is not more content! Thanks for playing, for now... :)");
            Console.ReadKey();
        }
    }
}
