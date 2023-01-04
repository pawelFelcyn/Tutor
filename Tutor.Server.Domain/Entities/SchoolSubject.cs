namespace Tutor.Server.Domain.Entities;

public class SchoolSubject
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual List<Advertisement> Advertisements { get; set; }
}
