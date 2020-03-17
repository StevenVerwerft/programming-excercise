using System;
using System.Collections.Generic;

namespace fileReaderLibrary
{
    public class UI
    {
        public void AskUserInput()
        {
            string filePath = this.AskFilePath();
            string fileExtension = this.AskFileExtension();
        }

        public bool AskReadAnotherFile()
        {
            return this.AskYesNo("Read another file?");
        }
        private string AskFilePath()
        {
            // todo: check if works on windows...
            string filePath;
            bool fileExists = false;
            do
            {
                System.Console.WriteLine("path to file:");
                filePath = System.Console.ReadLine();
                fileExists = this.CheckFileExists(filePath);
                if (! fileExists)
                {
                    System.Console.WriteLine("File does not exist");
                    this.AskTryAgain();
                }
            } while (! this.CheckFileExists(filePath));
            
            return filePath;
        }

        private string AskFileExtension()
        {
            string fileExtension;
            System.Console.WriteLine("file extension:");
            fileExtension = System.Console.ReadLine();
            return fileExtension;
        }
        private bool AskYesNo(string question)
        {
            System.Console.WriteLine(question + " (y/n)");
            string response = System.Console.ReadLine().ToLower().Trim();
            return (response == "y" | response == "yes");
        }

        private bool CheckFileExists(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }

        private void AskTryAgain()
        {
            System.Console.WriteLine("Try Again? (y/n)");
            string response = System.Console.ReadLine().ToLower().Trim();
            if (response == "n" | response == "no")
            {
                System.Environment.Exit(1);
            }
        }

        private void AskToContinue()
        {
            System.Console.WriteLine("continue? (y/n)");
            string response = System.Console.ReadLine().ToLower().Trim();
            if (response == "n" | response == "no")
            {
                System.Environment.Exit(1);
            }

        }
    }
}