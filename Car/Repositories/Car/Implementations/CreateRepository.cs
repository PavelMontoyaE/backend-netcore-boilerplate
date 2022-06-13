using BI.Core;
using Car.Entities;
using Dapper;

namespace Car.Repositories.Car.Implementations;

public class CreateRepository : BaseRepository
{
    public CreateRepository(DbSession session) : base(session)
    {
    }

    public async Task<ulong> CreateAsync(CarEntity car)
    {
        var carId = await _session.Connection.ExecuteScalarAsync(
            @"INSERT INTO Car (UserId, CarBrandId, FuelTypeId, CarModelId, PlateId
                    , CarTypeId, CarColorId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, Active)
                VALUES (@UserId, @CarBrandId, @FuelTypeId, @CarModelId, @PlateId, @CarTypeId
                    , @CarColorId, @CreatedBy, @CreatedOn, NULL, NULL, @Active);
                SELECT LAST_INSERT_ID();",
            car,
            _session.Transaction);

        return (ulong)carId;
    }
}