using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurnipHub.Data.Lobby;

namespace TurnipHub.Data
{
    public class LobbyService
    {
        private List<LobbyEntity> _database = new List<LobbyEntity>();

        public LobbyEntity CreateOrUpdate(LobbyEntity entity)
        {
            entity.LobbyId = Guid.NewGuid();
            _database.Add(entity);
            return entity;
        }

        public LobbyEntity Get(Guid lobbyId)
        {
            return _database.FirstOrDefault(q => q.LobbyId == lobbyId);
        }

        public bool LobbyExists(Guid lobbyId)
        {
            return _database.Any(q => q.LobbyId == lobbyId);
        }
    }
}
