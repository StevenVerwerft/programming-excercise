using System;
using System.Collections.Generic;

namespace fileReaderLibrary
{
    public class UI
    {

        public void AskUserInput()
        {
            string filePath = this.AskFilePath();
            string fileExtension = this.AskExtension(filePath);
        }
        public bool AskReadAnotherFile()
        {
            return this.AskYesNo("Read another file?");
        }

        private string AskFilePath()
        {
            bool isValidFile;
            string filePath;

            System.Console.WriteLine("File path: ");
            filePath = System.Console.ReadLine();
            isValidFile = FileValidator.CheckFileExists(filePath);

            // begin recursion
            if ( isValidFile)
            {
                return filePath;
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
                return this.AskFilePath();
            }
        }

        private string AskExtension(string filePath)
        {
            bool isSupportedExtension;
            bool isMatchingExtension;
            string fileExtension;

            System.Console.WriteLine("Extension: ");
            fileExtension = System.Console.ReadLine();

            // validate the extension
            isSupportedExtension = FileValidator.CheckTypeSupported(fileExtension);
            isMatchingExtension = FileValidator.MatchFileFileExtension(filePath, fileExtension);

            // base case recursion
            if (isSupportedExtension & isMatchingExtension)
            {
                return fileExtension;
            }
            else
            {   
                System.Console.WriteLine($"[Error]");
                if (! isSupportedExtension)
                {
                    System.Console.WriteLine($"Application does not support {fileExtension}.");
                }
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
                    filePath = this.AskFilePath();
                }
                return this.AskExtension(filePath);
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