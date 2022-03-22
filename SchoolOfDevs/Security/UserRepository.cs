using SchoolOfDevs.Entities;

namespace SchoolOfDevs.Security
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, UserName = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, UserName = "robin", Password = "robin", Role = "employee" });
            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
