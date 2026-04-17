namespace CivicAction.Models;

public class Update
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public double HoursDone { get; set; }
    public int StudentID { get; set; }
    public int ProjectID { get; set; }

    public Project? Project { get; set; }
}