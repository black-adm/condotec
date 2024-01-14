using System.ComponentModel.DataAnnotations;

namespace Condotec.Identity.Application.Requests
{
    public class SignUpUserRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "O campo e-mail é obrigatório")]
        public string? Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Um username deve ter ao menos 5 caracteres")]
        public string? Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "As senhas não coincidem")]
        public string? PasswordConfirmation { get; set; }
    }
}
