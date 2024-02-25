using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Stanishewski253505.Entities;


namespace Stanishewski253505.Services
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection database;

        public IEnumerable<RoomCategory> GetAllRooms()
        {
            Init();
            return database.Table<RoomCategory>().ToList();
        }
        public IEnumerable<RoomService> GetRoomService(int id)
        {
            Init();         
            return database.Table<RoomService>().Where(p=>p.RoomId == id).ToList();
        }
        public void Init()
        {
            if (database != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            database = new SQLiteConnection(databasePath);
            database.CreateTable<RoomCategory>();

            var Room1 = new RoomCategory(0, "Standart", 500);
            var Room2 = new RoomCategory(1, "Superior", 1250);
            var Room3 = new RoomCategory(2, "VIP", 2500);
            database.Insert(Room1);
            database.Insert(Room2);
            database.Insert(Room3);
            database.CreateTable<RoomService>();
            var room_service1 = new RoomService(0,"clean",0);
            var room_service2 = new RoomService(1,"wine",1);
            var room_service3 = new RoomService(2,"food",2);
            database.Insert(room_service1);
            database.Insert(room_service2);
            database.Insert(room_service3);




        }
    }
}
