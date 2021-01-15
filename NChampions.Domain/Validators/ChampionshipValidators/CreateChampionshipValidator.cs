using FluentValidation;
using NChampions.Domain.Commands.Championship;
using NChampions.Domain.Entities;
using NChampions.Domain.Repositories;
using System.Collections.Generic;

namespace NChampions.Domain.Validators.ChampionshipValidators
{
    public class CreateChampionshipCommandValidator : AbstractValidator<CreateChampionshipCommand>
    {

        public CreateChampionshipCommandValidator(IChampionshipRepository _championshipRepository,ITeamRepository _teamRepository)
        {
            RuleFor(championship => championship.TeamsIds)
                .NotNull()
                .Custom((ids, ctx) =>
                {
                    if (ids.Count <2)
                        ctx.AddFailure(nameof(Entities.Championship.Teams), "Quantidade de times insuficientes para cadastrar um campeonato!");
                })
                .CustomAsync(async (ids, ctx, action) =>
                {
                    var teams = ctx.ParentContext.InstanceToValidate as CreateChampionshipCommand;
                    teams.SetTeams(await _teamRepository.getTeamsFromIds(ids));

                    bool valido = (teams.GetTeams().Count == ids.Count) ;

                    if (!valido)
                        ctx.AddFailure(nameof(Entities.Championship.Teams), "Ids de times contem registro inválido !");
                });
            RuleFor(championship => championship.ChampionshipName)
                .NotNull()
                .MaximumLength(200)
                .CustomAsync(async (teamName, ctx, action) =>
                {
                    bool valido = await _championshipRepository.isUniqueChampionshipName(teamName);

                    if (!valido)
                        ctx.AddFailure(nameof(Entities.Team.TeamName), "Campeonato informado já cadastrado !");
                });
        }
    }
}
