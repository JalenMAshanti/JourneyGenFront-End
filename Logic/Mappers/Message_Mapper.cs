using Logic.API.ApiResponses;
using Logic.Models;

namespace Logic.Mappers
{
	public class Message_Mapper
	{
		public static IEnumerable<Message> MapMessage(IEnumerable<MessagesAPIResponse> response)
		{ 
			List<Message> messages = new List<Message>();
			foreach (MessagesAPIResponse message in response) 
			{
				Message message1 = new Message();

				message1.UserId = message.userId;
				message1.PostId = message.postId;
				message1.GroupId = message.groupId;
				message1.Content = message.content;
				message1.DatePosted = message.datePosted;
				message1.FirstName = message.firstName;
				message1.LastName = message.lastName;	
				
				messages.Add(message1);
				
			}

			return messages;
		}

	}
}
