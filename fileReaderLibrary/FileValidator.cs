using System;
using System.Collections.Generic;
using fileReaderLibrary.Enums;

namespace fileReaderLibrary
{
    public class FileValidator
    {   
        private static Dictionary<FileExtension, string> FileExtensionToString = new Dictionary<FileExtension, string>()
        {
            {FileExtension.TXT, ".txt"},
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
        public static bool MatchFileFileExtension(string fileName, FileExtension fileExtension)
        {
            string extension = System.IO.Path.GetExtension(fileName);
            return (FileExtensionToString[fileExtension] == extension);
        }
    }
}