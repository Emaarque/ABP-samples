namespace TodoApp.Services.Dtos;

public class TodoItemDto
{
    public Guid Id { get; set; }
    public string? Text { get; set; }

//    public Guid CreatorId { get; set; } // Incluido CreatorId

}
