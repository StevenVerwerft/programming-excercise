using System;
using fileReaderLibrary;

namespace fileReaderUI
{
    class Program
    {
        static void Main(string[] args)
        {

            UI UserInterface = new UI();
            IDecryptor ApplicationDecryptor = new ReverseDecryptor();
            IAuthorizer ApplicationAuthorizer = new SimpleAuthorizer();
            bool readAnotherFile = false;
            do
            {   
                // contains meta information about file and user
                Context ApplicationContext = new Context(ApplicationDecryptor, ApplicationAuthorizer);
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
