using JourneyGen_UI.Models;
using Logic.API;
using Logic.API.ApiResponses;
using Logic.Cookies.UserData;
using Logic.Mappers;
using Logic.Models;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JourneyGen_UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly LoginAPIService _loginAPIService;
		private readonly HttpClient _client;
		private readonly UserRepository _userRepository;
		private readonly MessagesRepository _messageRepository;
		private readonly BibleRepository _bibleRepository;
		private readonly ImageRepository _imageRepository;

		public HomeController(ILogger<HomeController> logger,
							  LoginAPIService loginAPIService,
							  HttpClient client,
							  UserRepository userRepository,
							  MessagesRepository messageRepository,
							  BibleRepository bibleRepository,
							  ImageRepository imageRepository)
		{
			_logger = logger;
			_loginAPIService = loginAPIService;
			_client = client;
			_userRepository = userRepository;
			_messageRepository = messageRepository;
			_bibleRepository = bibleRepository;
			_imageRepository = imageRepository;
		}



		[HttpGet]
		public IActionResult Login()
		{
			LoginViewModel viewModel = new LoginViewModel();
			return View(viewModel);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public async Task<IActionResult> LoginUser(LoginViewModel login)
		{
			DashboardViewModel dashboardViewModel = new DashboardViewModel();

			try
			{
				dashboardViewModel.User = Login_UserMapper.LoginUserMapper(_loginAPIService.GetAPIResponse<LoginApiResponse>(_client, $"{AppSettings.azureBaseAdress}/api/Login/UserLogin?email={login.request.Email}&password={login.request.Password}").Result);
				UserCookies.currentUser = dashboardViewModel.User;
			}
			catch
			{
				LoginViewModel viewModel = new LoginViewModel();
				viewModel.error = "Incorrect Password or Username";
				return View("Login", viewModel);
			}


			dashboardViewModel.VerseOfTheDay = await _bibleRepository.GetVerseOfTheDay();

			dashboardViewModel.PrexelImage = await _imageRepository.GetVODBackgroundImage();


			if (dashboardViewModel.User.RoleId == 1)
			{
				dashboardViewModel.Leaders = await _userRepository.GetLeaderByGroupId(dashboardViewModel.User.GroupId);
			}
			else
			{
				dashboardViewModel.Students = await _userRepository.GetStudentsByGroupId(dashboardViewModel.User.GroupId);
			}

			dashboardViewModel.RecentActivity = await _messageRepository.GetRecentActivityByGroupId(dashboardViewModel.User.GroupId);

			return View("Dashboard", dashboardViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> ReturnHome()
		{
			DashboardViewModel dashboardViewModel = new DashboardViewModel();

			dashboardViewModel.User = UserCookies.currentUser;
			dashboardViewModel.VerseOfTheDay = UserCookies.VerseOfTheDay;
			dashboardViewModel.PrexelImage = UserCookies.PrexelImage;
			dashboardViewModel.Leaders = UserCookies.Leaders;
			dashboardViewModel.Students = await _userRepository.GetStudentsByGroupId(dashboardViewModel.User.GroupId);
			dashboardViewModel.RecentActivity = await _messageRepository.GetRecentActivityByGroupId(dashboardViewModel.User.GroupId);

			return View("Dashboard", dashboardViewModel);
		}


		public async Task<IActionResult> GroupBoard()
		{
			MessagesViewModel messagesViewModel = new MessagesViewModel();

			messagesViewModel.Messages = await _messageRepository.GetMessagesByGroupId(messagesViewModel.User.GroupId);
			messagesViewModel.Students = await _userRepository.GetStudentsByGroupId(messagesViewModel.User.GroupId);
			messagesViewModel.Leaders = await _userRepository.GetLeaderByGroupId(messagesViewModel.User.GroupId);

			return View(messagesViewModel);
		}
	}
}
