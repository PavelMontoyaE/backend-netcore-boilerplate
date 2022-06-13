namespace Car.Requests.Car;

public class CreateRequest
{
    public int CarBrandId { get; set; }
    public int? FuelTypeId { get; set; }
    public int CarModelId { get; set; }
    public int PlateId { get; set; }
    public ulong? CarTypeId { get; set; }
    public int CarColorId { get; set; }
    public int UserId { get; set; }
}