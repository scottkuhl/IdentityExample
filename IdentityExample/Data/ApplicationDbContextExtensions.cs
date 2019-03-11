using IdentityExample.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityExample.Data
{
    public static class ApplicationDbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }

        public static void EnsureSeeded(this ApplicationDbContext context)
        {
            if (UserManager.FindByEmailAsync("scott@eventmanagement.local").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Scott",
                    LastName = "Kuhl",
                    UserName = "scott@identity.local",
                    Email = "scott@idenity.local",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "P@ssword1").GetAwaiter().GetResult();
            }
        }
    }
}
