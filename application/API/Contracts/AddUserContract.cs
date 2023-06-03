using API.Objects;

namespace API.Contracts
{
    public class AddUserContract
    {
        public string FirstName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public Date Birthday { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}