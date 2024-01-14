using System.Text.Json.Serialization;

namespace Condotec.Identity.Application.Responses
{
    public class UserLoginResponse
    {
        public bool Success => Errors?.Count == 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AccessToken { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RefreshToken { get; set; }

        public List<string>? Errors { get; set; }

        public UserLoginResponse() =>
            Errors = [];

        public UserLoginResponse(string accessToken, string refreshToken) : this()
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public UserLoginResponse AddErrors(string erro)
        {
            Errors?.Add(erro);
            return this;
        }

        public void AdicionarErros(IEnumerable<string> erros) =>
            Errors?.AddRange(erros);
    }
}
