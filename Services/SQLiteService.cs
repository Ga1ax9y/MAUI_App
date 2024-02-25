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
        public SQLiteConnection database;

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
            if (File.Exists(Path.Combine(FileSystem.AppDataDirectory, "MyData.db")))
            {
                 database = new(Path.Combine(FileSystem.AppDataDirectory, "MyData.db"));
            }
            else
            {

                database =new( Path.Combine(FileSystem.AppDataDirectory, "MyData.db"));
                database.CreateTable<RoomCategory>();
                database.CreateTable<RoomService>();

                database.Insert(new RoomCategory()

                {
                    Name = "Standart",
                    Id = 0,
                    Price = 500
                });
                database.Insert(new RoomService()
                {
                    Description = "Cleaning",
                    ServiceId = 0,
                    RoomId = 0,
                });
                database.Insert(new RoomCategory()
                {
                    Name = "VIP",
                    Id = 1,
                    Price = 2500
                });
                database.Insert(new RoomService()
                {
                    Description = "Free Food",
                    ServiceId = 1,
                    RoomId = 1,
                });
                database.Insert(new RoomCategory()
                {
                    Name = "Delux",
                    Id = 2,
                    Price = 5000
                });
                database.Insert(new RoomService()
                {
                    Description = "Free Wine",
                    ServiceId = 2,
                    RoomId = 2,
                });

                //database.DeleteAll<RoomCategory>();

            }


        }
    }
}
