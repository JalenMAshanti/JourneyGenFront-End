using Logic.API;
using Logic.API.ApiResponses;
using Logic.Cookies.UserData;
using Logic.Mappers;
using Logic.Models;
using System.Net.Http.Headers;

namespace Logic.Repositories
{
	public class ImageRepository
	{
		private readonly HttpClient _client;
		private readonly ExternalApiService _externalApiService;
		private readonly Random _random;

		public ImageRepository(HttpClient client, ExternalApiService externalApiService, Random random)
		{
			_client = client;
			_externalApiService = externalApiService;
			_random = random;
		}

		public async Task<PrexelImage> GetVODBackgroundImage()
		{
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"{AppSettings.prexelKey}");
			var image = await _externalApiService.GetAPIResponse<PrexelAPIResponse>(_client, $"https://api.pexels.com/v1/search?query=nature&page={_random.Next(1, 100)}&per_page={_random.Next(1, 30)}");
			var result = PrexelImage_Mapper.PrexelMapper(image);
			_client.DefaultRequestHeaders.Authorization = null;
			UserCookies.PrexelImage = result;

			return result;
		}
	}
}
