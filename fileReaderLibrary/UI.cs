using System;
using System.Collections.Generic;

namespace fileReaderLibrary
{
    public class UI
    {
        private string filePath;
        private string fileExtension;
        public Context AskUserInput()
        {
            this.AskFilePath();  // sets and validates filePath
            this.AskExtension();  // sets and validates fileExtension

            return new Context(this.filePath, this.fileExtension);
        }
        public bool AskReadAnotherFile()
        {
            return this.AskYesNo("Read another file?");
        }
        private void AskFilePath()
        {
            bool isValidFile;
            string filePath;

            System.Console.WriteLine("File path: ");
            filePath = System.Console.ReadLine();
            isValidFile = FileValidator.CheckFileExists(filePath);

            if ( isValidFile)
            {
                this.filePath = filePath;
                return;
            }
            else
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"[Error]");
                System.Console.WriteLine("File does not exist");
                if (! this.AskYesNo("Try another file? "))
                {
                    this.StopApplication();
                }
                this.AskFilePath();
            }
        }
        private void AskExtension()
        {
            bool isMatchingExtension;
            string fileExtension;

            System.Console.WriteLine("Select extension: ");
            System.Console.WriteLine("(1) TXT [.txt]");
            string response = System.Console.ReadLine();

            switch (response)
            {
                case "1":
                    fileExtension = ".txt";
                    break;
                default:
                    System.Console.WriteLine();
                    System.Console.WriteLine("[Error]");
                    System.Console.WriteLine("Invalid Choice.");
                    if (! this.AskYesNo("Choose Again?"))
                    {
                        this.StopApplication();
                    }
                    this.AskExtension();
                    return; 
            }
            // validate the extension
            isMatchingExtension = FileValidator.MatchFileFileExtension(this.filePath, fileExtension);

            if (isMatchingExtension)
            {
                this.fileExtension = fileExtension;
                return;
            }
            else
            {   
                System.Console.WriteLine($"[Error]");
                if (! isMatchingExtension)
                {
                    System.Console.WriteLine($"File type does not match given extension {fileExtension}");
                }
                if (! this.AskYesNo("Try again? "))
                {
                    this.StopApplication();
                }
                if (this.AskYesNo("New file? "))
                {
                    this.AskFilePath();
                }
                this.AskExtension();
            }
        }
        private bool AskYesNo(string question)
        {
            System.Console.WriteLine(question + " (y/n)");
            string response = System.Console.ReadLine().ToLower().Trim();
            return (response == "y" | response == "yes");
        }
        private void StopApplication()
        {
            System.Environment.Exit(1);
        }
    }
}