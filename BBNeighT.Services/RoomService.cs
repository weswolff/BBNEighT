using BBNEighT.Data;
using BBNEighT.Data.RoomData;
using BBNEighT.Models.RoomModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BBNeighT.Services.RoomService
{
    public class RoomService
    {
        private readonly Guid _userId;

        public RoomService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRoom(RoomCreate model)
        {
            var entity =
                new Room()
                {
                    OwnerId = _userId,
                    RoomName = model.RoomName,
                    RoomDescription = model.RoomDescription
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rooms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RoomList> GetRooms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rooms
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RoomList
                                {
                                    RoomID = e.RoomID,
                                    RoomName = e.RoomName,
                                    RoomDescription = e.RoomDescription
                                }
                        );
                return query.ToArray();
            }
        }
        public RoomDetail GetRoomByName(string roomName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rooms
                        .Single(e => e.RoomName == roomName && e.OwnerId == _userId);
                return
                    new RoomDetail
                    {
                        RoomID = entity.RoomID,
                        RoomName = entity.RoomName,
                        RoomDescription = entity.RoomDescription
                    };
            }
        }
        public bool UpdateRoom(RoomEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rooms
                        .Single(e => e.RoomID == model.RoomID && e.OwnerId == _userId);
                
                entity.RoomID = model.RoomID;
                entity.RoomName = model.RoomName;
                entity.RoomDescription = model.RoomDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRoom(string roomName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                        .Rooms
                        .Single(e => e.RoomName == roomName && e.OwnerId == _userId);
                ctx.Rooms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
