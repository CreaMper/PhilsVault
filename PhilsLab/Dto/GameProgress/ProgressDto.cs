namespace PhilsVault.Dto.GameProgress
{
    public class ProgressDto
    {
        public PlayerDataDto Player { get; set; }
        public SettingsDto Settings { get; set; }
        public IntroductionDto Introduction { get; set; }
        public AlphaDto Alpha { get; set; }

        //Stages
        public StageOneDto StageOne { get; set; }
    }
}
