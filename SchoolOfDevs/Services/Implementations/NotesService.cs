using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolOfDevs.Context;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Services.Contracts;

namespace SchoolOfDevs.Services.Implementations
{
    public class NotesService : INoteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public NotesService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<NoteDto> Create(NoteDto noteDto)
        {
            noteDto.CreatedAt = DateTime.Now;

            var newCourse = _mapper.Map<Note>(noteDto);

            _context.Entry(newCourse).State = EntityState.Added;
            _context.SaveChanges();
            return noteDto;
        }

        public async Task<NoteDto> Update(NoteDto noteDto)
        {
            var noute = await _context.Notes
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == noteDto.Id);

            noteDto.CreatedAt = noute.CreatedAt;
            noteDto.UpdatedAt = DateTime.Now;

            var updateNote = _mapper.Map<Note>(noteDto);

            updateNote.Id = noteDto.Id;

            _context.Entry(updateNote).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return noteDto;
        }
    }
}
