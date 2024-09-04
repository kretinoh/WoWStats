using Newtonsoft.Json;

namespace WoWStats.API.Models.Authentication
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
        public string Scope { get; set; }
        public int Sub { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
