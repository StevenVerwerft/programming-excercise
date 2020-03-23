using System;
using fileReaderLibrary;

namespace fileReaderUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DecryptorFactory decryptorFactory = new DecryptorFactory();
            IDecryptor applicationDecryptor = decryptorFactory.CreateDecryptor();

            AuthorizerFactory authorizerFactory = new AuthorizerFactory();
            IAuthorizer applicationAuthorizer = authorizerFactory.CreateAuthorizer();

            Context applicationContext = new Context(applicationDecryptor, applicationAuthorizer);
            UI userInterface = new UI();

            bool readAnotherFile = false;
            do
            {   
                applicationContext = userInterface.AddUserInfoToContext(applicationContext);

                // handles opening file and displaying content to the console
                FileReader ApplicationFileReader = new FileReader(applicationContext);
                ApplicationFileReader.DisplayContent();

                // ask user if application should read another file
                readAnotherFile = userInterface.AskReadAnotherFile();
            
            } while (readAnotherFile);

        }
    }
}
