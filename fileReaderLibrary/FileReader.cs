using System;

namespace fileReaderLibrary
{
    public class FileReader
    {
        private string FileContent { get; set; }
        private Context context { get; set;}

        public FileReader(Context context)
        {
            this.context = context;
        }
        public void DisplayContent()
        {
            this.GetFileContent();
            System.Console.WriteLine(this.FileContent);
        }
        private void GetFileContent()
        {
            this.FileContent = System.IO.File.ReadAllText(this.context.File.FileName);
        }
    }
}