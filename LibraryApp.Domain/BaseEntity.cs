namespace LibraryApp.Domain
{
    public abstract class BaseEntity(Guid id)
    {
        public Guid Id { get; set; } = id;
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public void Delete()
        {
            IsActive = false;
        }
    } 
}