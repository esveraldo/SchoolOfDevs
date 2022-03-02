using SchoolOfDevs.Entities.Base;

namespace SchoolOfDevs.Entities
{
    public class Note : BaseEntity
    {
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public User? User { get; set; }
        public Course? Course { get; set; }
    }
}
