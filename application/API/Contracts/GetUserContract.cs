namespace API.Contracts
{
    public class GetUserContract
    {
        public long UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public DateTime Birthday { get; set; }
    }
}