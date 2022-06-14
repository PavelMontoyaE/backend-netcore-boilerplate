using Dapper;

using BI.Core;
using Collaborator.Entities;
using Collaborator.Repositories.Personal.Contracts;

namespace Collaborator.Repositories.Personal;

public class GetAllByActiveRepository : BaseRepository, IGetAllByActiveRepository
{
    public GetAllByActiveRepository(DbSession session):base(session)
    {
    }

    public async Task<IEnumerable<PersonalEntity>> GetAllByActive()
    {
        var personal = (await _session.Connection.QueryAsync<PersonalEntity>(
            @"SELECT Id, name, LastName, City, Country, Active
                    FROM collaborators_personals
                    WHERE Active = 1;",
            _session.Transaction)).ToList();

        return personal;
    }
}