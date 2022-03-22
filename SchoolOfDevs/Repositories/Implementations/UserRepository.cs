using AutoMapper;
using SchoolOfDevs.Context;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Repositories.Contracts;
using BC = BCrypt.Net.BCrypt;

namespace SchoolOfDevs.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<User> Login(UserAuthRequest authRequest)
        {
            var _result = _context.Users.FirstOrDefault(u => u.UserName == authRequest.UserName && u.Password == authRequest.Password);
            return _result;
        }
    }
}
