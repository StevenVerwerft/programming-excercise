using System;
using System.Collections.Generic;
using fileReaderLibrary.Enums;

namespace fileReaderLibrary
{
    public class FileValidator

    {   
        public static List<FileExtension> EncryptedFileExtensions = new List<FileExtension> {FileExtension.TXT, FileExtension.XML};
        public static List<FileExtension> RoleBasedSecuredFileExtensions = new List<FileExtension> {FileExtension.XML, FileExtension.TXT};
        public static bool CheckEncryptionSupported(FileExtension fileExtension)
        {
            return EncryptedFileExtensions.Contains(fileExtension);
        }
        public static bool CheckRoleBasedSecuritySupported(FileExtension fileExtension)
        {
            return RoleBasedSecuredFileExtensions.Contains(fileExtension);
        }
        private static Dictionary<FileExtension, string> FileExtensionToString = new Dictionary<FileExtension, string>()

        {
            {FileExtension.TXT, ".txt"},
            {FileExtension.XML, ".xml"},
        };

        public static bool CheckFileExists(string fileName)
        {
            return System.IO.File.Exists(fileName);
        }
        public static bool MatchFileFileExtension(string fileName, string fileExtension)
        {
            return System.IO.Path.GetExtension(fileName) == fileExtension;
        }

        public static bool IsValidFileExtension(FileExtension fileExtension)
        {
            return Enum.IsDefined(typeof(FileExtension), fileExtension);
        }
        public static bool IsValidRole(IAuthorizer authorizer, int roleID)
        {
            try
            {
                IRole role = authorizer.AvailableRoles[roleID];
                return true;
            }
            catch (System.Exception)
            {
                
                return false;
            }
        }
        public static bool MatchFileFileExtension(string fileName, FileExtension fileExtension)
        {
            string extension = System.IO.Path.GetExtension(fileName);
            return (FileExtensionToString[fileExtension] == extension);
        }
    }
}