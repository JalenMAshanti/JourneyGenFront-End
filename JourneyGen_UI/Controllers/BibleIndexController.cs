using JourneyGen_UI.Models;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JourneyGen_UI.Controllers
{
	public class BibleIndexController : Controller
	{
		public string BookName { get; set; }
		public int ChapterNumber { get; set; }

		private readonly HttpClient _httpClient;
		private readonly BibleRepository _bibleRepository;

		public BibleIndexController(HttpClient client, BibleRepository bibleRepository)
		{
			_httpClient = client;
			_bibleRepository = bibleRepository;
		}


		public IActionResult BibleIndex()
		{
			BibleIndexViewModel bible = new BibleIndexViewModel();

			bible.BibleBooks = BibleRepository.GenerateBibleBooks();

			return View(bible);
		}

		public async Task<IActionResult> ChapterSelected(BibleIndexViewModel bibleIndexViewModel)
		{
			await _bibleRepository.UpdateUserBibleReadingStreak();

			bibleIndexViewModel.ChapterViewName = bibleIndexViewModel.SelectedChapterTitle;

			bibleIndexViewModel.SelectedChapterTitle = new string(bibleIndexViewModel.SelectedChapterTitle.ToLower().ToArray());

			bibleIndexViewModel.SelectedChapterText = await _bibleRepository.GetBibleChapterText(bibleIndexViewModel.SelectedChapterTitle, bibleIndexViewModel.SelectedChapterNum);

			bibleIndexViewModel.BibleBooks = BibleRepository.GenerateBibleBooks();

			return View("BibleIndex", bibleIndexViewModel);

		}
	}
}
