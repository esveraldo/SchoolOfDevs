using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolOfDevs.Context;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Exceptions;
using SchoolOfDevs.Repositories.Contracts;
using SchoolOfDevs.Security;
using SchoolOfDevs.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace SchoolOfDevs.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<UserDto> Create(UserDto userDto)
        {
            var user = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.UserName == userDto.UserName);

            if (user is not null)
                throw new KeyNotFoundException($"Usuário {userDto.UserName} já existe.");

            if (!userDto.Password.Equals(userDto.ConfirmPassword))
                throw new BadRequestException("A senha não confere com a confirmação.");

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
                throw new BadRequestException("A senha não confere com a confirmação.");

            var user = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == userDto.Id);

            if (user is null)
                throw new KeyNotFoundException($"{user.Id} não existe.");

            if (!BC.Verify(userDto.Password, user.Password))
                throw new BadRequestException("As senhas não conferem.");

            userDto.CreatedAt = user.CreatedAt;
            userDto.UpdatedAt = DateTime.Now;
            userDto.Password = BC.HashPassword(userDto.Password);

            var updateUser = _mapper.Map<User>(userDto);

            updateUser.Id = userDto.Id;

            _context.Entry(updateUser).State = EntityState.Modified;   
            await _context.SaveChangesAsync();
            return userDto;
        }

        public User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, UserName = "batman", Password = "batman", Role = "admin" });
            users.Add(new User { Id = 2, UserName = "robin", Password = "robin", Role = "empregado" });
            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
