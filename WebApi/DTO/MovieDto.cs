using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class MovieDto
    {
        public int number;
        public string name;
        public DateTime? date;
        public string year;
        public string genre;
        public int? length;
        public string movie_img_url;
        public int? seats;
    }
}