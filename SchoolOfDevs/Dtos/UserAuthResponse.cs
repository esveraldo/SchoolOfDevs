using SchoolOfDevs.Entities;

namespace SchoolOfDevs.Dtos
{
    public class UserAuthResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public UserAuthResponse(User user, string token = null)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Role = user.Role;
            Token = token;
        }
    }
}
