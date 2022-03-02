using SchoolOfDevs.Dtos;

namespace SchoolOfDevs.Services.Contracts
{
    public interface ICourseService
    {
        public Task<CourseDto> Create(CourseDto courseDto);
        public Task<CourseDto> Update(CourseDto courseDto);
    }
}
