using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurnipHub.Data;
using TurnipHub.Data.Lobby;

namespace TurnipHub.Hubs
{
    public class LobbyHub : Hub
    {
        private static readonly List<(string UserId, string ConnectionId)> userLookup = new List<(string UserId, string ConnectionId)>();
        private readonly LobbyService _lobbyService;

        public LobbyHub(LobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }

        public async Task StartAsync()
        {

        }

        public async Task OnUserConnected(string userId)
        {
            userLookup.Add((userId, Context.ConnectionId));
            await Task.FromResult(true);
        }

        public async Task OnUserEntered(string userId)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync(LobbyMessage.UserEntered, userId);
        }

        public async Task OnUserAdmitted(string userId)
        {
            if (userLookup.Any(q => q.UserId == userId))
            {
                var userConnections = userLookup.Where(q => q.UserId == userId).Select(q => q.ConnectionId).ToList();
                await Clients.Clients(userConnections).SendAsync(LobbyMessage.UserAdmitted, userId);
            }
        }

        public async Task OnRefreshGroupsAhead(string lobbyId)
        {
            var lobby = _lobbyService.Get(Guid.Parse(lobbyId));
            var visitorIds = lobby.VisitorQueue.Select(q => q.UserId.ToString());
            var usersToNotify = userLookup.Where(q => visitorIds.Contains(q.UserId)).Select(q => q.ConnectionId).ToList();
            await Clients.Clients(usersToNotify).SendAsync(LobbyMessage.RefreshGroupsAhead, lobbyId);
        }
    }
}
