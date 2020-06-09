
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurnipHub.Hubs;

namespace TurnipHub.Data.Lobby
{
    public class LobbyClient : IAsyncDisposable
    {

        public const string HUBURL = "/LobbyHub";
        private HubConnection _hubConnection;

        public delegate void UserEnterEventHandler(string userId);
        public event UserEnterEventHandler OnUserEnter;

        public delegate void UserConnectedEventHandler(string userId);
        public event UserConnectedEventHandler OnUserConnected;

        public delegate void UserAdmittedEventHandler(string userId);
        public event UserAdmittedEventHandler OnUserAdmitted;

        public delegate void RefreshGroupsAheadEventHandler(string lobbyId);
        public event RefreshGroupsAheadEventHandler OnGroupsAheadRefreshed;

        public async Task StartAsync(Uri hubUri)
        {
            _hubConnection = new HubConnectionBuilder()
            .WithUrl(hubUri)
            .Build();

            _hubConnection.On(LobbyMessage.UserEntered, (string userId) =>
            {
                OnUserEnter?.Invoke(userId);
            });

            _hubConnection.On(LobbyMessage.UserConnected, (string userId) =>
            {
                OnUserConnected?.Invoke(userId);
            });

            _hubConnection.On(LobbyMessage.UserAdmitted, (string userId) =>
            {
                OnUserAdmitted?.Invoke(userId);
            });

            _hubConnection.On(LobbyMessage.RefreshGroupsAhead, (string lobbyId) =>
            {
                OnGroupsAheadRefreshed?.Invoke(lobbyId);
            });

            await _hubConnection.StartAsync();
        }

        public async Task Connect(UserEntity user)
        {
            await _hubConnection.SendAsync(LobbyMessage.UserConnected, user.UserId);
        }

        public async Task Admit(UserEntity user)
        {
            await _hubConnection.SendAsync(LobbyMessage.UserAdmitted, user.UserId);
        }

        public async Task Enter(UserEntity user)
        {
            await _hubConnection.SendAsync(LobbyMessage.UserEntered, user.UserId);
        }

        public async Task RefreshLobby(LobbyEntity lobby)
        {
            await _hubConnection.SendAsync(LobbyMessage.RefreshGroupsAhead, lobby.LobbyId);
        }

        public async Task UpdateQueuePositions(LobbyEntity lobby)
        {
            
        }

        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("LobbyClient: Disposing");
            //await StopAsync();
        }
    }
}
