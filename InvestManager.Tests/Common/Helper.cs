namespace InvestManager.Tests.Common
{
    using System;
    using System.Security.Cryptography;

    public static class Helper
    {
        public static string CreateRandomString(int length)
        {
            var bytes = new byte[length];
            using var provider = new RNGCryptoServiceProvider();
            provider.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}