using TodoApi.Models;

namespace TodoApi.Repositories;

// simply implementation to hold data in storage
public class InMemoryTodoRepository : ITodoRepository
{
    // list of all todo-elements
    private readonly List<TodoItem> _items = new();

    //automatic id assignment
    private int _nextId = 1;

    public IEnumerable<TodoItem> GetAll() => _items;

    public TodoItem? GetById(int Id) => _items.FirstOrDefault(i => i.Id == Id);

    public void Add(TodoItem item)
    {
        item.Id = _nextId++; // get new id
        _items.Add(item);
    }

    public void Update(TodoItem item)
    {
        var existing = GetById(item.Id);
        if (existing is null) return;

        // rewrite fields
        existing.Title = item.Title;
        existing.IsDone = item.IsDone;
    }

    public void Delete(int Id)
    {
        var item = GetById(Id);
        if (item is not null)
        {
            _items.Remove(item);
        }
    }
}