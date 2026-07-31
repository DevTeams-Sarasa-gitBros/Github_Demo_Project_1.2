namespace TaskTracker.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Priority { get; set; } = "Medium";
    public bool IsDone { get; set; }

    public override string ToString()
    {
        var status = IsDone ? "x" : " ";
        return $"[{status}] #{Id,-3} {Title,-25} ({Priority})";
    }

    // test 3
}
