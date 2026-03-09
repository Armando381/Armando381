using TodoApi.Application.Abstractions;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Persistence;

public class InMemoryTodoRepository : ITodoRepository
{
    private static readonly List<TodoItem> Items = [];

    public Task<IReadOnlyList<TodoItem>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
        => Task.FromResult<IReadOnlyList<TodoItem>>(Items.Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedAtUtc).ToList());

    public Task<TodoItem?> GetByIdAsync(Guid id, string userId, CancellationToken cancellationToken = default)
        => Task.FromResult(Items.FirstOrDefault(x => x.Id == id && x.UserId == userId));

    public Task AddAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        Items.Add(item);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TodoItem item, CancellationToken cancellationToken = default) => Task.CompletedTask;

    public Task DeleteAsync(Guid id, string userId, CancellationToken cancellationToken = default)
    {
        var entity = Items.FirstOrDefault(x => x.Id == id && x.UserId == userId);
        if (entity is not null) Items.Remove(entity);
        return Task.CompletedTask;
    }
}
