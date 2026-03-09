using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.DTOs;
using TodoApi.Application.Services;

namespace TodoApi.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TodosController(TodoService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMine(CancellationToken ct)
    {
        var userId = GetUserId();
        var todos = await service.GetMineAsync(userId, ct);
        return Ok(todos);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoRequest request, CancellationToken ct)
    {
        var userId = GetUserId();
        var created = await service.CreateAsync(userId, request, ct);
        return CreatedAtAction(nameof(GetMine), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoRequest request, CancellationToken ct)
    {
        var userId = GetUserId();
        var updated = await service.UpdateAsync(id, userId, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var userId = GetUserId();
        await service.DeleteAsync(id, userId, ct);
        return NoContent();
    }

    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier)
           ?? User.FindFirstValue(ClaimTypes.Name)
           ?? throw new UnauthorizedAccessException("User ID claim not found.");
}
