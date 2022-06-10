using PhilsLab.Utils;

namespace PhilsLab.Dto
{
    public class ResourceDto
    {
        public string FileName { get; set; }
        public FileTypeEnum FileType { get; set; }
        public byte[] Data { get; set; }
    }
}
