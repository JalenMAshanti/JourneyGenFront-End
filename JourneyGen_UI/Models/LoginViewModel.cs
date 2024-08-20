using Logic.Models.RequestModels;

namespace JourneyGen_UI.Models
{
    public class LoginViewModel
    {
        public LoginRequest? request {  get; set; }

        public string error { get; set; } = "";

    }
}
