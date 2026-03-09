namespace TodoApi.Application.DTOs;

public record CreateTodoRequest(string Title, string? Description);
public record UpdateTodoRequest(string Title, string? Description, bool IsCompleted);
public record TodoResponse(Guid Id, string Title, string? Description, bool IsCompleted, DateTime CreatedAtUtc);
public record LoginRequest(string Email, string Password);
public record AuthResponse(string Token);
