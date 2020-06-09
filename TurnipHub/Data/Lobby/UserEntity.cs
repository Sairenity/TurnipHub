using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnipHub.Data.Lobby
{
    public class UserEntity
    {
        public UserEntity()
        {
            UserId = Guid.NewGuid();
        }
        public Guid UserId { get; set; }
        public LobbyVisitorStateEnum LobbyState { get; set; }
        public string Name { get; set; }
        public bool AdmissionGranted { get; set; }
        public int PositionInQueue { get; set; }
        public LobbyEntity JoinedLobby { get; set; }

    }
}
