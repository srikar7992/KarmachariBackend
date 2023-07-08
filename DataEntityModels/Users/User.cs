using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityModels;

[Table("users")]
public class User : DataEntityBase
{
    [Column("firstname")]
    [RegularExpression(@"^[A-Za-z]{1,25}$", ErrorMessage = "Only A-Z and a-z characters allowed with a maximum length of 25.")]
    public required string FirstName { get; set; }

    [Column("lastname")]
    [RegularExpression(@"^[A-Za-z]{1,25}$", ErrorMessage = "Only A-Z and a-z characters allowed with a maximum length of 25.")]
    public string? LastName { get; set; }

    [Column("username")]
    public required string UserName { get; set; }

    [Column("password")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W_]).*$", ErrorMessage = "Password must contain at least one uppercase letter and one special character.")]
    public required string Password { get; set; }

    [Column("email")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address.")]
    public required string Email { get; set; }

    [Column("phone")]
    [RegularExpression(@"^\+?\d{1,3}[-.\s]?\(?\d{1,3}\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}$", ErrorMessage = "Invalid phone number.")]
    public uint Phone { get; set; }
}
