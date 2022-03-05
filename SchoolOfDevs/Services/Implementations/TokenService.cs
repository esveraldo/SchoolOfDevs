using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Security;
using SchoolOfDevs.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolOfDevs.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<TokenService> _logger;
        private readonly IMapper _mapper;
        public TokenService(AppSettings appSettings, ILogger<TokenService> logger, IMapper mapper)
        {
            _appSettings = appSettings;
            _logger = logger;
            _mapper = mapper;
        }
        public string GenerateToken(UserDto userDto)
        {
            var userAuthenticate = _mapper.Map<User>(userDto);
            var TokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    //new Claim(ClaimTypes.Name, userAuthenticate.UserName.ToString()),
                    new Claim(ClaimTypes.Name, userAuthenticate.Id.ToString()),
                    new Claim(ClaimTypes.Role, userAuthenticate.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }
    }
}
