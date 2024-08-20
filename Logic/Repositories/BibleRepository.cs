using Logic.API;
using Logic.API.ApiResponses;
using Logic.Cookies.UserData;
using Logic.Helpers;
using Logic.Mappers;
using Logic.Models;

namespace Logic.Repositories
{
	public class BibleRepository
	{
		private readonly HttpClient _client;
		private readonly ExternalApiService _externalApiService;

		public BibleRepository(HttpClient client, ExternalApiService externalApiService)
		{
			_client = client;
			_externalApiService = externalApiService;
		}

		public async Task<VerseOfTheDay> GetVerseOfTheDay()
		{
			var verse = await _externalApiService.GetAPIResponse<VerseAPIResponse>(_client, "https://localhost:7229/GetVerseOfTheDay");
			var result = Verse_Mapper.VerseMapper(verse);
			UserCookies.VerseOfTheDay = result;
			return result;
		}

		public async Task UpdateUserBibleReadingStreak()
		{
			await _externalApiService.PutAPIRequest($"https://localhost:7229/api/User/UpdateUserReadingStreak?userId={UserCookies.currentUser.Id}", "");
		}

		public async Task<string> GetBibleChapterText(string chapterTitle, int chapterNumber) 
		{
			var response = await _externalApiService.GetAPIResponse<ChapterTextAPIResponse>(_client, $"https://localhost:7229/GetBibleChapter?book={chapterTitle}&chapter={chapterNumber}");
			var text = Chapter_Mapper.ChapterMapper(response);
			var result = StringFormattingHelpers.FormatBibleChapter(text);
			return result;	
		}

		public static List<BibleBook> GenerateBibleBooks()
		{
			List<BibleBook> BibleBooks = new List<BibleBook>();	

			if (BibleBooks != null)
			{
				BibleBooks.Add(new BibleBook("Genesis", 50));
				BibleBooks.Add(new BibleBook("Exodus", 40));
				BibleBooks.Add(new BibleBook("Leviticus", 27));
				BibleBooks.Add(new BibleBook("Numbers", 36));
				BibleBooks.Add(new BibleBook("Deuteronomy", 34));
				BibleBooks.Add(new BibleBook("Joshua", 24));
				BibleBooks.Add(new BibleBook("Judges", 21));
				BibleBooks.Add(new BibleBook("Ruth", 4));
				BibleBooks.Add(new BibleBook("1Samuel", 31));
				BibleBooks.Add(new BibleBook("2Samuel", 24));
				BibleBooks.Add(new BibleBook("1Kings", 1));
				BibleBooks.Add(new BibleBook("2Kings", 25));
				BibleBooks.Add(new BibleBook("1Chronicles", 29));
				BibleBooks.Add(new BibleBook("2Chronicles", 50));
				BibleBooks.Add(new BibleBook("Ezra", 10));
				BibleBooks.Add(new BibleBook("Nehemiah", 13));
				BibleBooks.Add(new BibleBook("Esther", 10));
				BibleBooks.Add(new BibleBook("Job", 42));
				BibleBooks.Add(new BibleBook("Psalms", 150));
				BibleBooks.Add(new BibleBook("Proverbs", 31));
				BibleBooks.Add(new BibleBook("Ecclesiastes", 12));
				BibleBooks.Add(new BibleBook("Song of Songs", 8));
				BibleBooks.Add(new BibleBook("Isaiah", 66));
				BibleBooks.Add(new BibleBook("Jeremiah", 52));
				BibleBooks.Add(new BibleBook("Lamentations", 5));
				BibleBooks.Add(new BibleBook("Ezekiel", 48));
				BibleBooks.Add(new BibleBook("Daniel", 12));
				BibleBooks.Add(new BibleBook("Hosea", 14));
				BibleBooks.Add(new BibleBook("Joel", 3));
				BibleBooks.Add(new BibleBook("Amos", 9));
				BibleBooks.Add(new BibleBook("Obadiah", 1));
				return BibleBooks;
			}

			List<BibleBook> books = new List<BibleBook>();
			books.Add(new BibleBook("Error Loading Books", 0));
			return books;
		}

	}
}
