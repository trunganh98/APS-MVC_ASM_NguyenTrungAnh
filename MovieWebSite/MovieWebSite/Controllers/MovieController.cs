using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieWebSite.Models;
using MovieWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace MovieWebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        public MovieController(JsonFileMovieServices movieService)
        {
            this.MovieService = movieService;
        }

        public JsonFileMovieServices MovieService { get; }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return MovieService.GetMovies();
        }

        //[HttpPatch]
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string MovieId,
            [FromQuery] int Rating)
        {
            MovieService.AddRating(MovieId, Rating);
            return Ok();
        }
    }
}
