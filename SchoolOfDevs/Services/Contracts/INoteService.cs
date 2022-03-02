using SchoolOfDevs.Dtos;

namespace SchoolOfDevs.Services.Contracts
{
    public interface INoteService
    {
        public Task<NoteDto> Create(NoteDto noteDto);
        public Task<NoteDto> Update(NoteDto noteDto);
    }
}
