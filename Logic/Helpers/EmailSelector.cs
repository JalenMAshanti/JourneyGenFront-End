using Logic.Models;

namespace Logic.Helpers
{
	public class EmailSelector
	{
		public static string SelectEmailsFromListOfUsers(IEnumerable<User> users) 
		{
			var result = string.Join(",", users.Select(a => a.Email));
			return result;
		}
	}
}
