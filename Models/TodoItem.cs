namespace TodoApi.Models;

// The data model for one todo-item
public class TodoItem 
{
    // unique id for every todo
    public int Id { get; set; }

    // title / description for the task
    public string Title { get; set; } = string.Empty;

    // indicator if the task is done or not
    public bool IsDone { get; set; }
}