using JourneyGen_UI.Models;
using Logic.Cookies.UserData;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JourneyGen_UI.Controllers
{
	public class AdminController : Controller
	{
		private readonly HttpClient _client;
		private readonly UserRepository _userRepository;
		public AdminController(HttpClient Client,
							   UserRepository userRepository)
		{
			_client = Client;
			_userRepository = userRepository;
		}

		public async Task<IActionResult> VerifyUser(ManageUserViewModel form)
		{
			int userId = form.SelectedUserId;
			int groupId = form.SelectedUserGroupId;

			await _userRepository.VerifiyUser(userId, groupId);

			ManageUserViewModel viewModel = new ManageUserViewModel();

			viewModel.Leaders = await _userRepository.GetLeaders();
			viewModel.StudentsWaiting = await _userRepository.GetUnverifiedUserByRoleId(1);
			viewModel.LeadersWaiting = await _userRepository.GetUnverifiedUserByRoleId(2);

			return View("~/Views/Admin/ManageUsers.cshtml", viewModel);
		}


		public async Task<IActionResult> ManageUsers()
		{
			ManageUserViewModel viewModel = new ManageUserViewModel();

			viewModel.Leaders = await _userRepository.GetLeaders();
			viewModel.StudentsWaiting = await _userRepository.GetUnverifiedUserByRoleId(1);
			viewModel.LeadersWaiting = await _userRepository.GetUnverifiedUserByRoleId(2);

			return View(viewModel);
		}

		public async Task<IActionResult> InitAdmin()
		{
			AdminViewModel adminViewModel = new AdminViewModel();

			adminViewModel.FirstName = UserCookies.currentUser.FirstName;
			adminViewModel.LastName = UserCookies.currentUser.LastName;

			adminViewModel.HighSchoolGirlsCount = _userRepository.GetStudentsByGroupId(2).Result.Count();
			adminViewModel.HighSchoolBoysCount = _userRepository.GetStudentsByGroupId(4).Result.Count();
			adminViewModel.MiddleSchoolBoysCount = _userRepository.GetStudentsByGroupId(3).Result.Count();
			adminViewModel.MiddleSchoolGirlsCount = _userRepository.GetStudentsByGroupId(1).Result.Count();
			adminViewModel.LeadersWaiting = await _userRepository.GetUnverifiedUserByRoleId(2);
			adminViewModel.StudentsWaiting = await _userRepository.GetUnverifiedUserByRoleId(1);

			adminViewModel.AdminUsers = await _userRepository.GetAdmins();

			return View("~/Views/Admin/Admin.cshtml", adminViewModel);
		}
	}
}
