using System;
using System.Collections.Generic;
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
}
