using Logic.Factories;
using Logic.Models;
using Newtonsoft.Json;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Logic.Abstractions.API
{
	public abstract class APIService : IAPIRequestInterface
	{
		private readonly HttpClient _client;
		private readonly ClientFactory	_clientFactory;
		public APIService(HttpClient client,
						 ClientFactory clientFactory)
		{
			_client = client;
			_clientFactory = clientFactory;
		}

		public HttpClient Client { get; }

		public async Task<TResponse> GetAPIResponse<TResponse>(HttpClient _client, string _url)
		{
			var response = await _client.GetStringAsync(_url);
			var result = JsonConvert.DeserializeObject<TResponse>(response);

			return result;

		}

		public async Task<IEnumerable<TResponse>> GetListAPIResponse<TResponse>(HttpClient _client, string _url)
		{
			try
			{
				var response = await _client.GetStringAsync(_url);
				var result = JsonConvert.DeserializeObject<IEnumerable<TResponse>>(response);
				return result;
			}
			catch
			{

				return new List<TResponse>();
			}
		}

		public async Task<string> PostAPIRequest(string _url, Object body)
		{
			
			_client.BaseAddress = new Uri(_url);
			string json = JsonSerializer.Serialize(body);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.PostAsync("", data);
			var result = await response.Content.ReadAsStringAsync();
			_client.CancelPendingRequests();
			return result;
		}

        public async Task<string> PostAPIRequestSecondary(HttpClient _client, string _url, Object body)
        {

			var client = ClientFactory.CreateNewClient();
			client.BaseAddress = new Uri(_url);
            string json = JsonSerializer.Serialize(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("", data);
            var result = await response.Content.ReadAsStringAsync();
			client.Dispose();
            return result;
        }

        public Task<string> PutAPIRequest(string _url, Object body)
		{

			_client.BaseAddress = new Uri(_url);
			string json = JsonSerializer.Serialize(body);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			var response = _client.PutAsync("", data).Result;
			var result = response.Content.ReadAsStringAsync();
			return result;
		}
	}
}
