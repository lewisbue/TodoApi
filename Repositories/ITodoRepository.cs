using TodoApi.Models;

namespace TodoApi.Repositories;

// interface for todo data access
public interface ITodoRepository
{
    IEnumerable<TodoItem> GetAll();         // get all elements
    TodoItem? GetById(int Id);              // get one element with the id
    void Add(TodoItem item);                // add new element
    void Update(TodoItem item);             // update existing element
    void Delete(int Id);                    // delete element with id
}