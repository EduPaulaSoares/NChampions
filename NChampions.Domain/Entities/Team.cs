using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NChampions.Domain.Entities
{
    public class Team : Entity
    {
        [MaxLength(200)]
        public string TeamName { get; private set; }
        public List<Championship> Championships { get; private set; }

        

        public Team(string teamName)
        {
            Id = Guid.NewGuid();
            TeamName = teamName;
            IsActive = true;
            CreatedOn = DateTime.Now;
        }
        public Team(Guid id, string teamName, bool isActive)
        {
            Id = id;
            TeamName = teamName;
            IsActive = isActive;

        }
        public void UpdateTeam(Team team)
        {
            Id = team.Id;
            TeamName = team.TeamName;
            IsActive = team.IsActive;
            UpdatedOn = DateTime.Now;
        }

    }
}
