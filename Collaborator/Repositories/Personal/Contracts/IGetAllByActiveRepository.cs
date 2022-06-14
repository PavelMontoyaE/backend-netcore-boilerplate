using Collaborator.Entities;

namespace Collaborator.Repositories.Personal.Contracts;

public interface IGetAllByActiveRepository
{
    Task<IEnumerable<PersonalEntity>> GetAllByActive();
}