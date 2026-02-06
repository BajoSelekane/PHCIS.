using Domain.Entities.Enums;


namespace Domain.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public  string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public EntityStatus Status { get; set; }

    }
}
