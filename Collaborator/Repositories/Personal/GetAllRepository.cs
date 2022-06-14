using Dapper;

using BI.Core;
using Collaborator.Entities;
using Collaborator.Repositories.Personal.Contracts;

namespace Collaborator.Repositories.Personal;

public class GetAllRepository : BaseRepository, IGetAllRepository
{
    public GetAllRepository(DbSession session):base(session)
    {
    }

    public async Task<IEnumerable<PersonalEntity>> GetAll()
    {
        var personal = (await _session.Connection.QueryAsync<PersonalEntity>(
            @"SELECT Id, name, LastName, City, Country, Active
                    FROM collaborators_personals;",
            _session.Transaction)).ToList();

        return personal;
    }
}