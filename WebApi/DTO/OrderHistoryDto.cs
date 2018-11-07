using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class OrderHistoryDto
    {
        public int id;
        public int? user_seats;
        public string order_date;
        public string name;
        public string movie_date;

    }
}