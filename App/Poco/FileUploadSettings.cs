namespace App.Poco
{
    public class FileUploadSettings
    {
        public int MaxSize { get; set; }
        public List<string>? FileType { get; set; }
    }
}