namespace Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(200)]
        public required string FullName { get; set; }
        public string? LandLine { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        
        public ICollection<Visit>? Visits { get; set; } = new List<Visit>();

    }
}
