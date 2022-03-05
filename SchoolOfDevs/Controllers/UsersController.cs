using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Repositories.Contracts;
using SchoolOfDevs.Services.Contracts;

namespace SchoolOfDevs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository, IUserService userService, ITokenService tokenService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("listar-todos-usuarios")]
        [AllowAnonymous]//QUALQUER USUÁRIO PODE ACESSAR ESSE MÉTODO
        public async Task<IActionResult> GetAll()
        {
            var result = await _userRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("usuario-selecionado/{id}")]
        //[Authorize]//SÓ USUÁRIOS AUTENTICADOS PODEM ACESSAR ESSE MÉTODO
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userRepository.Get(id);
            return Ok(result);
        }

        //[HttpGet]
        //[Route("Autenticado")]
        //[Authorize]
        //public string Autenticado()
        //{
        //    return $"Autenticado - {UserDto.Identity.Name}";
        //}

        [HttpPost]
        [Route("gravar-usuario")]
        //[Authorize(Roles = "Gerente")]//SOMENTE USUÁRIOS COM STATUS DE GERENTE PODEM ACESSAR ESSE MÉTODO
        public async Task<IActionResult> Create([FromBody] UserRequest userRequest)
        {
            if (!ModelState.IsValid) return BadRequest("O Modelo está incorreto.");
            try
            {
                UserDto userDto = new UserDto();
                userDto.FirstName = userRequest.FirstName;
                userDto.LastName = userRequest.LastName;
                userDto.Age = userRequest.Age;
                userDto.TypeUser = userRequest.TypeUser;
                userDto.UserName = userRequest.UserName;
                userDto.Password = userRequest.Password;
                userDto.ConfirmPassword = userRequest.ConfirmPassword;

                await _userService.Create(userDto);

                return Ok(userDto);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Authenticate([FromBody] UserDto userDto)
        {
            var u = await _userService.Login(userDto);

            if (userDto == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _tokenService.GenerateToken(u);

            u.Password = "";

            var result = new
            {
                user = u,
                token = token
            };

            return Ok(result);
        }

        [HttpPut]
        [Route("atualizar-usuario/{id}")]
        public async Task<IActionResult> Update([FromBody] UserRequest userRequest)
        {
            if(!ModelState.IsValid) return BadRequest("O modelo está incorreto");

            try
            {
                UserDto userDto = new UserDto();
                userDto.Id = userRequest.Id;
                userDto.FirstName = userRequest.FirstName;
                userDto.LastName = userRequest.LastName;
                userDto.Age = userRequest.Age;
                userDto.TypeUser = userRequest.TypeUser;
                userDto.UserName = userRequest.UserName;
                userDto.Password = userRequest.Password;
                userDto.ConfirmPassword = userRequest.ConfirmPassword;

                await _userService.Update(userDto);

                return Ok(userDto);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("remover-usuario/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            if(!ModelState.IsValid) return BadRequest("O modelo está incorreto");

            try
            {
                await _userRepository.DeleteAsync(id);
                return Ok("Usuário removido.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}