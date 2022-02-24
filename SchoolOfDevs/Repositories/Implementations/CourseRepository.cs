using SchoolOfDevs.Context;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Repositories.Contracts;

namespace SchoolOfDevs.Repositories.Implementations
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
