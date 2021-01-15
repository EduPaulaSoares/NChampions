using NChampions.Domain.Entities;
using System.Threading.Tasks;

namespace NChampions.Domain.Repositories
{
    public interface IChampionshipGameRepository
    {
        Task Update(ChampionshipGame championshipGame);
    }
}
