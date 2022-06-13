using System.ComponentModel.DataAnnotations;

namespace BI.Core;

public class ServiceResponse
{
    private readonly IList<string> errorMessages;

    public ServiceResponse()
    {
        errorMessages = new List<string>();
    }

    public IList<string> ErrorMessages => errorMessages;
    public bool Failed => ErrorMessages.Any();
    public bool IsOk => !ErrorMessages.Any();

    public void HandleException(Exception ex)
    {
        try
        {
            if (ex is ValidationException)
            {
                errorMessages.Add(ex.Message);
            }
            else if (ex is Exception)
            {
                errorMessages.Add("Error processing your request");
            }
        }
        catch (Exception ex2)
        {
            throw new Exception(ex2.Message);
        }
    }

    public override string ToString()
    {
        return string.Join("/n/r", ErrorMessages);
    }
}

public class ServiceResponse<T> : ServiceResponse
{
    public T Result { get; set; }
}