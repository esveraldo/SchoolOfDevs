using Microsoft.AspNetCore.Mvc;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Repositories.Contracts;
using SchoolOfDevs.Services.Contracts;

namespace SchoolOfDevs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CousesController : Controller
    {
        private readonly ILogger<CousesController> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseService _courseService;

        public CousesController(ILogger<CousesController> logger, ICourseRepository courseRepository, ICourseService courseService)
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _courseService = courseService;
        }

        [HttpGet]
        [Route("listar-todos-cursos")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("curso-selecionada/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _courseRepository.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("gravar-curso")]
        public async Task<IActionResult> Create([FromBody] CourseRequest courseRequest)
        {
            if (!ModelState.IsValid) return BadRequest("O Modelo está incorreto.");
            try
            {
                CourseDto courseDto = new CourseDto();
                courseDto.Name = courseRequest.Name;   
                courseDto.Price = courseRequest.Price;

                await _courseService.Create(courseDto);

                return Ok(courseDto);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("atualizar-usuario/{id}")]
        public async Task<IActionResult> Update([FromBody] CourseRequest courseRequest)
        {
            if (!ModelState.IsValid) return BadRequest("O modelo está incorreto");

            try
            {
                CourseDto courseDto = new CourseDto();
                courseDto.Id = courseRequest.Id;

                await _courseService.Update(courseDto);

                return Ok(courseDto);
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
            if (!ModelState.IsValid) return BadRequest("O modelo está incorreto");

            try
            {
                await _courseRepository.DeleteAsync(id);
                return Ok("Usuário removido.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
