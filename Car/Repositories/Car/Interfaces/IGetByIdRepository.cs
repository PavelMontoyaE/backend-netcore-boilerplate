using Car.Entities;

namespace Car.Repositories.Car.Interfaces;

public interface IGetByIdRepository
{
    Task<CarEntity> GetByIdAsync(ulong idCar);
}