using System;
using fileReaderLibrary.Enums;
namespace fileReaderLibrary
{
    public class File
    {
        public string FileName { get; set; }
        public FileExtension FileExtension { get; set; }
        public bool IsEncrypted { get; set; }
        public bool IsRoleBaseSecured { get; set; }

        public File(string fileName, FileExtension fileExtension, bool isEncrypted, bool isRoleBaseSecured)
        {
            this.FileName = fileName;
            this.FileExtension = fileExtension;
            this.IsEncrypted = isEncrypted;
            this.IsRoleBaseSecured = isRoleBaseSecured;
        }
    }
}