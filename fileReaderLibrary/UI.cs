using System;
using System.Collections.Generic;
using fileReaderLibrary.Enums;
namespace fileReaderLibrary
{
    public class UI
    {

        private bool startOver;
        public Context AddUserInfoToContext(Context applicationContext)
        {
            string filePath = null;
            FileExtension fileExtension = 0;
            bool isEncrypted = false;
            bool isRoleSecured = false;
            IRole role = null;
            File file = null;
            do
            {
                this.startOver = false;

                filePath = this.AskFilePath();
                if (this.startOver) continue;

                fileExtension = this.AskExtension(filePath);
                if (this.startOver) continue;

                isEncrypted = this.AskEncryption(fileExtension);
                if (this.startOver) continue;

                isRoleSecured = this.AskRoleBasedSecurity(fileExtension);
                if (this.startOver) continue;

                file = new File(filePath, fileExtension, isEncrypted, isRoleSecured);
                role = this.AskRole(applicationContext.ApplicationAuthorizer, file);
                if (this.startOver) continue;


            } while (this.startOver);

            applicationContext.File = file;
            applicationContext.Role = role;

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
            string filePath= null;


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

        private bool AskRoleBasedSecurity(FileExtension fileExtension)
        {   
            bool isRoleSecured = false;
            bool roleBaseSecuritySupported = false;
            bool tryAgain = false;
            bool startOver = false;

            do
            {
                tryAgain = false;
                isRoleSecured = this.AskYesNo("Use role base security?");
                if (isRoleSecured)
                {
                    roleBaseSecuritySupported = FileValidator.CheckRoleBasedSecuritySupported(fileExtension);
                    if (roleBaseSecuritySupported)
                    {
                        break;
                    }
                    else
                    {
                        tryAgain = this.AskErrorTryAgain($"Role base security not supported for files of type {fileExtension}");
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
                                return isRoleSecured;
                            }
                        }
                    }
                }
            } while (tryAgain);
            return isRoleSecured;
        }

        private IRole AskRole(IAuthorizer authorizer, File file)
        {   
            bool tryAgain = false;
            bool startOver = false;
            bool roleHasAccess = false;
            bool isValidRole = false;
            IRole role = null;

            if (! file.IsRoleBaseSecured)
            {
                return null;
            }
            do
            {
                System.Console.WriteLine("Choose a role:");
                int i = 0;
                foreach (IRole accessRole in authorizer.AvailableRoles)
                {
                    System.Console.WriteLine($"({i + 1}) {accessRole.RoleName}");
                    i++;
                }
                string response = System.Console.ReadLine();
                short roleID;
                Int16.TryParse(response, out roleID);
                roleID -= 1;  // index in list container start at 0
                isValidRole = FileValidator.IsValidRole(authorizer, roleID);

                if (isValidRole)
                {
                    role = authorizer.AvailableRoles[roleID];
                    roleHasAccess = authorizer.HasReadAccess(file.FileName, role);
                    if (roleHasAccess)
                    {
                        break;
                    }
                    else
                    {
                        tryAgain = this.AskErrorTryAgain($"{role.RoleName} does not have read access to file {file.FileName}.");
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
                                return null;
                            }
                            else
                            {
                                this.StopApplication();
                            }
                        }
                    }
                }
                else
                {
                    tryAgain = this.AskErrorTryAgain($"Unknown role chosen.");
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
                            return null;
                        }
                        else
                        {
                            this.StopApplication();
                        }
                    }
                }
  

            } while (tryAgain);
            return role;
        }
        private bool CheckRoleAccess(Context applicationContext, File file, IRole role)
        {
            return applicationContext.ApplicationAuthorizer.HasReadAccess(file.FileName, role);
        }
        private bool AskYesNo(string question)
        {
            bool tryAgain = false;
            bool isYes = false;
            bool isNo = false;
            do
            {
                tryAgain = false;
                System.Console.WriteLine(question + " (y/n)");
                string response = System.Console.ReadLine().ToLower().Trim();

                isYes = (response == "y" | response == "yes");
                isNo = (response == "n" | response == "no");
                
                if (! (isYes | isNo))
                {
                    tryAgain = this.AskErrorTryAgain("Unrecognized response.");
                    if (tryAgain)
                    {
                        continue;
                    }
                    else
                    {
                        this.StopApplication();
                    }
                }
                else
                {
                    break;
                }
            } while (tryAgain);
            return isYes;
        }
        private bool AskStartOver()
        {
            return this.AskYesNo("Start over?");
        }
        private bool AskTryAgain()
        {
            return this.AskYesNo("Try again");
        }
        private void PrintError(string errorMessage)
        {
            System.Console.WriteLine("[ERROR]");
            System.Console.WriteLine(errorMessage);
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
        private void StopApplication()
        {
            System.Environment.Exit(1);
        }
    }
}