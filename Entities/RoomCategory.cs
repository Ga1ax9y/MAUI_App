using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Stanishewski253505.Entities
{
    [Table("RoomCategories")]
    public class RoomCategory
    {
        [PrimaryKey,AutoIncrement,Indexed]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}
