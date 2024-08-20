using Logic.Abstractions.API;
using Logic.Factories;

namespace Logic.API
{
	public class MessagesAPIService : APIService
	{
		public MessagesAPIService(HttpClient client, ClientFactory clientFactory) : base(client, clientFactory)
		{
		}
	}
}
