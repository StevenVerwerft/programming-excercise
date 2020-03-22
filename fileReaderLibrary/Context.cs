using System;
using fileReaderLibrary.Enums;

namespace fileReaderLibrary
{
    public class Context
    {
        public File File { get; set; }

        public Context(string fileName, FileExtension fileExtension)
        {
            this.File = new File(fileName, fileExtension);
        }
        
    }
}