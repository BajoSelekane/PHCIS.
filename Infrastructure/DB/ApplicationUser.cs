using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DB
{
    public sealed class ApplicationUser : IdentityUser
    {
        public bool EnablePushNotification { get; set; }
        public string? Password {  get; set; }

        public ICollection<Roles> roles { get; set; }

    }
    public sealed class Roles
    {
        public int Id { get; set; }
        public const string Admin = "Admin";
        public const string Member = "Member";
        public const string Doc = "Doctor";
    }
}
