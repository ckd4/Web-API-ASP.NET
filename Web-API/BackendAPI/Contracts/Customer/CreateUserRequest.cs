namespace BackendAPI.Contracts.Customer
{
    public class CreateUserRequest
    {
        public CreateUserRequest()
        {
            CustomerPhone = string.Empty;
            CustomerPassword = string.Empty;
            CustomerFirstName = string.Empty;
            CustomerLastName = string.Empty;
            CustomerAddress = string.Empty;
        }

        public string CustomerPhone { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
    }
}
