namespace Condotec.Identity.Application.Requests
{
    public class AddUserInClaimRequest
    {
        public string? Email { get; set; }
        public IEnumerable<UserClaim>? Claims { get; set; }
    }

    public class UserClaim
    {
        public ClaimType ClaimType { get; set; }
        public ClaimValue ClaimValue { get; set; }
    }

    public enum ClaimType
    {
        Receipt = 0,
        Category = 1
    }

    public enum ClaimValue
    {
        Insert = 0,
        Read = 1,
        Update = 2,
        Delete = 3
    }
}
