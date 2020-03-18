using System;

namespace fileReaderLibrary
{
    public class FileReader
    {
        private string FileContent { get; set; }
        private Context Context { get; set;}

        public FileReader(Context context)
        {
            this.Context = context;
        }
        public void DisplayContent()
        {
            this.GetFileContent();
            System.Console.Clear();
            System.Console.WriteLine(this.FileContent);
        }
        private void GetFileContent()
        {
            this.FileContent = System.IO.File.ReadAllText(this.Context.File.FileName);
            if (this.Context.File.IsEncrypted)
            {
                this.FileContent = this.DecryptFileContent();
            }
        }
        private string DecryptFileContent()
        {
            return this.Context.ApplicationDecryptor.Decrypt(this.FileContent);
        }
    }
}