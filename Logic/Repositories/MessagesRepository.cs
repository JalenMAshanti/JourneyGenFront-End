using Logic.API;
using Logic.API.ApiResponses;
using Logic.Mappers;
using Logic.Models;

namespace Logic.Repositories
{
	public class MessagesRepository
	{
		private readonly HttpClient _client;
		private readonly ExternalApiService _externalApiService;
		public MessagesRepository(HttpClient client, ExternalApiService externalApiService) 
		{ 
			_client = client;
			_externalApiService = externalApiService;		
		}

		public async Task<IEnumerable<Message>> GetRecentActivityByGroupId(int groupId) 
		{
			var messages = await _externalApiService.GetListAPIResponse<MessagesAPIResponse>(_client, $"https://localhost:7229/api/Messages/GetRecentActivityByGroupId?groupId={groupId}");
			var result = Message_Mapper.MapMessage(messages);
			return result;
		}

		public async Task<IEnumerable<Message>> GetMessagesByGroupId(int groupId)
		{
			var messages = await _externalApiService.GetListAPIResponse<MessagesAPIResponse>(_client, $"https://localhost:7229/api/Messages/GetMessagesByGroupId?groupId={groupId}");
			var result = Message_Mapper.MapMessage(messages);
			return result;
		}
	}
}
