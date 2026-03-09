using TodoApi.Domain.Entities;

namespace TodoApi.Application.Abstractions;

public interface ITodoRepository
{
    Task<IReadOnlyList<TodoItem>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<TodoItem?> GetByIdAsync(Guid id, string userId, CancellationToken cancellationToken = default);
    Task AddAsync(TodoItem item, CancellationToken cancellationToken = default);
    Task UpdateAsync(TodoItem item, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, string userId, CancellationToken cancellationToken = default);
}
