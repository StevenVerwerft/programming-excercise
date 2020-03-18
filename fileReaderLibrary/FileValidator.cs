using System;
using System.Collections.Generic;

namespace fileReaderLibrary
{
    public class FileValidator
    {
        public static List<string> ValidFileExtensions = new List<string> {".txt", ".xml", ".json"};
        public static List<string> EncryptedFileExtensions = new List<string> {".txt", ".xml"};
        public static List<string> RoleBasedSecuredFileExtensions = new List<string> { ".txt", ".xml"};
        public static bool CheckTypeSupported(string fileExtension)
        {
            return ValidFileExtensions.Contains(fileExtension);
        }
        public static bool CheckEncryptionSupported(string fileExtension)
        {
            return EncryptedFileExtensions.Contains(fileExtension);
        }
        public static bool CheckRoleBasedSecuritySupported(string fileExtension)
        {
            return RoleBasedSecuredFileExtensions.Contains(fileExtension);
        }
        public static bool CheckFileExists(string fileName)
        {
            return System.IO.File.Exists(fileName);
        }
        public static bool MatchFileFileExtension(string fileName, string fileExtension)
        {
            return System.IO.Path.GetExtension(fileName) == fileExtension;
        }
    }
}