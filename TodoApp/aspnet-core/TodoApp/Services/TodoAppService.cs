using TodoApp.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using TodoApp.Services;
using TodoApp.Services.Dtos;
using TodoApp.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace TodoApp.Services;

public class TodoAppService : ApplicationService
{
    private readonly IRepository<TodoItem, Guid> _todoItemRepository;

    public TodoAppService(IRepository<TodoItem, Guid> todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    // TODO: Implement the methods here...
    [Authorize(TodoAppPermissions.Todos.View)]
    public async Task<List<TodoItemDto>> GetListAsync()
    {
        var items = await _todoItemRepository.GetListAsync();
        return items
            .Select(item => new TodoItemDto
            {
                Id = item.Id,
                Text = item.Text
            }).ToList();
    }

    [Authorize(TodoAppPermissions.Todos.Create)]
    public async Task<TodoItemDto> CreateAsync(string text)
    {
        var todoItem = await _todoItemRepository.InsertAsync(
            new TodoItem { Text = text }
        );

        return new TodoItemDto
        {
            Id = todoItem.Id,
            Text = todoItem.Text
        };
    }

    [Authorize(TodoAppPermissions.Todos.Delete)]
    public async void DeleteAsync(Guid id)
    {
        await _todoItemRepository.DeleteAsync(id);
    }
}
