namespace Domain.Entities.Base
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
       
    }
}
