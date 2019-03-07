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
    public class FacilitetsController : ApiController
    {
        private static ManageFacilitet manager = new ManageFacilitet();

        // GET: api/Facilitets
        public IEnumerable<Facilitet> Get()
        {
            return manager.Get();
        }

        // GET: api/Facilitets/5
        public Facilitet Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Facilitets
        public bool Post([FromBody]Facilitet facilitet)
        {
            return manager.Post(facilitet);
        }

        // PUT: api/Facilitets/5
        public bool Put(int id, [FromBody]Facilitet facilitet)
        {
            return manager.Put(id, facilitet);
        }

        // DELETE: api/Facilitets/5
        public bool Delete(int id)
        {
            return manager.Delete(id);
        }
    }
}
