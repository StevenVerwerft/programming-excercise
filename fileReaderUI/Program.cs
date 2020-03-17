using System;
using fileReaderLibrary;

namespace fileReaderUI
{
    class Program
    {

        static void Main(string[] args)
        {

            UI UserInterface = new UI();
            bool readAnotherFile = false;
            do
            {
                UserInterface.AskUserInput();
                System.Console.WriteLine("simulating read this file...");
                readAnotherFile = UserInterface.AskReadAnotherFile();
            } while (readAnotherFile);

        }
    }
}
