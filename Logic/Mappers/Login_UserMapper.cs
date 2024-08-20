using Logic.API.ApiResponses;
using Logic.Models;

namespace Logic.Mappers
{
    public class Login_UserMapper
    {
        public static User LoginUserMapper(LoginApiResponse response) 
        {
            User user = new User();
            user.Id = response.id;
            user.FirstName = response.firstName;
            user.LastName = response.lastName;
            user.Email = response.email;
            user.IsVerified = response.isVerified;
            user.PhoneNumber = response.phoneNumber;
            user.GroupId = response.groupId;
            user.Grade = response.grade;
            user.RoleId = response.roleId;
            user.TempKey = response.tempKey;
            user.Gender = response.gender;
            user.ReadingStreak = response.ReadingStreak;
            return user;
        }
    }
}
