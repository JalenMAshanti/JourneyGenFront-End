using Logic.API;

namespace Logic.Repositories
{
	public class EmailSenderRepository
	{
		private readonly HttpClient _client;
		private readonly ExternalApiService _externalAPIService;
		private readonly ExternalApiService _backUpAPIService;

		public EmailSenderRepository(HttpClient client, ExternalApiService externalApiService, ExternalApiService backUpAPIService)
		{
			_client = client;
			_externalAPIService = externalApiService;
			_backUpAPIService = backUpAPIService;
		}

		public async Task SendEmail(string emailTo, string subject, string body)
		{
			await _backUpAPIService.PostAPIRequestSecondary(_client, $"https://localhost:7229/api/Email/SendEmailFromAdminAccount?email={emailTo}&subject={subject}&message={body}", "");
		}

		public async Task NewRegistrationEmailToAdmin( string emailTo, string firstName, string lastName, int roleId) 
		{
			string subject = $"New User {firstName} {lastName} has Registered to JourneyGen!";
			string body = $"Please verify {firstName} {lastName} as a {((roleId == 1) ? "Student" : "Leader")}";

			await SendEmail(emailTo, subject, body);
		}
	}
}
