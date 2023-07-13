using NUlid;

namespace BusinessEntityModels;

public class User : BusinessEntityBase
{
    public string UserId { get; set; } = Ulid.NewUlid().ToString();
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public uint Phone { get; set; }
}
