using NChampions.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace NChampions.Domain.Repositories
{
    public interface IChampionshipRepository
    {
        Task Create(Championship championship);
        Task Update(Championship championship);
        Task<bool> isUniqueChampionshipName(string championshipName);
        Task<bool> isUniqueChampionshipName(Guid id,string championshipName);
    }
}
