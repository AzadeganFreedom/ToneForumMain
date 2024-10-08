using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IGenreRepository
    {
        // Create: 
        Task<Genre>? AddGenre(Genre genre);

        //##############################################################################################################

        // Read: 
        Task<IEnumerable<Genre>>? GetAllGenres();
        Task<Genre>? GetGenreById(int id);
        Task<Genre>? GetGenreByGenreName(string genreName);

        //##############################################################################################################

        // Update: 

        //##############################################################################################################

        // Delete: 

    }
}
