namespace Domain.Entities.Visit;

public enum VisitStatus
{
    Pending,
    Accepted,
    Denied
}

public enum VisitType
{
    InPerson,
    Virtual
}

public class Visit : BaseEntity
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public required string Reason { get; set; }
    required public VisitStatus VisitStatus { get; set; } = VisitStatus.Pending;
    required public VisitType Type { get; set; } = VisitType.InPerson;
    public string? Location { get; set; }
    required public string PatientName { get; set; }
    required public string PatientPhoneNumber { get; set; }
    public string? Description { get; set; }

    public required ApplicationUser ApplicationUser { get; set; }
}

