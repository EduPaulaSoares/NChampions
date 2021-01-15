using NChampions.Domain.Commands.ChampionshipGame;
using NChampions.Domain.Response;

namespace NChampions.Domain.Handlers
{
    public interface IChampionshipGameHandler :
        MediatR.IRequestHandler<UpdateChampionshipGameCommand, ResponseApi>
    {

    }
}
