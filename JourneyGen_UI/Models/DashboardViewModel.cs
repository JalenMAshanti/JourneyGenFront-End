using Logic.Models;
namespace JourneyGen_UI.Models
{
    public class DashboardViewModel
    {
    
        private static DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        private static string comparisonDate = currentDate.ToString("MM/dd/yyyy");


        public string? TodaysDate { get; } = comparisonDate;
        public User? User { get; set; }
        public VerseOfTheDay? VerseOfTheDay { get; set; }
        public PrexelImage? PrexelImage { get; set; }
        public IEnumerable<Message>? RecentActivity { get; set; }
        public IEnumerable<User>? Students { get; set; }
        public IEnumerable<User>? Leaders { get; set; }
    }
}
