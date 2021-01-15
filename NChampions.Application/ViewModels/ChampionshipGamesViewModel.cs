using System;

namespace NChampions.Application.ViewModels
{
    public class ChampionshipGamesViewModel
    {
        public Guid IdChampionshipGame { get; set; }

        public Guid IdChampionship { get; set; }
        public string ChampionshipName { get; set; }

        public string HomeTeam { get; set; }
        public Guid IdHomeTeam { get; set; }
        public int HomeScore { get; set; }

        public string AwayTeam { get; set; }
        public Guid IdAwayTeam { get; set; }
        public int AwayScore { get; set; }

        public DateTime GameDate { get; set; }

        public bool isActive { get; set; }

    }
}
