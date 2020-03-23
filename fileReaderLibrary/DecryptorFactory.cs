using System;

namespace fileReaderLibrary
{
    public interface IDecryptorFactory
    {
        IDecryptor CreateDecryptor();
    }
    public class DecryptorFactory : IDecryptorFactory
    {
        public IDecryptor CreateDecryptor()
        {
            return new ReverseDecryptor();
        }
    }
}