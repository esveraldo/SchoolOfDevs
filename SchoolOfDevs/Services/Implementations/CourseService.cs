using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolOfDevs.Context;
using SchoolOfDevs.Dtos;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Services.Contracts;

namespace SchoolOfDevs.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CourseService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CourseDto> Create(CourseDto courseDto)
        {
            courseDto.CreatedAt = DateTime.Now;

            var newCourse = _mapper.Map<Course>(courseDto);

            _context.Entry(courseDto).State = EntityState.Added;
            _context.SaveChanges();
            return courseDto;
        }

        public async Task<CourseDto> Update(CourseDto courseDto)
        {
            var noute = await _context.Courses
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == courseDto.Id);

            courseDto.CreatedAt = noute.CreatedAt;
            courseDto.UpdatedAt = DateTime.Now;

            var updateCourse = _mapper.Map<Note>(courseDto);

            updateCourse.Id = courseDto.Id;

            _context.Entry(updateCourse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return courseDto;
        }
    }
}
