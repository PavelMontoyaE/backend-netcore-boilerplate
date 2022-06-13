using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI.Core;
using BI.Car.Entities;
using BI.Car.Repositories.Car.Constants;
using BI.Car.Repositories.Car.Interfaces;
using Dapper;


namespace BI.Car.Repositories.Car.Implementations;

public class CarCreateRepository : BaseRepository, ICarCreateRepository
{
    public CarCreateRepository(DbSession session) : base(session)
    {
    }

    public async Task<ulong> CreateAsync(CarEntity car)
    {
        var carId = await _session.Connection.ExecuteScalarAsync(SqlCommands.Create, car, _session.Transaction);

        return (ulong)carId;
    }
}