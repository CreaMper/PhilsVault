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
                "error01.wav",
                "error02.wav",
                "type01.wav",
                "intro.wav",
                "access_deined.wav",
                "access_granted.wav",
                "lab_alarm.wav",

                //StageOne
                "phoenixFile_doc.jpg",
                "phoenixFile_log.txt",
                "phill_is_dead.wav",
                "25042022.rar"
            };
        }
    }
}
