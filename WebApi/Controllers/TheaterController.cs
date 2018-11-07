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
        [Route("api/theater/{movieNum}")]
        public void Post(int movieNum, [FromBody]int hallNum)
        {
            Theaters theater = new Theaters();
            theater.movie_number = movieNum;
            theater.hall_num = hallNum;
            theater.avail_seats_arr = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            CinemaDB db = new CinemaDB();
            db.Theaters.Add(theater);
            db.SaveChanges();
        }



        // PUT api/<controller>/5
        [Route("api/theater/{movieNumber}/{newSeatsArr}")]
        public void Put(int movieNumber, string newSeatsArr)
        {
            CinemaDB db = new CinemaDB();

            Theaters theater = db.Theaters.SingleOrDefault(x => x.movie_number == movieNumber);

            if (theater != null)
            {
                theater.avail_seats_arr = newSeatsArr;
                db.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}