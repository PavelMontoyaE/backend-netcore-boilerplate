namespace Car.Responses.Car;

public class GenericResponse
{
    public long IdCar { get; set; }
    public virtual UserGenericResponse User { get; set; }
}