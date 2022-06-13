using System;

using NLog.Fluent;

namespace BI.Core.Interfaces;

public interface IServiceExceptionLogger
{
    void LogException(Exception ex, string specificMessage);
}