using Microsoft.AspNetCore.Mvc;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository repo;

        public GenreController(IGenreRepository repo)
        {
            this.repo = repo;
        }

        //##############################################################################################################

        // Create: 
        [HttpPost] // Add Genre to database
        public async Task<IActionResult> AddGenre(Genre genre)
        {
            if (genre == null)
            {
                return BadRequest("Genre is null.");
            }

            // Check if UserName already exists in database
            var genreCheck = await repo.GetGenreByGenreName(genre.GenreName);
            if (genreCheck == null) // If it doesn't exist, create User
            {
                var newGenreAdded = await repo.AddGenre(genre);
            }
            else // If it does exist, BadRequest
            {
                return BadRequest("A Genre with this name already exists!");
            }
            

            // Return the newly created user
            return CreatedAtAction(nameof(GetGenreById), new { id = genre.Genre_Id }, genre);
        }

        //##############################################################################################################

        // Read: 
        [HttpGet("GetAllGenres")] // Get all Genres
        public async Task<IActionResult> GetAllGenres()
        {
            var allGenres = await repo.GetAllGenres();

            return Ok(allGenres);
        }

        [HttpGet("{id:int}")] // Get Genre by Id
        public async Task<IActionResult> GetGenreById(int id)
        {
            var selectedGenre = await repo.GetGenreById(id);

            if (selectedGenre == null)
            {
                return NotFound();
            }

            return Ok(selectedGenre);
        }

        [HttpGet("GetGenreByGenreName")] // Get Genre by GenreName
        public async Task<IActionResult> GetGenreByGenreName(string genreName)
        {
            var selectedGenre = await repo.GetGenreByGenreName(genreName);

            if (selectedGenre == null)
            {
                return NotFound();
            }

            return Ok(selectedGenre);
        }

        //##############################################################################################################

        // Update: 

        //##############################################################################################################

        // Delete:

    }
}
