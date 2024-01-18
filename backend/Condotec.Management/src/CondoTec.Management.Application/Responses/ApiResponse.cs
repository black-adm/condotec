namespace CondoTec.Management.Application.Responses
{
    public class ApiResponse<T>
    {
        public bool Success => ErrorMessages?.Count == 0;
        public List<string?> ErrorMessages { get; set; } = [];

        public T? Data { get; set; } = Activator.CreateInstance<T>();


        public ApiResponse<T> AddError(string error)
        {
            ErrorMessages.Add(error);
            return this;
        }
    }

    public class ApiResponse
    {
        public bool Success => ErrorMessages?.Count == 0;
        public List<string?> ErrorMessages { get; set; } = [];

        public void AddError(string error)
        {
            ErrorMessages.Add(error);
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            ErrorMessages.AddRange(errors);
        }
    }
}
