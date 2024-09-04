
using System.ComponentModel.DataAnnotations;

namespace WoWStats.Core.Model.OAuth
{
    public class Authorize
    {
        [Required(ErrorMessage = "El campo 'region' es obligatorio")]
        public string Region { get; set; }
        [Required(ErrorMessage = "El campo 'response_type' es obligatorio")]
        public string ResponseType { get; set; }
        [Required(ErrorMessage = "El campo 'client_id' es obligatorio")]
        public string ClientId { get; set; }
        [Required(ErrorMessage = "El campo 'redirect_uri' es obligatorio")]
        public string RedirectUri { get; set; }
        public string Scope { get; set; }
        public string State { get; set; }
    }
}
