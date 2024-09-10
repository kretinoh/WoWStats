using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WoWStats.API.Models.Authentication;
using WoWStats.API.Models.Config;

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

        [HttpGet("userinfo")]
        public async Task<dynamic> GetUserInfo(string accessToken)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var url = $"{_oAuthSettings.BasicUri}/userinfo";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserInfo>(content);

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
            var userInfo = await GetUserInfo(tokenResponse.AccessToken);
            return Ok(userInfo);
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
