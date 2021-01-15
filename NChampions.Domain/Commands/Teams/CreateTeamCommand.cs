using FluentValidation;
using FluentValidation.Results;
using NChampions.Domain.Repositories;
using NChampions.Domain.Validators.TeamValidators;

namespace NChampions.Domain.Commands.Teams
{
    public class CreateTeamCommand :  ICommand
    {
        public string TeamName { get; set; }
        
        public ValidationResult Validate(ITeamRepository iTeamRepository)
        {
            ValidationResult validationResult = new CreateTeamCommandValidator(iTeamRepository).Validate(this);
            return validationResult;
        }

        

    }
}
