using eAppointmentServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eAppointmentServer.WebApi.Helper
{
    public static class HelperConfig
    {
        public static async Task CreateUser(WebApplication app)
        {
            // burda ilk kullanici olusturuyorum admin yetkisi veriyorum hic kullanici yoksa calisir
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                if (!userManager.Users.Any())
                {
                    await userManager.CreateAsync(new()
                    {
                        FirstName = "Yusuf",
                        LastName = "Bolat",
                        Email = "admin@admin.com",
                        UserName = "admin"
                    }, "1");
                }
            }
        }
    }
}
