using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnipHub.Hubs
{
    public class LobbyMessage
    {
        public static readonly string UserEntered = "OnUserEntered";
        public static readonly string UserConnected = "OnUserConnected";
        public static readonly string UserAdmitted = "OnUserAdmitted";
        public static readonly string RefreshGroupsAhead = "OnRefreshGroupsAhead";
    }
}
