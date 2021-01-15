using System;

namespace NChampions.Domain.Entities
{
    public class ChampionshipGame : Entity
    {
        public Championship Championship { get; private set; }
               
        public Team HomeTeam { get; private set; }        
        public Team AwayTeam { get; private set; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public DateTime GameDate { get; private set; }

        public ChampionshipGame()
        {            
        }

        public ChampionshipGame(Championship championship, Team homeTeam, Team awayTeam)
        {
            Id = Guid.NewGuid();
            Championship = championship;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = 0;
            AwayScore = 0;           
            CreatedOn = DateTime.Now;
        }
        public ChampionshipGame(Guid id, int homeScore, int awayScore, DateTime gameDate)
        {
            Id = id;            
            HomeScore = homeScore;
            AwayScore = awayScore;
            GameDate = gameDate;
        }
        
        public void UpdateChampionshipGame(ChampionshipGame championshipGame)
        {
            Id = championshipGame.Id;
            HomeScore = championshipGame.HomeScore;
            AwayScore = championshipGame.AwayScore;
            GameDate = championshipGame.GameDate;
            UpdatedOn = DateTime.Now;
        }
    }
}
