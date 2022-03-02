using Microsoft.AspNetCore.Mvc;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Repositories.Contracts;
using SchoolOfDevs.Services.Contracts;

namespace SchoolOfDevs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class NotesController : Controller
    {
        private readonly ILogger<NotesController> _logger;
        private readonly INoteRepository _noteRepository;
        private readonly INoteService _noteService;

        public NotesController(ILogger<NotesController> logger, INoteRepository noteRepository, INoteService noteService)
        {
            _logger = logger;
            _noteRepository = _noteRepository;
            _noteService = noteService;
        }

        [HttpGet]
        [Route("listar-todas-notas")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _noteRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("nota-selecionada/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _noteRepository.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("gravar-nota")]
        public async Task<IActionResult> Create([FromBody] NoteRequest noteRequest)
        {
            if (!ModelState.IsValid) return BadRequest("O Modelo está incorreto.");
            try
            {
                NoteDto noteDto = new NoteDto();
                noteDto.Value = noteRequest.Value;

                await _noteService.Create(noteDto);

                return Ok(noteDto);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("atualizar-usuario/{id}")]
        public async Task<IActionResult> Update([FromBody] NoteRequest noteRequest)
        {
            if (!ModelState.IsValid) return BadRequest("O modelo está incorreto");

            try
            {
                NoteDto noteDto = new NoteDto();
                noteDto.Value = noteRequest.Value;

                await _noteService.Update(noteDto);

                return Ok(noteDto);
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
                await _noteRepository.DeleteAsync(id);
                return Ok("Usuário removido.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
