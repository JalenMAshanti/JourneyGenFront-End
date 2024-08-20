using Logic.Models;

namespace JourneyGen_UI.Models
{
    public class AdminViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 

        public int MiddleSchoolBoysCount { get; set; } = 0;
        public int MiddleSchoolGirlsCount { get; set;} = 0;
        public int HighSchoolBoysCount { get; set; } = 0;
        public int HighSchoolGirlsCount { get; set; } = 0;

        public IEnumerable<User>? AdminUsers { get; set; }
        public IEnumerable<User>? CurrentLeaders { get; set; }
        public IEnumerable<User>? StudentsWaiting { get; set; }
        public IEnumerable<User>? LeadersWaiting { get; set; }
    }
}
