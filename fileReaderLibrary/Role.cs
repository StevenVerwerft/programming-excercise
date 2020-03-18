using System;

namespace fileReaderLibrary
{
    public interface IRole
    {
        string RoleName { get; set; }
    }

    public class Admin : IRole
    {
        public string RoleName
        {
            get { return "Admin"; }
            set {}
        }
    }

    public class Member : IRole
    {
        public string RoleName
        {
            get { return "Member"; }
            set {}
        }
    }
}