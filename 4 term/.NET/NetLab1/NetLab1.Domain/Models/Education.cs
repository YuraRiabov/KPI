using NetLab1.Domain.Models.Enums;

namespace NetLab1.Domain.Models;

public class Education
{
    public long Id { get; set; }

    public Degree Degree { get; set; }

    public DateTimeOffset Start { get; set; }
    
    public DateTimeOffset End { get; set; }
    
    public Major Major { get; set; }
    
    public long PersonId { get; set; }
}