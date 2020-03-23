using System;
using System.Collections.Generic;
using fileReaderLibrary.Enums;
namespace fileReaderLibrary
{
    public class UI
    {
        private bool startOver;
        public Context PopulateContext(Context applicationContext)
        {
            string filePath = "";
            FileExtension fileExtension = 0;
            bool isEncrypted = false;

            do
            {
                this.startOver = false;

                filePath = this.AskFilePath();
                if (this.startOver) continue;

                fileExtension = this.AskExtension(filePath);
                if (this.startOver) continue;

                isEncrypted = this.AskEncryption(fileExtension);
                if (this.startOver) continue;

            } while (this.startOver);

            File file = new File(filePath, fileExtension, isEncrypted);
            applicationContext.File = file;
            return applicationContext;
        }
        public bool AskReadAnotherFile()
        {
            return this.AskYesNo("Read another file?");
        }
        private string AskFilePath()
        {
            bool isExistingFile = false;
            bool tryAgain = false;
            bool startOver = false;
            string filePath= "";


            do
            {
                System.Console.WriteLine("File path: ");
                string response = System.Console.ReadLine();
                isExistingFile = FileValidator.CheckFileExists(response);

                if (isExistingFile)
                {
                    filePath = response;
                    break;
                }
                else
                {
                    tryAgain = this.AskErrorTryAgain("File does not exist.");
                    if (! tryAgain)
                    {
                        startOver = this.AskStartOver();
                        if (startOver)
                        {
                            this.startOver = true;
                            return filePath;
                        }
                        else
                        {
                            this.StopApplication();
                        }
                    }
                }
                
            } while (tryAgain);
            return filePath;
        }
        private FileExtension AskExtension(string filePath)
        {
            FileExtension extension;
            bool tryAgain = false;
            bool startOver = false;
            bool isMatchingExtension = false;
            bool isValidExtension = false;

            do
            {   
                tryAgain = false;
                System.Console.WriteLine("Select extension: ");
                foreach (FileExtension option in Enum.GetValues(typeof(FileExtension)))
                {
                    System.Console.WriteLine($"({ (int)option }) { option }");
                }
                string response = System.Console.ReadLine();
                Enum.TryParse(response, out extension);

                isValidExtension = FileValidator.IsValidFileExtension(extension);
                if (! isValidExtension)
                {
                    tryAgain = this.AskErrorTryAgain("Unrecognized file extension.");
                    if (tryAgain)
                    {
                        continue;
                    }
                    else
                    {
                        startOver = this.AskStartOver();
                        if (startOver)
                        {
                            this.startOver = true;
                            return extension;
                        }
                        else
                        {
                            this.StopApplication();
                        }
                    }
                }

                isMatchingExtension = FileValidator.MatchFileFileExtension(filePath, extension);
                if (isMatchingExtension)
                {
                    break;
                }
                else
                {
                    tryAgain = this.AskErrorTryAgain("File extension does not match file.");
                    if (tryAgain)
                    {
                        continue;
                    }
                    else
                    {
                        startOver = this.AskStartOver();
                        if (startOver)
                        {
                            this.startOver = true;
                            return extension;
                        }
                        else
                        {
                            this.StopApplication();
                        }
                    }
                }

            } while (tryAgain);
            return extension;
        }
        private bool AskEncryption(FileExtension fileExtension)
        {

            bool isEncrypted = false;
            bool encryptionSupported = false;
            bool tryAgain = false;
            bool startOver = false;

            do
            {
                tryAgain = false;
                isEncrypted = this.AskYesNo("File encrypted?");
                if (!isEncrypted)
                {
                    break;
                }
                else
                {
                    encryptionSupported = FileValidator.CheckEncryptionSupported(fileExtension);
                    if (encryptionSupported)
                    {
                        break;
                    }
                    else
                    {
                        tryAgain = this.AskErrorTryAgain($"Encryption not supported for files of type {fileExtension}");
                        if (tryAgain)
                        {
                            continue;
                        }
                        else
                        {
                            startOver = this.AskStartOver();
                            if (startOver)
                            {
                                this.startOver = true;
                                return isEncrypted;
                            }
                            else
                            {
                                this.StopApplication();
                            }
                        }
                    }
                }
            } while (tryAgain);
            return isEncrypted;
        }
        private void PrintError(string errorMessage)
        {
            System.Console.WriteLine("[ERROR]");
            System.Console.WriteLine(errorMessage);
        }
        private bool AskStartOver()
        {
            return this.AskYesNo("Start over?");
        }
        private bool AskTryAgain()
        {
            return this.AskYesNo("Try again");
        }
        private bool AskErrorStartOver(string errorMessage)
        {
            this.PrintError(errorMessage);
            return this.AskStartOver();
        }
        private bool AskErrorTryAgain(string errorMessage)
        {
            this.PrintError(errorMessage);
            return this.AskTryAgain();
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