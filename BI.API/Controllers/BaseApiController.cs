using System;
using BI.Core;
using Microsoft.AspNetCore.Mvc;

namespace BI.API.Controllers;

public class BaseApiController : ControllerBase
{
    protected IActionResult GetResult<U>(ServiceResponse<U> response)
    {
        IActionResult result;
        try
        {
            if (response.IsOk)
            {
                result = Ok(response);
            }
            else
            {
                result = BadRequest(response);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            response.ErrorMessages.Add(ex.Message);
            result = BadRequest(response);
        }

        return result;
    }
}