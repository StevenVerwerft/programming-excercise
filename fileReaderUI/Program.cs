using System;
using fileReaderLibrary;

namespace fileReaderUI
{
    class Program
    {
        static void Main(string[] args)
        {

            // decryptor to use - can be replaced with more advanced decryptor
            IDecryptor ApplicationDecryptor = new ReverseDecryptor();

            // authorizer to use - grants read access to the available roles
            IAuthorizer ApplicationAuthorizer = new SimpleAuthorizer();

            // container for user input and available decryptor and authorizer
            Context ApplicationContext = new Context(ApplicationDecryptor, ApplicationAuthorizer);

            // user interface - puts user input into context
            // contains most of file validation: 
            // (valid file - valid & matching extension - decryption supported - role security supported - access right for role)
            UI UserInterface = new UI(ApplicationContext);
    
            bool readAnotherFile = false;
            do
            {   
                UserInterface.AddUserInfoToContext();

                // handles opening file and displaying content to the console
                FileReader ApplicationFileReader = new FileReader(ApplicationContext);
                ApplicationFileReader.DisplayContent();

                // ask user if application should read another file
                readAnotherFile = UserInterface.AskReadAnotherFile();
            
            } while (readAnotherFile);

        }
    }
}
