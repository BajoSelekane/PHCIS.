using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DB
{
    public sealed class ApplicationUser : IdentityUser
    {
        public bool EnablePushNotification { get; set; }

    }
}
