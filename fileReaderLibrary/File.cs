using System;

namespace fileReaderLibrary
{
    public class File
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsRoleBaseSecured { get; set; }
        public File(string fileName, string fileExtension, bool isEncrypted, bool isRoleBaseSecured)
        {
            this.FileName = fileName;
            this.FileExtension = fileExtension;
            this.IsEncrypted = isEncrypted;
            this.IsRoleBaseSecured = isRoleBaseSecured;
        }
    }
}