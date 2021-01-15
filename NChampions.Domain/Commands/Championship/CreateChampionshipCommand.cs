using FluentValidation.Results;
using NChampions.Domain.Entities;
using NChampions.Domain.Repositories;
using NChampions.Domain.Validators.ChampionshipValidators;
using System;
using System.Collections.Generic;

namespace NChampions.Domain.Commands.Championship
{
    public class CreateChampionshipCommand: ICommand
    {
        public string ChampionshipName { get; set; }
        public List<Guid> TeamsIds { get; set; }

        private List<Team> Teams;

        public ValidationResult Validate(IChampionshipRepository championshipRepository, ITeamRepository teamRepository)
        {
            ValidationResult validationResult = new CreateChampionshipCommandValidator(championshipRepository,teamRepository).Validate(this);
            
            return validationResult;
        }

        public List<Team> GetTeams()
        {
            return Teams;
        }
        public void SetTeams(List<Team> teams)
        {
            Teams = teams;
        }
        
    }
}
