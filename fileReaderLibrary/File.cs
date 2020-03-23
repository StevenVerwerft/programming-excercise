using System;
using fileReaderLibrary.Enums;
namespace fileReaderLibrary
{
    public class File
    {
        public string FileName { get; set; }
        public FileExtension FileExtension { get; set; }
        public bool IsEncrypted { get; set; }
        public File(string fileName, FileExtension fileExtension, bool isEncrypted)
        {
            this.FileName = fileName;
            this.FileExtension = fileExtension;
            this.IsEncrypted = isEncrypted;
        }
    }
}