using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Stanishewski253505.Entities
{
    [Table("RoomServices")]
    public class RoomService
    {
        public RoomService() { }
        public RoomService(int serviceId,string description,int roomid) 
        { 
            this.ServiceId = serviceId;
            this.Description = description;
            this.RoomId = roomid;
        }
        [PrimaryKey,AutoIncrement,Indexed]
        [Column("Id")]
        public int ServiceId { get; set; }
        public string Description { get; set; }
        [Indexed]
        public int RoomId { get; set; }
        
    }
}
