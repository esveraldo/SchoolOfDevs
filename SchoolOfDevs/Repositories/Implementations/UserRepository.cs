using Microsoft.EntityFrameworkCore;
using SchoolOfDevs.Context;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Repositories.Contracts;
using System.Linq.Expressions;

namespace SchoolOfDevs.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
