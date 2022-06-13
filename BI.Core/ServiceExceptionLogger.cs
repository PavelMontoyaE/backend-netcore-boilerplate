using System;
using BI.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using R = BI.Core.Response;
using BI.Core.Interfaces;

namespace BI.Core;

// TODO: IMPLEMENT ALL EXCEPTIONS HERE
public class ServiceExceptionLogger : IServiceExceptionLogger
{
    private static ILogger<R.Response> Logger = NullLogger<R.Response>.Instance;

    public void LogException(Exception ex, string specificMessage)
    {
        Logger.LogError($"{ex.Message} >>> {ex.StackTrace}");
        
        // ADDED THIS THROW INSTRUCTION FOR GETTING FULL EXCEPTION INFO IN RESPONSE.
        // TODO: REMOVE IT WHEN YOU HAVE ACCESS TO THE LOG FILE
        throw ex;
    }
}