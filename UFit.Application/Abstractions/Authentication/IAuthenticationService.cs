namespace UFit.Application.Abstractions.Authentication;
public interface IAuthenticationService
{
    Task<string> RegisterAsync(string email, string password);
}
