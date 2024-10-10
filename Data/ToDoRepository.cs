public class ToDoRepository
{
    private readonly List<ToDoItem> _toDoItems = new List<ToDoItem>();
    private int _nextId = 1;

    // Get all to-do items based on parameters
    public IEnumerable<ToDoItem> GetAll(string? status = null, string? sortBy = null, DateTime? dueDate = null)
    {
        var items = _toDoItems.AsEnumerable();

        if (!string.IsNullOrEmpty(status))
        {
            if (status == "completed")
                items = items.Where(t => t.Completed);
            else if (status == "pending")
                items = items.Where(t => !t.Completed);
        }

        if (dueDate.HasValue)
        {
            Console.WriteLine(dueDate);
            items = items.Where(t => t.DueDate.HasValue && t.DueDate.Value.Date == dueDate.Value.Date);
        }

        if (!string.IsNullOrEmpty(sortBy) && sortBy == "title")
            items = items.OrderBy(t => t.Title);

        if (!string.IsNullOrEmpty(sortBy) && sortBy == "dueDate")
            items = items.OrderBy(t => t.DueDate);

        return items;
    }

    // Get a to-do item based on given ID
    public ToDoItem GetById(int id) => _toDoItems.FirstOrDefault(t => t.Id == id);

    // Create a new to-do item
    public ToDoItem Create(ToDoItem toDoItem)
    {
        toDoItem.Id = _nextId++;
        _toDoItems.Add(toDoItem);
        return toDoItem;
    }

    // Update a to-do item
    public void Update(ToDoItem toDoItem)
    {
        var existing = GetById(toDoItem.Id);
        if (existing != null)
        {
            existing.Title = toDoItem.Title;
            existing.Description = toDoItem.Description;
            existing.DueDate = toDoItem.DueDate;
            existing.Completed = toDoItem.Completed;
        }
    }

    // Delete a to-do item
    public void Delete(int id) => _toDoItems.RemoveAll(t => t.Id == id);
}
