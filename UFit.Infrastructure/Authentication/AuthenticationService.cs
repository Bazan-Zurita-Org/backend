using FirebaseAdmin.Auth;
using UFit.Application.Abstractions.Authentication;

namespace UFit.Infrastructure.Authentication;
internal sealed class AuthenticationService : IAuthenticationService
{
    public async Task<string> RegisterAsync(string email, string password)
    {
        var userArgs = new UserRecordArgs()
        {
            Email = email,
            Password = password
        };

        var user = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

        return user.Uid;
    }
}
