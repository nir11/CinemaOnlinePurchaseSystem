using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ClassLibrary;
using WebApi.DTO;

namespace WebApi.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/<controller>
        public List<OrderHistoryDto> Get()
        {
            //return new string[] { "value1", "value2" };
            CinemaDB db = new CinemaDB();

            return db.Orders.OrderBy(y => y.order_date).Select(x => new OrderHistoryDto()
            {
                id = x.id,
                order_date = x.order_date,
                name = x.Movies.name,
                movie_date = x.Movies.date,
                user_seats = x.user_seats_amount,
                user_seats_positions = x.user_seats_positions
            }).ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route("api/order/{num}/{seatsAmount}")]
        public void Post(int num, int seatsAmount, [FromBody]string seatsPositions)
        {
            Orders order = new Orders();
            order.movie_number = num;
            order.user_seats_amount = seatsAmount;
            order.order_date = DateTime.Now;
            order.user_seats_positions = seatsPositions;
            CinemaDB db = new CinemaDB();
            db.Orders.Add(order);
            db.SaveChanges();

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