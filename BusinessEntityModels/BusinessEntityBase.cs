using CommonEntities;

namespace BusinessEntityModels;

public class BusinessEntityBase
{
    public long Id { get; set; }
    public Guid EntityId { get; set; } = Guid.NewGuid();
    public string OpertionType { get; set; } = ActionType.Insert.ToString();
    public Guid CreatedBy { get; set; }
    public Guid ModifiedBy { get; set;}
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateUpdated { get; set;} = DateTime.Now;
    public bool IsActive { get; set; } = true;
}
