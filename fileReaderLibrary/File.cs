using System;

namespace fileReaderLibrary
{
    public class File
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public bool IsEncrypted { get; set; }
        public File(string fileName, string fileExtension, bool isEncrypted)
        {
            this.FileName = fileName;
            this.FileExtension = fileExtension;
            this.IsEncrypted = isEncrypted;
        }
    }
}