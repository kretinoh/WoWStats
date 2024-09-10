using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WoWStats.API.Models.Retail;
using WoWStats.API.Models.Retail.Heirlooms;
using WoWStats.API.Models.Retail.Pets;
using WoWStats.API.Models.Retail.Toys;
using WoWStats.API.Models.Retail.Transmogs;
using WoWStats.API.Utils;

namespace WoWStats.API.Controllers.WowRetail
{
    [ApiController]
    [Route("Retail/[controller]")]
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
            var apiUrl = $"https://{region}.{rawUrl}/profile/user/wow?namespace={profileNameSpace}&locale=es_ES";
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

        [HttpGet("mounts")]
        public async Task<IActionResult> GetMountsCollection(string region)
        {

            var accessToken = _tokenService.GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Token no disponible. Por favor, autorízate primero.");
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var apiUrl = $"https://{region}.{rawUrl}/profile/user/wow/collections/mounts?namespace={profileNameSpace}&locale=es_ES";

            var response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener el perfil de WoW.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<Mounts>(content);

            return Ok(userInfo);
        }

        [HttpGet("pets")]
        public async Task<IActionResult> GetPetsCollection(string region)
        {

            var accessToken = _tokenService.GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Token no disponible. Por favor, autorízate primero.");
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var apiUrl = $"https://{region}.{rawUrl}/profile/user/wow/collections/pets?namespace={profileNameSpace}&locale=es_ES";

            var response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener el perfil de WoW.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<Pets>(content);

            return Ok(userInfo);
        }

        [HttpGet("heirlooms")]
        public async Task<IActionResult> GetHeirloomsCollection(string region)
        {

            var accessToken = _tokenService.GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Token no disponible. Por favor, autorízate primero.");
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var apiUrl = $"https://{region}.{rawUrl}/profile/user/wow/collections/heirlooms?namespace={profileNameSpace}&locale=es_ES";

            var response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener el perfil de WoW.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<Heirlooms>(content);

            return Ok(userInfo);
        }

        [HttpGet("transmogs")]
        public async Task<IActionResult> GetTransmogsCollection(string region)
        {

            var accessToken = _tokenService.GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Token no disponible. Por favor, autorízate primero.");
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var apiUrl = $"https://{region}.{rawUrl}/profile/user/wow/collections/transmogs?namespace={profileNameSpace}&locale=es_ES";

            var response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener el perfil de WoW.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<Transmogs>(content);

            return Ok(userInfo);
        }

        [HttpGet("toys")]
        public async Task<IActionResult> GetToysCollection(string region)
        {

            var accessToken = _tokenService.GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Token no disponible. Por favor, autorízate primero.");
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var apiUrl = $"https://{region}.{rawUrl}/profile/user/wow/collections/toys?namespace={profileNameSpace}&locale=es_ES";

            var response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener el perfil de WoW.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var userInfo = JsonConvert.DeserializeObject<Toys>(content);

            return Ok(userInfo);
        }


    }
}
