using System.Diagnostics;

namespace BI.Core;

public static class Validator
{
    public static void Requires(bool predicate, string message)
    {
        if (!predicate)
        {
            Debug.WriteLine(message);
            throw new Exception(message);
        }
    }

    public static void Requires<TException>(bool predicate, string message) where TException : Exception, new()
    {
        if (!predicate)
        {
            throw (Exception)Activator.CreateInstance(typeof(TException), message);
        }
    }

    public static void Requires<TException>(bool predicate) where TException : Exception, new()
    {
        if (!predicate)
        {
            throw (Exception)Activator.CreateInstance(typeof(TException));
        }
    }
}