using Logic.API.ApiResponses;
using Logic.Models;

namespace Logic.Mappers
{
	public class UserByGroup_Mapper
	{
		public static User UserByGroupMapper(UserByGroupIdAPIResponse response)
		{
			User user = new User();
			user.FirstName = response.firstName;
			user.LastName = response.lastName;
			user.Email = response.email;
			user.Id = response.id;
			user.PhoneNumber = response.phoneNumber;
			user.IsVerified = response.isVerified;
			user.Gender = response.gender;
			user.IsActive = response.isActive;
			user.RoleId = response.roleId;
			user.GroupId = response.groupId;

			return user;
		}

		public static List<User> UserByGroupMapperList(List<UserByGroupIdAPIResponse> responses)
		{
			List<User> users = new List<User>();

			foreach (var response in responses)
			{
				User user = new User();
				user.FirstName = response.firstName;
				user.LastName = response.lastName;
				user.Email = response.email;
				user.Id = response.id;
				user.PhoneNumber = response.phoneNumber;
				user.IsActive = response.isActive;
				user.RoleId = response.roleId;

				users.Add(user);
			}

			return users;
		}



		public static List<User> UserCollectionMapper(IEnumerable<UserCollectionAPIResponse> responses)
		{
			List<User> users = new List<User>();

			foreach (var response in responses)
			{
				User user = new User();
				user.FirstName = response.firstName;
				user.LastName = response.lastName;
				user.Email = response.email;
				user.Id = response.id;
				user.PhoneNumber = response.phoneNumber;
				user.IsActive = response.isActive;
				user.RoleId = response.roleId;
				user.Gender = response.gender;
				user.Grade = response.grade;

				users.Add(user);
			}

			return users;
		}
	}
}
