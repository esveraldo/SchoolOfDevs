namespace SchoolOfDevs.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        private DateTime _createdAt;

        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value == null ? DateTime.Now : value; }
        }

        public DateTime UpdatedAt { get; set; }
    }
}
