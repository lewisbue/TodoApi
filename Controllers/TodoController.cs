using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers;

// marks controller as REST-API
[ApiController]

// api is accessible under /api/todo
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _repository;

    // repository gets provided from dependency injection
    public TodoController(ITodoRepository repository)
    {
        _repository = repository;
    }

    // GET /api/todo - get all todos
    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> GetAll() => Ok(_repository.GetAll());

    // GET /api/todo{id} - get a single todo
    [HttpGet("{id}")]
    public ActionResult<TodoItem> Get(int Id)
    {
        var item = _repository.GetById(Id);
        return item is null ? NotFound() : Ok(item);
    }

    // POST /api/todo - create new todo item
    [HttpPost]
    public ActionResult<TodoItem> Create(TodoItem item)
    {
        _repository.Add(item);
        return CreatedAtAction(nameof(Get), new { Id = item.Id }, item);
    }

    // PUT /api/todo{idf} - update existing todo
    [HttpPut("{id}")]
    public IActionResult Update(int Id, TodoItem item)
    {
        if (Id != item.Id) return BadRequest();
        _repository.Update(item);
        return NoContent(); // no return value needed
    }

    // DELETE /api/todo{id} - delete one todo
    [HttpDelete("{id}")]
    public IActionResult Delete(int Id)
    {
        _repository.Delete(Id);
        return NoContent();
    }
}
