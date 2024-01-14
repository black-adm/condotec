using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Condotec.Identity.Application.Requests
{
    public class SignInUserRequest
    {
        [JsonIgnore]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Username { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Password { get; set; }
    }
}
