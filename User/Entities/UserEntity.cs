using BI.Core;

namespace User.Entities;

public class UserEntity : MetaDataEntity
{
    public int IdUser { get; set; }
    public string UserIdp { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int RoleId { get; set; }
    
    public virtual RoleEntity Role { get; set; }
}