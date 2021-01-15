using System;

namespace NChampions.Application.ViewModels
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public string TeamName { get; set; }
        public bool isActive { get; set; }
    }
}
