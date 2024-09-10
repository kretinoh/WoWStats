using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using WoWStats.API.Models.Authentication;
using WoWStats.API.Models.Config;
using WoWStats.API.Models.Retail;
using WoWStats.API.Utils;

namespace WoWStats.API.Controllers.WowRetail
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {

        private string rawUrl = "api.blizzard.com";
        private string profileNameSpace = "profile-eu";

        private TokenService _tokenService;

        public ProfileController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary(string region)
        {

            var accessToken = _tokenService.GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Token no disponible. Por favor, autorízate primero.");
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var apiUrl = $"https://{region}.{rawUrl}/profile/user/wow?namespace=profile-eu&locale=es_ES";
            //client.DefaultRequestHeaders.Add("Battlenet-Namespace", profileNameSpace);

            var response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener el perfil de WoW.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<WowProfile>(content);

            return Ok(userInfo);
        }


    }
}
