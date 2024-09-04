using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WoWStats.API.Models.Authentication;
using WoWStats.API.Models.Config;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WoWStats.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly OAuthSettings _oAuthSettings;

        public AuthorizationController(IOptions<OAuthSettings> oAuthSettings)
        {
            _oAuthSettings = oAuthSettings.Value;
            
        }
        // GET: <AuthorizationController>/authorize
        [HttpGet("authorize")]
        public IActionResult RedirectToAuthorization()
        {
            var authorizationUrl = $"{_oAuthSettings.AuthorizeUri}?response_type=code&client_id={_oAuthSettings.ClientId}&redirect_uri={_oAuthSettings.RedirectUri}&state=AbCdEfG&scope=openid";
            return Redirect(authorizationUrl);
        }

        // GET: <AuthorizationController>/callback
        [HttpGet("callback")]
        public async Task<IActionResult> Callback(string code, string state)
        {
            if (state != "AbCdEfG")
            {
                return BadRequest("Invalid state");
            }

            var tokenResponse = await GetToken(code);
            return Ok(tokenResponse);
        }

        private async Task<TokenResponse> GetToken(string code)
        {
            using var client = new HttpClient();

            var requestContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","authorization_code"),
                new KeyValuePair<string,string>("code",code),
                new KeyValuePair<string, string>("redirect_uri",_oAuthSettings.RedirectUri),
                new KeyValuePair<string,string>("client_id",_oAuthSettings.ClientId),
                new KeyValuePair<string,string>("client_secret",_oAuthSettings.ClientSecret)
            });

            var response = await client.PostAsync(_oAuthSettings.TokenUri, requestContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TokenResponse>(content);
        }
    }
}
