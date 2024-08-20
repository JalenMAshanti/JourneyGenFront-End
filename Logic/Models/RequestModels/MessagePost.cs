namespace Logic.Models.RequestModels
{
	public class MessagePost
	{
		public int GroupId { get; set; }
		public string? Content { get; set; }
		public int UserId { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
