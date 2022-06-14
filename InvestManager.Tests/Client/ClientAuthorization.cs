namespace TestClient
{
    using System.Net.Http.Headers;

    public partial class Client
    {
        private string _accessToken;

        public Client SetAccessToken(string accessToken)
        {
            _accessToken = accessToken;
            return this;
        }
        
        partial void PrepareRequest(
            System.Net.Http.HttpClient client, 
            System.Net.Http.HttpRequestMessage request,
            string url) =>
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
    }
}