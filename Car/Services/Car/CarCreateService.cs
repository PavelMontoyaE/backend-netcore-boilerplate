using System;
using System.Threading.Tasks;
using System.Net;

using AutoMapper;

using Car.Repositories.Car.Interfaces;
using Car.Entities;
using Car.Requests.Car;
using Car.Responses.Car;
using Car.Services.Car.Constants;
using BI.Core.Response;
using BI.Core;

namespace Car.Services.Car;

public class CarCreateService : ServiceExceptionLogger
{
    private readonly ICreateRepository _carCreateRepository;
    private readonly IGetByIdRepository _carGetByIdRepository;
    private readonly IMapper _mapper;
}