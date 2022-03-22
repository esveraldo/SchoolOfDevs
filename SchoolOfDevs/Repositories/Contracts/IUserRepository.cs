using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using System.Linq.Expressions;

namespace SchoolOfDevs.Repositories.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Login(UserAuthRequest authRequest);
    }
}
