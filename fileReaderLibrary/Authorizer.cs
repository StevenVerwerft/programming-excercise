using System;

namespace fileReaderLibrary
{
    public interface IAuthorizer
    {
        bool HasReadAccess(File file, IRole role);
    }

    public class SimpleAuthorizer : IAuthorizer
    {
        public bool HasReadAccess(File file, IRole role)
        {
            // some dummy logic here
            if (file.FileName.Contains("admin"))
            {
                // only admins have access
                return (role is Admin);
            }
            else
            {
                // everyone has access
                return true;
            }    
        }
    }
}