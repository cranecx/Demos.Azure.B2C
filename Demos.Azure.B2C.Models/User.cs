namespace Demos.Azure.B2C.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? Upn { get; set; }
        public bool Enabled { get; set; }
        public List<UserIdentity> Identities { get; set; } = [];
        public string? GivenName { get; set; }
        public string? Surname { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
