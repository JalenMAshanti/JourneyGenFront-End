namespace Logic.Factories
{
	public class ClientFactory
	{
		public ClientFactory()
		{
		}

		public static HttpClient CreateNewClient()
		{
			HttpClient client = new HttpClient();
			return client;
		}
	}
}
