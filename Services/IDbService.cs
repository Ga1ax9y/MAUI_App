using Stanishewski253505.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stanishewski253505.Services
{
    public interface IDbService
    {
        IEnumerable<RoomCategory> GetAllRooms();
        IEnumerable<RoomService> GetRoomService(int id);
        void Init();
    }
}
