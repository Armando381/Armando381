using TodoApi.Application.Abstractions;
using TodoApi.Application.DTOs;
using TodoApi.Domain.Entities;

namespace TodoApi.Application.Services;

public class TodoService(ITodoRepository repository)
{
    public async Task<IReadOnlyList<TodoResponse>> GetMineAsync(string userId, CancellationToken ct)
    {
        var items = await repository.GetByUserIdAsync(userId, ct);
        return items.Select(Map).ToList();
    }

    public async Task<TodoResponse> CreateAsync(string userId, CreateTodoRequest request, CancellationToken ct)
    {
        var entity = new TodoItem
        {
            Title = request.Title,
            Description = request.Description,
            UserId = userId
        };

        await repository.AddAsync(entity, ct);
        return Map(entity);
    }

    public async Task<TodoResponse?> UpdateAsync(Guid id, string userId, UpdateTodoRequest request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(id, userId, ct);
        if (entity is null)
        {
            return null;
        }

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.IsCompleted = request.IsCompleted;

        await repository.UpdateAsync(entity, ct);
        return Map(entity);
    }

    public Task DeleteAsync(Guid id, string userId, CancellationToken ct) => repository.DeleteAsync(id, userId, ct);

    private static TodoResponse Map(TodoItem item) =>
        new(item.Id, item.Title, item.Description, item.IsCompleted, item.CreatedAtUtc);
}
