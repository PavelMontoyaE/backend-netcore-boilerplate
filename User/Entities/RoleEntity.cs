using BI.Core;

namespace User.Entities;

public class RoleEntity : MetaDataEntity
{
    public int IdRole { get; set; }
    public string Role { get; set; }
}