using NChampions.Domain.Commands.Championship;
using NChampions.Domain.Response;

namespace NChampions.Domain.Handlers
{
    public interface IChampionshipHandler :
        MediatR.IRequestHandler<CreateChampionshipCommand, ResponseApi>,
        MediatR.IRequestHandler<UpdateChampionshipCommand, ResponseApi>

    {

    }
}
