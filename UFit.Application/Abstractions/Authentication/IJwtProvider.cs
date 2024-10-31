namespace UFit.Application.Abstractions.Authentication;
public interface IJwtProvider
{
    Task<string> GetJwtAsync(string email, string password);
}
