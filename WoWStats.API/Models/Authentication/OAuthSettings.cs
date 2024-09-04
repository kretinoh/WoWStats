namespace WoWStats.API.Models.Config
{
    public class OAuthSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizeUri { get; set; }
        public string TokenUri { get; set; }
        public string RedirectUri { get; set; }

    }
}
