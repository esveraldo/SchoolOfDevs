using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Repositories.Contracts;
using SchoolOfDevs.Security;
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

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository, IUserService userService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";

        [AllowAnonymous]
        [HttpGet]
        [Route("listar-todos-usuarios")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userRepository.GetAll();
            return Ok(result);
        }

        [Authorize(Roles = "manager")]
        [HttpGet]
        [Route("usuario-selecionado/{id}")]
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

        [AllowAnonymous]//QUALQUER USUÁRIO PODE ACESSAR ESSE MÉTODO
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
                userDto.Role = userRequest.Role;

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
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserAuthRequest authRequest)
        {
            // Recupera o usuário
            var user = UserRepository.Get(authRequest.UserName, authRequest.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
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
                userDto.Role = userRequest.Role;

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