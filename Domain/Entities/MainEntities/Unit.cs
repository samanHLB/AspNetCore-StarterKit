namespace Domain.Entities.MainEntities;

public class Unit : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Specialization { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfJoining { get; set; }

    public ICollection<Visit>? Visits { get; set; } = new List<Visit>();
}
