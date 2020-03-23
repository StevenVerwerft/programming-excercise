using System;
using fileReaderLibrary.Enums;
namespace fileReaderLibrary
{
    public class File
    {
        public string FileName { get; set; }
        public FileExtension FileExtension { get; set; }

        public File(string fileName, FileExtension fileExtension)
        {
            this.FileName = fileName;
            this.FileExtension = fileExtension;
        }
    }
}