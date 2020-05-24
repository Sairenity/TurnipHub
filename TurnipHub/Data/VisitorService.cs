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
            entity.UserId = Guid.NewGuid();
            _database.Add(entity);
            return entity;
        }

        public UserEntity Get(Guid lobbyId)
        {
            return _database.FirstOrDefault(q => q.UserId == lobbyId);
        }

    }
}
