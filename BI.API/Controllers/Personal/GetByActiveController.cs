using System.Net;
using BI.Core;
using BI.Core.Response;
using Collaborator.Services.Personal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BI.API.Controllers.Personal;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class GetByActiveController : ControllerBase
{
    private readonly IGetAllByActiveService _getAllByActiveService;

    public GetByActiveController(IGetAllByActiveService getAllByActiveService)
    {
        _getAllByActiveService = getAllByActiveService;
    }
    
    // GET api/<GetByActiveController>/
    [HttpGet]
    public async Task<ActionResult<IResponse>> GetAllByActive([FromServices] IUnitOfWork unitOfWork)
    {
        try
        {
            unitOfWork.BeginTransaction();
            Response response = await _getAllByActiveService.GetAllByActive();
            unitOfWork.Commit();

            return response.Type == HttpStatusCode.OK ? Ok(response) : StatusCode((int)response.Type, response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToResponseException("Operation couldn't complete."));
        }
    }
}