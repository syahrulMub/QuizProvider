using Microsoft.AspNetCore.Identity;
using QuizWeb.Models;

namespace QuizWeb.Data;

public static class CreateAdminOnDatabase
{
    public static async void CreateAdminRoleOnDatabase(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            await SetAdminAccount(userManager);
        }
        static async Task SetAdminAccount(UserManager<User> userManager)
        {
            var userName = "KitariOPloverz";
            var adminEmail = "KapanTamat@onepiece.com";
            var adminPassword = "OnePiece123@";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = userName,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
            }
            await userManager.CreateAsync(adminUser, adminPassword);
            await userManager.AddToRoleAsync(adminUser, "admin");
        }

    }
}
