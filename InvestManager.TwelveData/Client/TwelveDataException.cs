namespace InvestManager.TwelveData.Client
{
    using System;

    public class TwelveDataException : Exception
    {
        public TwelveDataException()
        {
        }
        
        public TwelveDataException(string message) : base(message)
        {
        }
        
        public TwelveDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}