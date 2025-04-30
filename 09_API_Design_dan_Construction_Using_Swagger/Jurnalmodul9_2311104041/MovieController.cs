using Microsoft.AspNetCore.Mvc;

namespace Jurnalmodul9_2311104041
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> Movies = new List<Movie>
    {
        new Movie { Title = "The Shawshank Redemption", Director = "Frank Darabont", Stars = new List<string> { "Tim Robbins", "Morgan Freeman" }, Description = "Two imprisoned men bond over years." },
        new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", Stars = new List<string> { "Marlon Brando", "Al Pacino" }, Description = "The aging patriarch of an organized crime dynasty..." },
        new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", Stars = new List<string> { "Christian Bale", "Heath Ledger" }, Description = "Batman battles the Joker." }
    };

        [HttpGet]
        public ActionResult<List<Movie>> Get() => Movies;

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id) => (id < 0 || id >= Movies.Count) ? NotFound() : Movies[id];

        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            Movies.Add(movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= Movies.Count) return NotFound();
            Movies.RemoveAt(id);
            return Ok();
        }
    }
}