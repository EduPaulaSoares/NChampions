using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NChampions.Domain.Entities
{
    public class Championship: Entity
    {
        [MaxLength(200)]
        public string ChampionshipName { get; private set; }
        public List<Team> Teams { get; private set; }
        public List<ChampionshipGame> ChampionshipGames { get; private set; }

        public Championship(string championshipName)
        {
            Id = Guid.NewGuid();
            ChampionshipName = championshipName;
            IsActive = true;
            CreatedOn = DateTime.Now;
        }
        public Championship(Guid id, string championshipName)
        {
            Id = id;
            ChampionshipName = championshipName;
            IsActive = true;
            CreatedOn = DateTime.Now;
        }
        public void AddTeams(List<Team> teams)
        {
            this.Teams = new List<Team>();
            Teams.AddRange(teams);
        }
        public void AddChampionshipGames(List<ChampionshipGame> championshipGames)
        {
            this.ChampionshipGames = new List<ChampionshipGame>();
            ChampionshipGames.AddRange(championshipGames);
        }
        public void UpdateChampionship(Championship championship)
        {
            Id = championship.Id;
            ChampionshipName = championship.ChampionshipName;
            IsActive = championship.IsActive;
            Teams = championship.Teams;
            ChampionshipGames = championship.ChampionshipGames;
            UpdatedOn = DateTime.Now;
        }

    }
}
