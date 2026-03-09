namespace TodoApi.Application.Abstractions;

public interface IJwtTokenGenerator
{
    string Generate(string userId, string email);
}
