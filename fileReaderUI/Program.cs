using System;
using fileReaderLibrary;

namespace fileReaderUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DecryptorFactory decryptorFactory = new DecryptorFactory();
            IDecryptor ApplicationDecryptor = decryptorFactory.CreateDecryptor();

            UI UserInterface = new UI();
            bool readAnotherFile = false;
            do
            {   
                // contains meta information about file and user
                Context ApplicationContext = new Context(ApplicationDecryptor);
                UserInterface.PopulateContext(ApplicationContext);
                               
                // handles opening file and displaying content to the console
                FileReader ApplicationFileReader = new FileReader(ApplicationContext);
                ApplicationFileReader.DisplayContent();

                // ask user if application should read another file
                readAnotherFile = UserInterface.AskReadAnotherFile();
            
            } while (readAnotherFile);

        }
    }
}
