using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary;
using System.Web;
using System.IO;
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

            return db.Orders.Select(x => new OrderHistoryDto()
            {
                id = x.id,
                order_date = x.order_date.ToString(),
                name = x.Movies.name,
                movie_date = x.Movies.date.ToString(),
                user_seats = x.user_seats
            }).ToList();
        }

        // GET api/<controller>/5
        public List<OrderHistoryDto> Get(int id)
        {
            return null;
        }

        // POST api/<controller>
        [HttpPost]
        public void setNewOrder()
        {
            Orders order = new Orders();
            order.movie_number = Convert.ToInt32(HttpContext.Current.Request.Params["number"]);
            order.user_seats = Convert.ToInt32(HttpContext.Current.Request.Params["userAmountChoice"]);
            order.order_date = DateTime.Now;
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