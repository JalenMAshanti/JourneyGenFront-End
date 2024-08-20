using Logic.Models;

namespace JourneyGen_UI.Models
{
	public class ManageUserViewModel
	{
		public int SelectedUserId { get; set; }
		public int SelectedUserGroupId { get; set; }

		public IEnumerable<User>? Leaders {  get; set; }
		public IEnumerable<User>? LeadersWaiting { get; set; }
		public IEnumerable<User>? StudentsWaiting { get; set; }
	}
}
