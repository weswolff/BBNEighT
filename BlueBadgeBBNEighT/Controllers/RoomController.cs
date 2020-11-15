using BBNeighT.Services.RoomService;
using BBNEighT.Models.RoomModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeBBNEighT.Controllers
{
    [Authorize]
    public class RoomController : ApiController
    {
        private RoomService CreateRoomService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var roomService = new RoomService(userID);
            return roomService;
        }
        public IHttpActionResult GetAllRooms()
        {
            RoomService roomService = CreateRoomService();
            var rooms = roomService.GetRooms();
            return Ok(rooms);
        }
        public IHttpActionResult PostRoom(RoomCreate room)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoomService();

            if (!service.CreateRoom(room))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult GetRoom(int id)
        {
            RoomService roomService = CreateRoomService();
            var room = roomService.GetRoomById(id);
            return Ok(id);
        }

        public IHttpActionResult PutRoom(RoomEdit room)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            var service = CreateRoomService();

            if (!service.UpdateRoom(room))
                return InternalServerError();

            return Ok();

        }

        public IHttpActionResult DeleteRoom(int id)
        {
            var service = CreateRoomService();

            if (!service.DeleteRoom(id))
                return InternalServerError();
            return Ok();
        }
    }
}
