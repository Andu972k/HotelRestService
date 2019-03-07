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
    public class GuestsController : ApiController
    {

        private static ManageGuest manager = new ManageGuest();

        // GET: api/Guests
        public IEnumerable<Guest> Get()
        {
            return manager.GetAllGuest();
        }

        // GET: api/Guests/5
        public Guest Get(int id)
        {
            return manager.GetGuestFromId(id);
        }

        // POST: api/Guests
        public bool Post([FromBody]Guest guest)
        {
            return manager.CreateGuest(guest);
        }

        // PUT: api/Guests/5
        public bool Put(int id, [FromBody]Guest guest)
        {
            return manager.UpdateGuest(guest, id);
        }

        // DELETE: api/Guests/5
        public bool Delete(int id)
        {
            return manager.DeleteGuest(id);
        }
    }
}
