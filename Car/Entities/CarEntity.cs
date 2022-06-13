using User.Entities;
using BI.Core;

namespace Car.Entities;

public class CarEntity : MetaDataEntity
{
    public long IdCar { get; set; }
    public int UserId { get; set; }
    public int CarBrandId { get; set; }
    public int FuelTypeId { get; set; }
    public int CarModelId { get; set; }
    public ulong PlateId { get; set; }
    public ulong CarTypeId { get; set; }
    public int CarColorId { get; set; }
    
    public virtual UserEntity User { get; set; }
}