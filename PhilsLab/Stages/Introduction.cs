using PhilsLab.Dto.GameProgress;
using PhilsLab.UnitOfWork;
using System;

namespace PhilsLab.Stages
{
    public class Introduction : WriteManager
    {
        private static ProgressDto _progress;
        private static Factory _factory;
        private readonly string[] _args;

        public Introduction(ProgressDto progress, string[] args, AssetManager assetManager)
        {
            _progress = progress;
            _factory = new Factory();
            _args = args;
            _soundManager = new SoundManager(assetManager);
            C();
        }

        public void Start()
        {
            _soundManager.Play("intro.wav");

            for (int i = 0; i < 1000; i++)
            {
                W("test?");
                S(1000);
            }

            Console.ReadKey();
        }
    }
}
