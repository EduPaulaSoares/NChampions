using System;
using System.Collections.Generic;

namespace NChampions.Application.ViewModels
{
    public class ChampionshipViewModel
    {
        public Guid Id { get; set; }
        public string ChampionshipName { get; set; }
        public bool isActive { get; set; }
        public IList<TeamViewModel> ChampionshipTeams { get; set; }
    }
}
