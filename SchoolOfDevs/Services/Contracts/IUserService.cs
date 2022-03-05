using AutoMapper;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;

namespace SchoolOfDevs.Services.Contracts
{
    public interface IUserService
    {
        public Task<UserDto> Create(UserDto userDto);
        public Task<UserDto> Update(UserDto userDto);
        public Task<UserDto> Login(UserDto userDto);
    }
}
