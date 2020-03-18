using System;
using System.Collections.Generic;

namespace fileReaderLibrary
{
    public interface IAuthorizer
    {
        List<IRole> AvailableRoles { get; set; }
        bool HasReadAccess(string fileName, IRole role);
    }

    public class SimpleAuthorizer : IAuthorizer
    {
        public List<IRole> AvailableRoles
        {
            get 
            {
                return new List<IRole> {new Admin(), new Member()};
            }
            set {}
        }
        public bool HasReadAccess(string fileName, IRole role)
        {
            // some dummy logic here
            if (fileName.Contains("admin"))
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