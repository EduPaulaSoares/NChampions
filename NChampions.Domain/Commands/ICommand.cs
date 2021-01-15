using NChampions.Domain.Response;

namespace NChampions.Domain.Commands
{
    public interface ICommand : MediatR.IRequest<ResponseApi>
    {
    }
}
