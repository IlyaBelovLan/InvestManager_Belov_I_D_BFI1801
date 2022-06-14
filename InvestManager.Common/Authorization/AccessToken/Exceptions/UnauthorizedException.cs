namespace InvestManager.Common.Authorization.AccessToken.Exceptions
{
    using System;

    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {
        }
        
        public UnauthorizedException(string message) : base(message)
        {
        }
        
        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}