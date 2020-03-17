using System;

namespace fileReaderLibrary
{
    public class File
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }

        public File(string fileName)
        {
            string fileExtension = System.IO.Path.GetExtension(fileName);
            this.FileName = fileName;
            this.FileExtension = fileExtension;
        }

        public File(string fileName, string fileExtension)
        {
            this.FileName = fileName;
            this.FileExtension = fileExtension;
        }
    }
}