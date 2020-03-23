using System;

namespace fileReaderLibrary
{
    public interface IAuthorizerFactory
    {
        IAuthorizer CreateAuthorizer();
    }

    public class AuthorizerFactory : IAuthorizerFactory
    {
        public IAuthorizer CreateAuthorizer()
        {
            return new SimpleAuthorizer();
        }
    }
}