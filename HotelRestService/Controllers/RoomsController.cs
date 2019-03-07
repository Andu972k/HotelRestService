using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelRestService.DBUtil;
using ModelLibrary.Model;

namespace HotelRestService.Controllers
{
    public class RoomsController : ApiController
    {
        private static ManageRoom manager = new ManageRoom();

        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            return manager.Get();
        }

        // GET: api/Rooms/5
        [Route("api/Rooms/{hotel_id:int}/{room_id:int}")]
        public Room Get(int hotel_id, int room_id)
        {
            return manager.Get(hotel_id, room_id);
        }

        // POST: api/Rooms
        public bool Post([FromBody]Room room)
        {
            return manager.Post(room);

        }

        // PUT: api/Rooms/5
        [Route("api/Rooms/{hotel_id}/{room_id}")]
        public bool Put(int hotel_id, int room_id, [FromBody]Room room)
        {
           return manager.Put(hotel_id, room_id, room);
        }

        // DELETE: api/Rooms/5
        [Route("api/Rooms/{hotel_id}/{room_id}")]
        public bool Delete(int hotel_id, int room_id)
        {
           return manager.Delete(hotel_id, room_id);
        }
    }
}
