using System;

namespace fileReaderLibrary
{
    public class Context
    {
        public File File { get; set; }
        public IRole Role { get; set; }
        public IDecryptor ApplicationDecryptor { get; set; }
        public IAuthorizer ApplicationAuthorizer { get; set; }
        public Context(string fileName, string fileExtension, bool isEncrypted, bool isRoleBaseSecured)
        {
            this.File = new File(fileName, fileExtension, isEncrypted, isRoleBaseSecured);
        }
        
        public Context(IDecryptor applicationDecryptor, IAuthorizer applicationAuthorizer)
        {
            this.ApplicationDecryptor = applicationDecryptor;
            this.ApplicationAuthorizer = applicationAuthorizer;
        }
    }
}