using SchoolOfDevs.Entities.Base;

namespace SchoolOfDevs.Entities
{
    public class Course : BaseEntity
    {
        public string ?Name { get; set; }
        public decimal Price { get; set; }

        //EF
        public virtual ICollection<Note>? Notes { get; set; }
        //REALCIONAMENTO MUITOS PARA MUITOS
        public virtual ICollection<User>? Users { get; set; }
        public virtual List<UserCourse>? UserCourses { get; set; }
    }
}
