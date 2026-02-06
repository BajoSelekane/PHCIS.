
using SharedLibrary.Shared;

namespace Domain.Entities.User;

public sealed class User : Entity
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PasswordHash { get; set; }
}
