using System.Threading.Tasks;

using Car.Entities;

namespace Car.Repositories.Car.Interfaces;

public interface ICarCreateRepository
{
    Task<uLong> CreateAsync(CarEntity car);
}