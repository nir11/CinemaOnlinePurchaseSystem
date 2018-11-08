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
    public class MovieController : ApiController
    {
        // GET api/<controller>
        public List<MovieDto> Get()
        {
            CinemaDB db = new CinemaDB();

            return db.Movies.Select(x => new MovieDto()
            {
                number = x.number,
                name = x.name,
                date = x.date,
                year = x.year,
                genre = x.genre,
                length = x.length,
                movie_img_url = x.movie_img_url,
                seats = x.seats
            }).OrderBy(y => y.date).ToList();
        }

        // GET api/<controller>/5
        public List<MovieDto> Get(string id)
        {
            CinemaDB db = new CinemaDB();
            return db.Movies.Where(s => s.name.StartsWith(id)).Select(x => new MovieDto()
            {
                number = x.number,
                name = x.name,
                date = x.date,
                year = x.year,
                genre = x.genre,
                length = x.length,
                movie_img_url = x.movie_img_url,
                seats = x.seats
            }).OrderBy(y => y.date).ToList();
        }

        // POST api/<controller>
        public void Post()
        {

            Movies movie = new Movies();
            movie.name = HttpContext.Current.Request.Params["name"];
            movie.date = Convert.ToDateTime(HttpContext.Current.Request.Params["date"]);
            movie.year = HttpContext.Current.Request.Params["year"];
            movie.genre = HttpContext.Current.Request.Params["genre"];
            movie.length = Convert.ToInt32(HttpContext.Current.Request.Params["length"]);
            movie.seats = Convert.ToInt32(HttpContext.Current.Request.Params["seats"]);

            HttpPostedFile file = HttpContext.Current.Request.Files["img"];
            //string ext = Path.GetExtension(file.FileName);      
            file.SaveAs(HttpContext.Current.Server.MapPath("~") + "/images/" + file.FileName);
            movie.movie_img_url = "/images/" + file.FileName;

            Theaters theater = new Theaters();
            theater.hall_num = Convert.ToInt32(HttpContext.Current.Request.Params["hall_num"]);
            theater.avail_seats_arr = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            
            movie.Theaters.Add(theater);

            CinemaDB db = new CinemaDB();
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        // PUT api/<controller>/5
        [Route("api/movie/{movieNumber}/{userAmountSeats}")]
        public void Put(int movieNumber, string userAmountSeats)
        {
            CinemaDB db = new CinemaDB();

            Movies movie = db.Movies.SingleOrDefault(x => x.number == movieNumber);

            if (movie != null)
            {
                int? oldAmount = movie.seats;
                movie.seats = oldAmount- Convert.ToInt32(userAmountSeats);
                db.SaveChanges();
            }          
        }

    }
}