using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Car.Entities;
using Car.Repositories.CarBrand.Interfaces;
using Car.Repositories.CarModel.Interfaces;
using Car.Repositories.CarType.Interfaces;
using Car.Repositories.CarColor.Interfaces;
using Car.Repositories.Car.Interfaces;
using Car.Repositories.Car.Constants;
using User.Repositories.User.Interfaces;
using BI.Core;

namespace Car.Repositories.Car.Implementations;

public class GetByIdRepository : BaseRepository, IGetByIdRepository
    {
        private readonly IUserGetByIdRepository _userGetByIdRepository;

        public CarGetByIdRepository(DbSession session
            , IUserGetByIdRepository userGetByIdRepository):base(session)
        {
            _userGetByIdRepository = userGetByIdRepository;
        }
        public async Task<CarEntity> GetByIdAsync(ulong idCar)
        {
            
            var car = (await _session.Connection.QueryAsync<CarEntity>(SqlCommands.GetById, new { IdCar = idCar }, _session.Transaction)).SingleOrDefault();
            if (car is not null) 
            {
                car.CarBrand = await _carBrandGetByIdRepository.GetByIdAsync(car.CarBrandId);
                car.CarModel = await _carModelGetByIdRepository.GetByIdAsync(car.CarModelId);
                car.CarType = await _carTypeGetByIdRepository.GetByIdAsync(car.CarTypeId);
                car.CarColor = await _carColorGetByIdRepository.GetByIdAsync(car.CarColorId);
                car.User = await _userGetByIdRepository.GetByIdAsync(car.UserId);
                car.FuelType = await _fuelTypeGetByIdRepository.GetByIdAsync(car.FuelTypeId);
                car.Plate = await _plateGetByIdRepository.GetByIdAsync(car.PlateId);

            }
            return car;
        }
    }