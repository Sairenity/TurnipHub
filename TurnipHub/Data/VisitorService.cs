using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurnipHub.Data.Lobby;

namespace TurnipHub.Data
{
    public class VisitorService
    {
        private List<UserEntity> _database = new List<UserEntity>();

        public UserEntity CreateOrUpdate(UserEntity entity)
        {
            var existing = _database.FirstOrDefault(q => q.UserId == entity.UserId);
            if (existing == null)
            {
                entity.UserId = Guid.NewGuid();
                _database.Add(entity);
            }
            else
            {
                existing.LobbyState = entity.LobbyState;
            }

            return entity;
        }

        public UserEntity Get(Guid lobbyId)
        {
            return _database.FirstOrDefault(q => q.UserId == lobbyId);
        }

    }
}
