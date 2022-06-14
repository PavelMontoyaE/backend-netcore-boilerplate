using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net;

namespace BI.API.Controllers.Car;

[Route("api/car/[controller]")]
[Produces("application/json")]
[ApiController]
// [Authorize] implementations join with interfaces
public class CarCreateController : BaseApiController
{
    // private readonly ICreateService _carCreateService;
}