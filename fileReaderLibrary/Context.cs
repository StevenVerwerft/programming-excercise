using System;
using fileReaderLibrary.Enums;

namespace fileReaderLibrary
{
    public class Context
    {
        public File File { get; set; }
        public IRole Role { get; set; }
        public IAuthorizer ApplicationAuthorizer { get; set; }
        public IDecryptor ApplicationDecryptor { get; set; }

        public Context(IDecryptor applicationDecryptor, IAuthorizer applicationAuthorizer)
        {
            this.ApplicationDecryptor = applicationDecryptor;
            this.ApplicationAuthorizer = applicationAuthorizer;
        }
    }
}