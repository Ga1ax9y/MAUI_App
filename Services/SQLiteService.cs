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
            return database.Table<RoomCategory>().ToList();
        }
        public IEnumerable<RoomService> GetRoomService(int id)
        {
            return database.Table<RoomService>().Where(p=>p.RoomId == id).ToList();
        }
        public void Init()
        {
            if (File.Exists(Path.Combine(FileSystem.AppDataDirectory, "MyData2.db")))
            {
                 database = new(Path.Combine(FileSystem.AppDataDirectory, "MyData2.db"));
            }
            else
            {
                database =new(Path.Combine(FileSystem.AppDataDirectory, "MyData2.db"));
                database.CreateTable<RoomCategory>();
                database.CreateTable<RoomService>();
                //Стандартная категория
                database.Insert(new RoomCategory()
                {
                    Name = "Standart",
                    Id = 1,
                    Price = 500
                });
                //Услуги стандартной категории
                database.Insert(new RoomService()
                {
                    Description = "Одноразовое питание",
                    ServiceId = 0,
                    RoomId = 0,
                });
                database.Insert(new RoomService()
                {
                    Description = "Обслуживание номера",
                    ServiceId = 1,
                    RoomId = 0,
                });
                database.Insert(new RoomService()
                {
                    Description = "Бесплатный интернет",
                    ServiceId = 2,
                    RoomId = 0,
                });
                database.Insert(new RoomService()
                {
                    Description = "Предоставление халатов",
                    ServiceId = 3,
                    RoomId = 0,
                });
                database.Insert(new RoomService()
                {
                    Description = "Бесплатная экскурсия",
                    ServiceId = 4,
                    RoomId = 0,
                });
                //VIP категория
                database.Insert(new RoomCategory()
                {
                    Name = "VIP",
                    Id = 2,
                    Price = 2500
                });
                //Услуги VIP категории
                database.Insert(new RoomService()
                {
                    Description = "Двухразовое питание",
                    ServiceId = 5,
                    RoomId = 1,
                });
                database.Insert(new RoomService()
                {
                    Description = "Доступ в сауну",
                    ServiceId = 6,
                    RoomId = 1,
                });
                database.Insert(new RoomService()
                {
                    Description = "Доступ к сейфу",
                    ServiceId = 7,
                    RoomId = 1,
                });
                database.Insert(new RoomService()
                {
                    Description = "Скидка на напитки",
                    ServiceId = 8,
                    RoomId = 1,
                });
                database.Insert(new RoomService()
                {
                    Description = "Скидка на автобус",
                    ServiceId = 9,
                    RoomId = 1,
                });
                // Delux категория
                database.Insert(new RoomCategory()
                {
                    Name = "Delux",
                    Id = 3,
                    Price = 5000
                });
                // Услуги delux категории
                database.Insert(new RoomService()
                {
                    Description = "Трехразовое питание",
                    ServiceId = 10,
                    RoomId = 2,
                });
                database.Insert(new RoomService()
                {
                    Description = "Доступ в ♂Gym♂",
                    ServiceId = 11,
                    RoomId = 2,
                });
                database.Insert(new RoomService()
                {
                    Description = "Выведение из запоя",
                    ServiceId = 12,
                    RoomId = 2,
                });
                database.Insert(new RoomService()
                {
                    Description = "Услуги прачечной",
                    ServiceId = 13,
                    RoomId = 2,
                });
                database.Insert(new RoomService()
                {
                    Description = "Ежедневный массаж",
                    ServiceId = 14,
                    RoomId = 2,
                });

                //database.DeleteAll<RoomCategory>();

            }


        }
    }
}
