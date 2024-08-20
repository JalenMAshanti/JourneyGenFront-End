using Logic.Abstractions.API;
using Logic.Factories;

namespace Logic.API
{
	public class LoginAPIService : APIService
	{
		public LoginAPIService(HttpClient client, ClientFactory clientFactory) : base(client, clientFactory)
		{
		}
	}
}
