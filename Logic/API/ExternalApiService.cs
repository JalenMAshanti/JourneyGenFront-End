using Logic.Abstractions.API;
using Logic.Factories;

namespace Logic.API
{
	public class ExternalApiService : APIService
	{
		public ExternalApiService(HttpClient client, ClientFactory clientFactory) : base(client, clientFactory)
		{
		}
	}
}
