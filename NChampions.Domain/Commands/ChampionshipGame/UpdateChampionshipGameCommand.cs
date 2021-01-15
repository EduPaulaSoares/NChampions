using NChampions.Domain.Entities;
using System;

namespace NChampions.Domain.Commands.ChampionshipGame
{
    public class UpdateChampionshipGameCommand : ICommand
    {
        public Guid Id { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime GameDate { get; set; }
       
    }
}
