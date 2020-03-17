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
    }
}