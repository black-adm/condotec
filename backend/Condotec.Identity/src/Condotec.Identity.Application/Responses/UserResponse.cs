namespace Condotec.Identity.Application.Responses
{
    public class UserResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; }

        public UserResponse() =>
            Errors = [];

        public UserResponse(bool sucesso = true) : this() =>
            Success = sucesso;

        public void AddError(IEnumerable<string> erros) =>
            Errors.AddRange(erros);
    }
}
