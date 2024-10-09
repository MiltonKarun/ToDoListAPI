using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
[Authorize]
public class ToDoController : ControllerBase
{
    private readonly ToDoRepository _repository;

    public ToDoController(ToDoRepository repository)
    {
        _repository = repository;
    }


    [HttpPost]
    public IActionResult Create([FromBody] ToDoItem toDoItem)
    {
        var newToDo = _repository.Create(toDoItem);
        return CreatedAtAction(nameof(GetById), new { id = newToDo.Id }, newToDo);
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string? status, [FromQuery] string? sortBy)
    {
        var todos = _repository.GetAll(status, sortBy);
        return Ok(todos);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var toDo = _repository.GetById(id);
        if (toDo == null)
            return NotFound();
        return Ok(toDo);
    }

    // PUT /todos/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ToDoItem updatedToDo)
    {
        var toDo = _repository.GetById(id);
        if (toDo == null)
            return NotFound();
        _repository.Update(updatedToDo);
        return NoContent();
    }

    // DELETE /todos/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var toDo = _repository.GetById(id);
        if (toDo == null)
            return NotFound();
        _repository.Delete(id);
        return NoContent();
    }
}
