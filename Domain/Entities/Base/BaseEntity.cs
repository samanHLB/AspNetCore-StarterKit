﻿namespace Domain.Entities.Base;

public class BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
    [MaxLength(100)]
    public string? CreatedBy { get; set; }
    [MaxLength(100)]
    public string? UpdatedBy { get; set; }
   
}
