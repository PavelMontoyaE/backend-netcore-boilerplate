using BI.Core.Response;
using Collaborator.Entities;

namespace Collaborator.Repositories.Personal.Contracts;

public interface IGetAllRepository
{
    Task<IEnumerable<PersonalEntity>> GetAll();
}