using TaskTracker.Models;

namespace TaskTracker.Services;

public class TaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    // Create
    public TaskItem Create(string title, string priority)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            Priority = priority,
            IsDone = false
        };
        _tasks.Add(task);
        return task;
    }

    // comment test 2

    // Read
    public List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public TaskItem? GetById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    // Update
    public bool UpdateTitle(int id, string newTitle)
    {
        var task = GetById(id);
        if (task is null) return false;
        task.Title = newTitle;
        return true;
    }

    public bool ToggleDone(int id)
    {
        var task = GetById(id);
        if (task is null) return false;
        task.IsDone = !task.IsDone;
        return true;
    }

    // Delete
    public bool Delete(int id)
    {
        var task = GetById(id);
        if (task is null) return false;
        _tasks.Remove(task);
        return true;
    }
}
