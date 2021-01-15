
using FluentValidation.Results;
using NChampions.Domain.Repositories;
using NChampions.Domain.Validators.TeamValidators;
using System;

namespace NChampions.Domain.Commands.Teams
{
    public class UpdateTeamCommand : ICommand
    {
        public Guid Id { get; set; }
        public string TeamName { get; set; }
        public bool IsActive { get; set; }

        public ValidationResult Validate(ITeamRepository iTeamRepository)
        {
            ValidationResult validationResult = new UpdateTeamCommandValidator(iTeamRepository).Validate(this);
            return validationResult;
        }

    }
}
