namespace Logic.Models.RequestModels
{
    public class RegisterRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public int RoleId { get; set; }
        public int Grade { get; set; }
        public long PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
