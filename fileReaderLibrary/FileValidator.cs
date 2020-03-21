using System;
using System.Collections.Generic;
using fileReaderLibrary.Enums;

namespace fileReaderLibrary
{
    public class FileValidator
    {   
        private static Dictionary<FileExtension, string> FileExtensionToEnum = new Dictionary<FileExtension, string>()
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

        public static bool MatchFileExtension(string fileName, FileExtension fileExtension)
        {
            string extension = System.IO.Path.GetExtension(fileName);
            return FileExtensionToEnum.TryGetValue()
        }
    }
}