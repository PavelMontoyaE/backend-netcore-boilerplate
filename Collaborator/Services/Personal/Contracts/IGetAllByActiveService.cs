using BI.Core.Response;

namespace Collaborator.Services.Personal.Contracts;

public interface IGetAllByActiveService
{
    Task<Response> GetAllByActive();
}