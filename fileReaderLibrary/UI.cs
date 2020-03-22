using System;
using System.Collections.Generic;
using fileReaderLibrary.Enums;
namespace fileReaderLibrary
{
    public class UI
    {
        private string filePath;
        private FileExtension fileExtension;
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
                bool tryAgain = this.ErrorTryAgain("File does not exist.");
                if (tryAgain)
                {
                    this.AskFilePath();
                }
                else
                {
                    this.StopApplication();
                }
            }
        }
        private void AskExtension()
        {
            FileExtension extension;

            System.Console.WriteLine("Select extension: ");
            foreach (FileExtension option in Enum.GetValues(typeof(FileExtension)))
            {
                System.Console.WriteLine($"({ (int)option }) { option }");
            }

            string response = System.Console.ReadLine();
            Enum.TryParse(response, out extension);

            bool isValidFileExtension = FileValidator.IsValidFileExtension(extension);
            if (! isValidFileExtension)
            {
                bool tryAgain = this.ErrorTryAgain("Extension not recognized");
                if (tryAgain)
                {
                    this.AskExtension();
                    return;
                }
                bool startOver = this.StartOver();
                if (startOver)
                {
                    this.Reset();
                    this.AskUserInput();
                    return;
                }
                else
                {
                    this.StopApplication();
                }
            }
            bool isMatchingExtension = FileValidator.MatchFileFileExtension(this.filePath, extension);
            if (isMatchingExtension)
            {
                this.fileExtension = extension;
                return;
            }
            else
            {   
                bool tryAgain = this.ErrorTryAgain("File does not match extension");
                if (tryAgain)
                {
                    this.AskExtension();
                    return;
                }
                bool startOver = this.StartOver();
                if (startOver)
                {
                    this.Reset();
                    this.AskUserInput();
                    return;
                }
                else
                {
                    this.StopApplication();
                }
            }
        }
        private void Reset()
        {
            this.fileExtension = new FileExtension();
            this.filePath = "";
        }
        private void PrintError(string errorMessage)
        {
            System.Console.WriteLine("[ERROR]");
            System.Console.WriteLine(errorMessage);
        }
        private bool StartOver()
        {
            return this.AskYesNo("Start over?");
        }
        private bool TryAgain()
        {
            return this.AskYesNo("Try again");
        }
        private bool ErrorStartOver(string errorMessage)
        {
            this.PrintError(errorMessage);
            return this.StartOver();
        }
        private bool ErrorTryAgain(string errorMessage)
        {
            this.PrintError(errorMessage);
            return this.TryAgain();
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