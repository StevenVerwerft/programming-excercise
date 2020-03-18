using System;

namespace fileReaderLibrary
{
    interface IDecryptor
    {
        string Decrypt(string fileContent);
    }

    public class ReverseDecryptor : IDecryptor
    {
        public string Decrypt(string encryptedFileContent)
        {
            char[] decryptedContent = encryptedFileContent.ToCharArray();
            Array.Reverse(decryptedContent);
            return new string(decryptedContent);
        }
    }
}