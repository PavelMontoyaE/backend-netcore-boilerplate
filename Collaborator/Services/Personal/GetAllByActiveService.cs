using System.Net;
using AutoMapper;

using BI.Core;
using BI.Core.Response;
using Collaborator.Entities;
using Collaborator.Repositories.Personal.Contracts;
using Collaborator.Responses.Personal;
using Collaborator.Services.Personal.Contracts;

namespace Collaborator.Services.Personal;

public class GetAllByActiveService : ServiceExceptionLogger, IGetAllByActiveService
{
    private readonly IGetAllByActiveRepository _getAllByActiveRepository;
    private readonly IMapper _mapper;

    public GetAllByActiveService(IGetAllByActiveRepository getAllByActiveRepository, IMapper mapper)
    {
        _getAllByActiveRepository = getAllByActiveRepository;
        _mapper = mapper;
    }

    public async Task<Response> GetAllByActive()
    {
        try
        {

            var activePersonal = await _getAllByActiveRepository.GetAllByActive();
            if (activePersonal.Any())
            {
                return activePersonal.ToResponse(true, HttpStatusCode.NotFound, Messages.GetAllByActive.EmptyList);
            }

            List<PersonalResponse> responseData = new();
            foreach (PersonalEntity personal in activePersonal)
            {
                // ContractEntity contractEntity = await _getContractByPersonal.GetById(activePersonal.Id);
                // if (contractEntity is not null) { responseData.Add(_mapper.Map<ContractResponse>(contractEntity)) }
            }

            return responseData.ToResponse(true, HttpStatusCode.OK, Messages.GetAll.OK);
        }
        catch (Exception ex)
        {
            LogException(ex, Messages.GetAll.Ex);
            throw new Exception(Messages.GetAll.Ex);
        }
    }
}