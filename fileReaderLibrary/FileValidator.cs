using System;
using System.Collections.Generic;

namespace fileReaderLibrary
{
    public class FileValidator
    {
        public static List<string> ValidFileExtensions = new List<string> {".txt"};

        public static bool CheckTypeSupported(string fileExtension)
        {
            return ValidFileExtensions.Contains(fileExtension);
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