namespace CivicAction.Models;


public class Project
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Hours { get; set; }
    public string Organization { get; set; } = string.Empty;
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
    public int StudentID { get; set; }
    public bool IsApproved { get; set; }

    public Account? Student { get; set; }
    public ICollection<Update> Updates { get; set; } = new List<Update>();
    public ICollection<Verification> Verifications { get; set; } = new List<Verification>();
}