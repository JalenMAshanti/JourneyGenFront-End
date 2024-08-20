

namespace Logic.API.ApiResponses
{

    public class UserByGroupIdAPIResponse
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? gender { get; set; }
        public int roleId { get; set; }
        public long phoneNumber { get; set; }
        public int groupId { get; set; }
        public bool isActive { get; set; }
        public bool isVerified { get; set; }
    }

}
