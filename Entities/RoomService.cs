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
        public RoomService(int serviceId,string name,int roomid) 
        { 
            this.ServiceId = serviceId;
            this.Name = name;
            this.RoomId = roomid;
        }
        [PrimaryKey,AutoIncrement,Indexed]
        [Column("Id")]
        public int ServiceId { get; set; }
        public string Name { get; set; }
        [Indexed]
        public int RoomId { get; set; }
        
    }
}
