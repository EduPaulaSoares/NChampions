using FluentValidation;
using NChampions.Domain.Commands.Teams;
using NChampions.Domain.Repositories;

namespace NChampions.Domain.Validators.TeamValidators
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator(ITeamRepository _teamRepository)
        {
            RuleFor(team => team.TeamName)
                .NotNull()
                .MaximumLength(200)
                .CustomAsync(async (teamName, ctx, action) =>
                {
                    var team = ctx.ParentContext.InstanceToValidate as UpdateTeamCommand;
                    bool valido = await _teamRepository.isUniqueTeamName(team.Id,teamName);

                    if (!valido)
                        ctx.AddFailure(nameof(Entities.Team.TeamName), "Time informado já cadastrado !");
                }); 
        }
    }
}
