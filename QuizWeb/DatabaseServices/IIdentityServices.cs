using Microsoft.AspNetCore.Identity;

namespace QuizWeb.IdentityServices;

public interface IIdentityServices
{
    public Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
    public Task<SignInResult> LoginAsync(LoginViewModel model);
    public Task<UserData?> GetUserData(string email);
    public Task<bool> DeleteUser(string userId);
}
