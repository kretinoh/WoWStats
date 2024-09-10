namespace WoWStats.API.Utils
{
    public class TokenService
    {
        private string _accessToken;

        public void SetAccessToken(string token)
        {
            _accessToken = token;
        }

        public string GetAccessToken()
        {
            return _accessToken;
        }
    }
}
