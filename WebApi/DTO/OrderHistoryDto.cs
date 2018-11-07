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
        public DateTime? order_date;
        public string name;
        public DateTime? movie_date;
        public string user_seats_positions;

    }
}