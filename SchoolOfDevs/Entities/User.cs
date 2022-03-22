using SchoolOfDevs.Entities.Base;
using SchoolOfDevs.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolOfDevs.Entities
{
    public class User : BaseEntity
    {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public int Age { get; set; }
        public string? UserName { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        public string? Role { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string? ConfirmPassword { get; set; }
        public TypeUserEnum TypeUser { get; set; }

        //EF
        public virtual ICollection<Note>? Notes { get; set; }
        //REALCIONAMENTO MUITOS PARA MUITOS
        public virtual ICollection<Course>? Courses { get; set; }
        public virtual List<UserCourse>? UserCourses { get; set; }
    }
}
