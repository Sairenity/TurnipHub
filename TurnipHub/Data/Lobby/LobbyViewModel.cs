using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TurnipHub.Data.Lobby
{
    public class LobbyViewModel
    {
        public string TownName { get; set; }
        public string DodoCode { get; set; }
        public int ConcurrentVisitors { get; set; } = 4;
        public int QueueSize { get; set; } = 20;
    }

    public class LobbyValidator : AbstractValidator<LobbyViewModel>
    {
        public LobbyValidator()
        {
            RuleFor(e => e.TownName).NotEmpty();
            RuleFor(e => e.DodoCode).NotEmpty();
            RuleFor(e => e.ConcurrentVisitors).GreaterThan(0).LessThan(8);
            RuleFor(e => e.QueueSize).GreaterThanOrEqualTo(e => e.ConcurrentVisitors);
        }
    }
}
