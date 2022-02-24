using SchoolOfDevs.Context;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Repositories.Contracts;

namespace SchoolOfDevs.Repositories.Implementations
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
