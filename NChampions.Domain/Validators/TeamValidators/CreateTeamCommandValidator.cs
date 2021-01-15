using FluentValidation;
using NChampions.Domain.Commands.Teams;
using NChampions.Domain.Repositories;

namespace NChampions.Domain.Validators.TeamValidators
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        

        public CreateTeamCommandValidator(ITeamRepository _teamRepository)
        {
            RuleFor(team => team.TeamName)
                .NotNull()
                .MaximumLength(200)
                .CustomAsync(async (teamName, ctx, action) =>
                {                    
                    bool valido = await _teamRepository.isUniqueTeamName( teamName);

                    if (!valido)
                        ctx.AddFailure(nameof(Entities.Team.TeamName), "Time informado já cadastrado !");
                });

        }
    }
}
