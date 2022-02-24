using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolOfDevs.Context;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Repositories.Contracts;
using SchoolOfDevs.Services.Contracts;
using BC = BCrypt.Net.BCrypt;

namespace SchoolOfDevs.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        //private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, ApplicationDbContext context) //IUserRepository userRepository
                       
        {
            //_userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDto> Create(UserDto userDto)
        {
            var user = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.UserName == userDto.UserName);

            if (user is not null)
                throw new Exception($"Usuário {userDto.UserName} já existe.");

            if (!userDto.Password.Equals(userDto.ConfirmPassword))
                throw new Exception("A senha não confere com a confirmação.");

            userDto.CreatedAt = DateTime.Now;

            var newUser = _mapper.Map<User>(userDto);

            newUser.Password = BC.HashPassword(newUser.Password);

            _context.Entry(newUser).State = EntityState.Added;
            _context.SaveChanges();
            return userDto;
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            if (!userDto.Password.Equals(userDto.ConfirmPassword))
                throw new Exception("A senha não confere com a confirmação.");

            var user = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == userDto.Id);


            if (!BC.Verify(userDto.Password, user.Password))
                throw new Exception("As senhas não conferem.");

            userDto.CreatedAt = user.CreatedAt;
            userDto.UpdatedAt = DateTime.Now;
            userDto.Password = BC.HashPassword(userDto.Password);

            var updateUser = _mapper.Map<User>(userDto);

            updateUser.Id = userDto.Id;

            _context.Entry(updateUser).State = EntityState.Modified;   
            await _context.SaveChangesAsync();
            return userDto;
        }
    }
}
