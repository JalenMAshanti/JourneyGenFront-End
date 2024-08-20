using JourneyGen_UI.Models;
using Logic.API;
using Logic.API.ApiResponses;
using Logic.Mappers;
using Logic.Models;
using Logic.Models.RequestModels;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JourneyGen_UI.Controllers
{
	public class GroupBoardController : Controller
	{
		private readonly HttpClient _client;
		private readonly UserRepository _userRepository;
		private readonly MessagesAPIService _messagesService;
		public GroupBoardController(HttpClient client, 
									UserRepository userRepository,
									MessagesAPIService messagesService)
		{
			
			_client = client;
			_userRepository = userRepository;
			_messagesService = messagesService;
		}


		[HttpPost]
		public async Task<IActionResult> PostMessage(MessagesViewModel view)
		{
			string url = "https://localhost:7229/api/Messages/PostMessageToGroupBoard";

			MessagePost messagePost = new MessagePost();
			messagePost.FirstName = view.User.FirstName;
			messagePost.LastName = view.User.LastName;
			messagePost.UserId = view.User.Id;
			messagePost.GroupId = view.User.GroupId;
			messagePost.Content = view.Message.Content;

			var response = _messagesService.PostAPIRequest(url, messagePost).Result;

			var messages = await _messagesService.GetListAPIResponse<MessagesAPIResponse>(_client, $"https://localhost:7229/api/Messages/GetMessagesByGroupId?groupId={view.User.GroupId}");
			view.Messages = Message_Mapper.MapMessage(messages);
			view.Message.Content = "";

			return View("~/Views/Home/GroupBoard.cshtml", view);
		}
	}
}
