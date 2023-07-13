using CommonEntities;
using NUlid;

namespace BusinessEntityModels;

public class BusinessEntityBase
{
    public long Id { get; set; }
    public string OpertionType { get; set; } = ActionType.Insert.ToString();
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set;}
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateUpdated { get; set;} = DateTime.Now;
    public bool IsActive { get; set; } = true;
}
