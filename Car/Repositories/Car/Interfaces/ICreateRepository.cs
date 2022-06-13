using Car.Entities;

namespace Car.Repositories.Car.Interfaces;

public interface ICreateRepository
{
    Task<ulong> CreateAsync(CarEntity car);
}