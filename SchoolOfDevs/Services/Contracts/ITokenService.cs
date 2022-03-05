using SchoolOfDevs.Dtos;

namespace SchoolOfDevs.Services.Contracts
{
    public interface ITokenService
    {
        public string GenerateToken(UserDto userDto);
    }
}
