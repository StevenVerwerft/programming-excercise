using System;

namespace fileReaderLibrary
{
    public class Context
    {
        public File File { get; set; }
        public IDecryptor ApplicationDecryptor { get; set; }

        public Context(string fileName, string fileExtension, bool isEncrypted)
        {
            this.File = new File(fileName, fileExtension, isEncrypted);
        }
        
        public Context(IDecryptor applicationDecryptor)
        {
            this.ApplicationDecryptor = applicationDecryptor;
        }
    }
}