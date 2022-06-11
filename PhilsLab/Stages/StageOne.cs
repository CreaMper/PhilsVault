using PhilsLab.Dto.GameProgress;
using PhilsLab.UnitOfWork;
using System;

namespace PhilsLab.Stages
{
    public class StageOne :WriteManager
    {
        private static ProgressDto _progress;
        private static Factory _factory;
        private readonly string[] _args;

        public StageOne(ProgressDto progress, string[] args, AssetManager assetManager)
        {
            _progress = progress;
            _factory = new Factory();
            _args = args;
            _soundManager = new SoundManager(assetManager);
        }

        public void Start()
        {
            if (!_progress.StageOne.LoginPhase)
            {
                WL("It works!");
                FlushRead();
                Console.ReadKey(false);
            }
        }
    }
}
