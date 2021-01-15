using FluentValidation;
using NChampions.Domain.Commands.Championship;
using NChampions.Domain.Repositories;

namespace NChampions.Domain.Validators.ChampionshipValidators
{
    public class UpdateChampionshipCommandValidator : AbstractValidator<UpdateChampionshipCommand>
    {
        public UpdateChampionshipCommandValidator(IChampionshipRepository _championshipRepository, ITeamRepository _teamRepository)
        {
            RuleFor(championship => championship.TeamsIds)
                .NotNull()
                .Custom((ids, ctx) =>
                {
                    if (ids.Count < 2)
                        ctx.AddFailure(nameof(Entities.Championship.Teams), "Quantidade de times insuficientes para cadastrar um campeonato!");
                })
                .CustomAsync(async (ids, ctx, action) =>
                {
                    var teams = ctx.ParentContext.InstanceToValidate as UpdateChampionshipCommand;
                    teams.SetTeams(await _teamRepository.getTeamsFromIds(ids));

                    bool valido = (teams.GetTeams().Count == ids.Count);

                    if (!valido)
                        ctx.AddFailure(nameof(Entities.Championship.Teams), "Ids de times contem registro inválido !");
                });
            RuleFor(championship => championship.ChampionshipName)
                .NotNull()
                .MaximumLength(200)
                .CustomAsync(async (teamName, ctx, action) =>
                {
                    var championship = ctx.ParentContext.InstanceToValidate as UpdateChampionshipCommand;
                    bool valido = await _championshipRepository.isUniqueChampionshipName(championship.Id, teamName);

                    if (!valido)
                        ctx.AddFailure(nameof(Entities.Team.TeamName), "Campeonato informado já cadastrado !");
                });
        }
    }
}
