using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ClassLibrary;

namespace WebApi.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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