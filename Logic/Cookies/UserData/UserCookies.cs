using Logic.Models;

namespace Logic.Cookies.UserData
{
    public static class UserCookies
    {
        public static User? currentUser {  get; set; }
        public static VerseOfTheDay? VerseOfTheDay { get; set; }
        public static PrexelImage? PrexelImage { get; set; }
        public static IEnumerable<User>? Students { get; set; }
        public static IEnumerable<User>? Leaders { get; set; }
    }
}
