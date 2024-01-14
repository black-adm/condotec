namespace Condotec.Identity.IoC.Models
{
    public class JwtOptionsSettings
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? SecurityKey { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
