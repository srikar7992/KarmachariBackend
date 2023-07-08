using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntityModels;

public class DataEntityBase
{
    [Key]
    [Column("Id")]
    public long Id { get; set; }

    [Column("EntityId")]
    public Guid EntityId { get; set; } = Guid.NewGuid();

    [Column("ActionType")]
    public string ActionType { get; set; } = CommonEntities.ActionType.Insert.ToString();

    [Column("CreatedBy")]
    public Guid CreatedBy { get; set; }

    [Column("UpdatedBy")]
    public Guid UpdatedBy { get; set; }

    [Column("CreatedOn")]
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    [Column("UpdatedOn")]
    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    [Column("IsActive")]
    public bool IsActive { get; set; }
}
