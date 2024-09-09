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
			var verse = await _externalApiService.GetAPIResponse<VerseAPIResponse>(_client, $"{AppSettings.azureBaseAdress}/GetVerseOfTheDay");
			var result = Verse_Mapper.VerseMapper(verse);
			UserCookies.VerseOfTheDay = result;
			return result;
		}

		public async Task UpdateUserBibleReadingStreak()
		{
			await _externalApiService.PutAPIRequest($"{AppSettings.azureBaseAdress}/api/User/UpdateUserReadingStreak?userId={UserCookies.currentUser.Id}", "");
		}

		public async Task<string> GetBibleChapterText(string chapterTitle, int chapterNumber) 
		{
			var response = await _externalApiService.GetAPIResponse<ChapterTextAPIResponse>(_client, $"{AppSettings.azureBaseAdress}/GetBibleChapter?book={chapterTitle}&chapter={chapterNumber}");
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
				BibleBooks.Add(new BibleBook("Jonah", 4));
				BibleBooks.Add(new BibleBook("Micah", 7));
				BibleBooks.Add(new BibleBook("Nahum", 3));
				BibleBooks.Add(new BibleBook("Habakkuk", 3));
				BibleBooks.Add(new BibleBook("Zephaniah", 3));
				BibleBooks.Add(new BibleBook("Haggai", 2));
				BibleBooks.Add(new BibleBook("Zechariah", 14));
				BibleBooks.Add(new BibleBook("Malachi", 4));
				BibleBooks.Add(new BibleBook("Matthew", 28));
				BibleBooks.Add(new BibleBook("Mark", 16));
				BibleBooks.Add(new BibleBook("Luke", 24));
				BibleBooks.Add(new BibleBook("John", 21));
				BibleBooks.Add(new BibleBook("Acts", 28));
				BibleBooks.Add(new BibleBook("Romans", 16));
				BibleBooks.Add(new BibleBook("1 Corinthians", 16));
				BibleBooks.Add(new BibleBook("2 Corinthians", 13));
				BibleBooks.Add(new BibleBook("Galations", 6));
				BibleBooks.Add(new BibleBook("Ephesians", 6));
				BibleBooks.Add(new BibleBook("Philippians", 4));
				BibleBooks.Add(new BibleBook("Colossians", 4));
				BibleBooks.Add(new BibleBook("1 Thessalonians", 5));
				BibleBooks.Add(new BibleBook("2 Thessalonians", 3));
				BibleBooks.Add(new BibleBook("1 Timothy", 6));
				BibleBooks.Add(new BibleBook("2 Timothy", 4));
				BibleBooks.Add(new BibleBook("Titus", 3));
				BibleBooks.Add(new BibleBook("Philemon", 1));
				BibleBooks.Add(new BibleBook("Hebrews", 13));
				BibleBooks.Add(new BibleBook("James", 5));
				BibleBooks.Add(new BibleBook("1 Peter", 5));
				BibleBooks.Add(new BibleBook("2 Peter", 3));
				BibleBooks.Add(new BibleBook("1 John", 5));
				BibleBooks.Add(new BibleBook("2 John", 1));
				BibleBooks.Add(new BibleBook("3 John", 1));
				BibleBooks.Add(new BibleBook("Jude", 1));
				BibleBooks.Add(new BibleBook("Revelation", 22));


				return BibleBooks;
			}

			List<BibleBook> books = new List<BibleBook>();
			books.Add(new BibleBook("Error Loading Books", 0));
			return books;
		}

	}
}
