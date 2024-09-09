using Logic.API;
using Logic.API.ApiResponses;
using Logic.Cookies.UserData;
using Logic.Mappers;
using Logic.Models;

namespace Logic.Repositories
{
	public class UserRepository
	{
		private readonly HttpClient _client;
		private readonly ExternalApiService _externalApiService;

		public UserRepository(HttpClient client, ExternalApiService externalApiService)
		{
			_client = client;
			_externalApiService = externalApiService;
		}

		public async Task<IEnumerable<User>> GetLeaderByGroupId(int groupId)
		{
			var leaders = await _externalApiService.GetListAPIResponse<UserCollectionAPIResponse>(_client, $"{AppSettings.azureBaseAdress}/api/User/GetLeadersByGroupId?groupId={groupId}");
			var results = UserByGroup_Mapper.UserCollectionMapper(leaders);
			UserCookies.Leaders = results;
			return results;
		}

		public async Task<IEnumerable<User>> GetStudentsByGroupId(int groupId)
		{
			var students = await _externalApiService.GetListAPIResponse<UserCollectionAPIResponse>(_client, $"{AppSettings.azureBaseAdress}/api/User/GetStudentsByGroupId?groupId={groupId}");
			var results = UserByGroup_Mapper.UserCollectionMapper(students);
			UserCookies.Students = results;
			return results;
		}

		public async Task<IEnumerable<User>> GetAdmins()
		{
			var students = await _externalApiService.GetListAPIResponse<UserCollectionAPIResponse>(_client, $"{AppSettings.azureBaseAdress}/api/User/GetAdmins");
			var results = UserByGroup_Mapper.UserCollectionMapper(students);
			return results;
		}

		public async Task<IEnumerable<User>> GetUnverifiedUserByRoleId(int roleId)
		{
			var students = await _externalApiService.GetListAPIResponse<UserCollectionAPIResponse>(_client, $"{AppSettings.azureBaseAdress}/api/User/GetUnverifiedUsersByRoleId?roleId={roleId}");
			var results = UserByGroup_Mapper.UserCollectionMapper(students);
			return results;
		}

		public async Task<IEnumerable<User>> GetLeaders()
		{
			var leaders = await _externalApiService.GetListAPIResponse<UserCollectionAPIResponse>(_client, $"{AppSettings.azureBaseAdress}/api/User/GetLeaders");
			var results = UserByGroup_Mapper.UserCollectionMapper(leaders);
			return results;
		}

		public async Task VerifiyUser(int userId, int groupId)
		{
			await _externalApiService.PutAPIRequest($"{AppSettings.azureBaseAdress}/api/User/VerifyUser?userId={userId}&groupId={groupId}", "");
		}

		public async Task<string> RegisterUser(Object body)
		{
			string url = $"{AppSettings.azureBaseAdress}/RegisterUser";
			var result = await _externalApiService.PostAPIRequest(url, body);

			if (result == null)
			{
				return "unsuccessful";
			}
			else
			{
				return "successful";
			}
		}

	}
}
