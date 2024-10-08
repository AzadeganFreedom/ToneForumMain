using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;
        public GenreRepository(DataContext Context)
        {
            _context = Context;
        }

        //##############################################################################################################

        // Add Genre to database: 
        public async Task<Genre>? AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        //##############################################################################################################

        // Get all Bands: 
        public async Task<IEnumerable<Genre>>? GetAllGenres()
        {
            var listOfGenres = await _context.Genres.ToListAsync();
            return listOfGenres;
        }

        // Get Genre by Id: 
        public async Task<Genre>? GetGenreById(int id)
        {
            return await _context.Genres.FirstOrDefaultAsync(genre => genre.Genre_Id == id);
        }

        // Get Genre by GenreName
        public async Task<Genre>? GetGenreByGenreName(string genreName)
        {
            return await _context.Genres.FirstOrDefaultAsync(genre => genre.GenreName == genreName);
        }

        //##############################################################################################################

    }
}
