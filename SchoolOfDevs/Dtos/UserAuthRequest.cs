using SchoolOfDevs.Entities;

namespace SchoolOfDevs.Dtos
{
    public class UserAuthRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
