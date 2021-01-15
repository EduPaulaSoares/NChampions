using FluentValidation.Results;
using NChampions.Domain.Entities;
using NChampions.Domain.Repositories;
using NChampions.Domain.Validators.ChampionshipValidators;
using System;
using System.Collections.Generic;

namespace NChampions.Domain.Commands.Championship
{
    public class UpdateChampionshipCommand: ICommand
    {
        public Guid Id { get; set; }
        public List<Guid> TeamsIds { get; set; }
        public string ChampionshipName { get; set; }

        public bool IsActive { get; set; }
        private List<Team> Teams;

        public ValidationResult Validate(IChampionshipRepository championshipRepository, ITeamRepository teamRepository)
        {
            ValidationResult validationResult = new UpdateChampionshipCommandValidator(championshipRepository, teamRepository).Validate(this);

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
