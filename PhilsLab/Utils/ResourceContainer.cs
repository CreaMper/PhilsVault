using System.Collections.Generic;

namespace PhilsLab.Utils
{
    public class ResourceContainer
    {
        public List<string> _resources;

        public ResourceContainer()
        {
            _resources = new List<string>()
            {
                //Icons
                "skull.ico",

                //Sounds
                "bigBlack.wav",
                "error.wav",
                "type.wav",
                "intro.wav"
            };
        }
    }
}
