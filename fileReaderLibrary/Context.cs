using System;

namespace fileReaderLibrary
{
    public class Context
    {
        public File File { get; set; }

        public Context(string fileName, string fileExtension)
        {
            this.File = new File(fileName, fileExtension);
        }
        
    }
}