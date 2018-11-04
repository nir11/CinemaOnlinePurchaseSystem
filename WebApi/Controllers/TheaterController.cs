using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary;
using WebApi.DTO;

namespace WebApi.Controllers
{
    public class TheaterController : ApiController
    {
        //// GET api/<controller>
        public int Get()
        {
            //return new string[] { "value1", "value2" };
            //CinemaDB db = new CinemaDB();
            //return db.Theater.Select(x => x.avail_seats);
            return 1;
        }

        // GET api/<controller>/5
        [Route("api/theater/{s}/{number}")]
        public TheaterDto Get(string s, int number)
        {
            CinemaDB db = new CinemaDB();
            return db.Theaters.Where(y => y.movie_number == number).Select(x => new TheaterDto()
            {
                avail_seats_arr = x.avail_seats_arr,
                hall_num = x.hall_num
            }).First();
 
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}