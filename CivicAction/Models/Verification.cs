namespace CivicAction.Models;

public class Verification
{
    public int Id { get; set; }
    public bool IsApproved { get; set; }
    public string Feedback { get; set; } = string.Empty;
    public int AdminID { get; set; }
    public int ProjectID { get; set; }

    public Account? Admin { get; set; }
    public Project? Project { get; set; }
}