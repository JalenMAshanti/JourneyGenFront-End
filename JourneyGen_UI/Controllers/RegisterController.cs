using JourneyGen_UI.Models;
using Logic.Helpers;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JourneyGen_UI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserRepository _userRepository;
		private readonly EmailSenderRepository _emailSenderRepository;

		public RegisterController(UserRepository userRepository,
								  EmailSenderRepository emailSenderRepository)
		{
		
			_userRepository = userRepository;
			_emailSenderRepository = emailSenderRepository;
		}

		public IActionResult Register()
		{
			RegisterViewModel registerViewModel = new RegisterViewModel();

			return View(registerViewModel);
		}

		public async Task<IActionResult> AttemptAccountRegister(RegisterViewModel form)
		{

			try
			{
				var response = _userRepository.RegisterUser(form).Result;

				if (response == "unsuccessful")
				{
					RegisterViewModel viewModel = new RegisterViewModel();

					return View("Register", viewModel);
				}
				else
				{
					var admins = await _userRepository.GetAdmins();

					string emailTo = EmailSelector.SelectEmailsFromListOfUsers(admins);

					await _emailSenderRepository.NewRegistrationEmailToAdmin(emailTo, form.FirstName, form.LastName, form.RoleId);

					LoginViewModel loginView = new LoginViewModel();

					return View("~/Views/Home/Login.cshtml", loginView);
				}
			}
			catch
			{
				RegisterViewModel registerView = new RegisterViewModel();

				return View("Register", registerView);
			}
		}
	}
}

