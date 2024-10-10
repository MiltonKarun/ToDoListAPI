using System.ComponentModel.DataAnnotations;

public class ToDoItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100, ErrorMessage = "Title can be a maximum of 100 characters")]
    public string Title { get; set; }

    [MaxLength(500, ErrorMessage = "Description can be a maximum of 500 characters")]
    public string Description { get; set; }

    public DateTime? DueDate { get; set; }

    public bool Completed { get; set; } = false;
}
