using System;
using System.Collections.Generic;

namespace fileReaderLibrary
{
    public class UI
    {
        private string filePath;
        private string fileExtension;
        private bool isEncrypted;
        public Context AskUserInput()
        {
            this.SetUserInput();
            return new Context(this.filePath, this.fileExtension);
        }
        private void SetUserInput()
        {
            this.AskFilePath();  // sets and validates filePath
            this.AskExtension();  // sets and validates fileExtension
            this.AskEncryption();  // sets and validates isEncrypted
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
            System.Console.WriteLine("(2) XML [.xml]");
            string response = System.Console.ReadLine();

            switch (response)
            {
                case "1":
                    fileExtension = ".txt";
                    break;
                case "2":
                    fileExtension = ".xml";
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

        private void AskEncryption()
        {
            bool isEncrypted;
            bool encryptionSupported;

            isEncrypted = this.AskYesNo("File encrypted?");
            
            // check if encrypted files are allowed for the given extension
            encryptionSupported = FileValidator.CheckEncryptionSupported(this.fileExtension);

            if (encryptionSupported)
            {
                this.isEncrypted = isEncrypted;
                return;
            }
            else
            {
                System.Console.WriteLine("[ERROR");
                System.Console.WriteLine($"Encryption not supported for file of type ({this.fileExtension}).");
                if (this.AskYesNo("Continue without encryption?"))
                {
                    this.isEncrypted = false;
                }
                else if (this.AskYesNo("New file?"))
                {
                    this.SetUserInput();
                }
                else
                {
                    this.StopApplication();
                }
            }
        }
        private bool AskYesNo(string question)
        {
            System.Console.WriteLine(question + " (y/n)");
            string response = System.Console.ReadLine().ToLower().Trim();

            bool isYes = (response == "y" | response == "yes");
            bool isNo = (response == "n" | response == "no");
            if (! (isYes | isNo))
            {
                System.Console.WriteLine("Unrecognized response.");
                System.Console.WriteLine("Closing application...");
                this.StopApplication();
            }
            return (response == "y" | response == "yes");
        }
        private void StopApplication()
        {
            System.Environment.Exit(1);
        }
    }
}