using Logic.Cookies.UserData;
using Logic.Models;

namespace JourneyGen_UI.Models
{
    public class MessagesViewModel
    {
        public Message? Message { get; set; }
        public User User { get; set; } = UserCookies.currentUser;
        public IEnumerable<Message>? Messages { get; set; }
        public IEnumerable<User>? Students;
        public IEnumerable<User>? Leaders;
    }
}
