namespace Logic.API.ApiResponses
{
    public class LoginApiResponse
    {

        public string? email { get; set; }
        public string? password { get; set; }
        public int roleId { get; set; }
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? gender { get; set; }
        public bool isActive { get; set; }
        public bool isVerified { get; set; }
        public int groupId { get; set; }
        public int grade { get; set; }
        public long phoneNumber { get; set; }
        public int ReadingStreak { get; set; }
        public string? tempKey { get; set; }

    }
}
