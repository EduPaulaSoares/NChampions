using NChampions.Domain.Entities;
using NChampions.Domain.Repositories;
using NChampions.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace NChampions.Infra.Repositories
{
    public class ChampionshipGameRepository : IChampionshipGameRepository
    {
        private readonly NChampionsContext _ctx;
        public ChampionshipGameRepository(NChampionsContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Update(ChampionshipGame championshipGame)
        {
            var BDChampionshipGame = _ctx.ChampionshipGame
                                           .FirstOrDefault(x => x.Id == championshipGame.Id);


            BDChampionshipGame.UpdateChampionshipGame(championshipGame);
            await _ctx.SaveChangesAsync();
        }
    }
}
