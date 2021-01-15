using NChampions.Domain.Commands.Teams;
using NChampions.Domain.Response;

namespace NChampions.Domain.Handlers
{
    public interface ITeamHandler : 
        MediatR.IRequestHandler<CreateTeamCommand,ResponseApi>,
        MediatR.IRequestHandler<UpdateTeamCommand, ResponseApi>
    {
    }
}
