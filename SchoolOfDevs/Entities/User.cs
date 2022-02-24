using SchoolOfDevs.Entities.Base;
using SchoolOfDevs.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolOfDevs.Entities
{
    public class User : BaseEntity
    {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public int Age { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        [NotMapped]
        public string? ConfirmPassword { get; set; }
        public TypeUserEnum TypeUser { get; set; }
    }
}
