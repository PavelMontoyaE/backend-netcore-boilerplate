using BI.Core.Response;

namespace Collaborator.Services.Personal.Interfaces;

public interface IGetAllByActiveService
{
    Task<Response> GetAllByActive();
}