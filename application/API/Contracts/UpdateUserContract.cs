using API.Objects;

namespace API.Contracts
{
    public class UpdateUserContract
    {
        public string FirstName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public Date Birthday { get; set; } = null!;
    }
}