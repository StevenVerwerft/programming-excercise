using System;
using fileReaderLibrary.Enums;

namespace fileReaderLibrary
{
    public class Context
    {
        public File File { get; set; }
        public IDecryptor ApplicationDecryptor { get; set; }

        public Context(string fileName, FileExtension fileExtension, bool isEncrypted)

        {
            this.File = new File(fileName, fileExtension, isEncrypted);
        }
        
        public Context(IDecryptor applicationDecryptor)
        {
            this.ApplicationDecryptor = applicationDecryptor;
        }
    }
}