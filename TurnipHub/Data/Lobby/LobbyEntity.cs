using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnipHub.Data.Lobby
{
    public class LobbyEntity
    {
        public LobbyEntity() { }
        public LobbyEntity(LobbyViewModel viewModel)
        {
            AdminCode = Guid.NewGuid();
            TownName = viewModel.TownName;
            DodoCode = viewModel.DodoCode;
            ConcurrentVisitors = viewModel.ConcurrentVisitors;
            QueueSize = viewModel.QueueSize;
        }

        public Guid LobbyId { get; set; }
        public Guid AdminCode { get; set; }
        public string TownName { get; set; }
        public string DodoCode { get; set; }
        public int ConcurrentVisitors { get; set; }
        public int QueueSize { get; set; }
        public bool VisitorQueueLocked { get; set; } = false;

        public List<UserEntity> VisitorQueue { get; set; } = new List<UserEntity>();
        public List<UserEntity> CurrentVisitors { get; set; } = new List<UserEntity>();

        public void RecalculatePositions()
        {
            int counter = 0;
            foreach (var visitor in VisitorQueue)
            {
                visitor.PositionInQueue = counter++;
            }
        }

    }
}
