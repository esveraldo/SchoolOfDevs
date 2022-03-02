namespace SchoolOfDevs.Entities
{
    public class UserCourse
    {
        //CLASSE PIVOT DE MUITOS PARA MUITOS
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public virtual User? User { get; set; }
        public virtual Course? Course { get; set; }
    }
}
