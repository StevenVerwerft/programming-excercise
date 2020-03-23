using System;

namespace fileReaderLibrary
{
    public class DecryptorFactory
    {
        public IDecryptor CreateDecryptor()
        {
            return new ReverseDecryptor();
        }
    }
}