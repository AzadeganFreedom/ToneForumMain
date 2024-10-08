using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;


namespace ToneForum.Repository.Repositories
{
    public class ReleaseRepository : IReleaseRepository
    {
        private readonly DataContext _context;
        private readonly IGenreRepository _genreRepository;
        public ReleaseRepository(DataContext Context)
        {
            _context = Context;
            _genreRepository = new GenreRepository(Context);
        }

        // Create: 

        // Create a Release: 
        public async Task<Release>? CreateRelease(Release release)
        {
            List<Genre> genre = new List<Genre>();
            foreach (var id in release.Genre_Id)
            {
                var genreItem = await _genreRepository.GetGenreById(id);

                genre.Add(genreItem);
                
            }
            var newRelease = new Release
            {
                ReleaseName = release.ReleaseName,
                ReleaseYear = release.ReleaseYear,
                Band_Id = release.Band_Id,
                Type_Id = release.Type_Id,
                Genre_Id = release.Genre_Id,
                Genres = genre
            };

            _context.Releases.Add(newRelease);
            await _context.SaveChangesAsync();
            return newRelease;
        }

        public async Task<Release>? CreateRelease2()
        {
            Genre g = new Genre();
            g.GenreName = "Punk Rock";
            g.ParentGenre = "Punk";
            List<Genre> genre = new List<Genre>();

            var checkGenre = await _genreRepository.GetGenreByGenreName(g.GenreName);
            if (checkGenre == null)
            {
                genre.Add(g);
                var release = new Release
                {
                    ReleaseName = "Ramones",
                    ReleaseYear = 1976,
                    Band_Id = 5,
                    Type_Id = 1,
                    Genre_Id = [g.Genre_Id],
                    Genres = genre
                };
                _context.Releases.Add(release);
                await _context.SaveChangesAsync();
                return release;
            }
            else
            {
                genre.Add(checkGenre);
                var release = new Release
                {
                    ReleaseName = "Ramones",
                    ReleaseYear = 1976,
                    Band_Id = 5,
                    Type_Id = 1,
                    Genre_Id = [checkGenre.Genre_Id],
                    Genres = genre
                };
                _context.Releases.Add(release);
                await _context.SaveChangesAsync();
                return release;
            }
        }

        //##############################################################################################################

        // Read: 

        // Get all Releases: 
        public async Task<IEnumerable<Release>>? GetAllReleases()
        {
            var listOfReleases = await _context.Releases.ToListAsync();
            return listOfReleases;
        }

        // Get a Release by Id: 
        public async Task<Release>? GetReleaseById(int id)
        {
            return await _context.Releases.FirstOrDefaultAsync(release => release.Release_Id == id);
        }

        // Get Releases by BandId:
        public async Task<List<Release>>? GetReleaseByBandId(int bandId)
        {
            //return await _context.Releases.FirstOrDefaultAsync(release => release.Band_Id == bandId);
            return await _context.Releases.Where(release => release.Band_Id == bandId).ToListAsync();
        }

        // Get a Release by ReleaseName: 
        public async Task<Release>? GetReleaseByReleaseName(string releaseName)
        {
            return await _context.Releases.FirstOrDefaultAsync(release => release.ReleaseName == releaseName);
        }

        //##############################################################################################################

        // Update: 

        // Update Release by Id:
        public async Task<Release>? UpdateReleaseById(int id, Release updatedReleaseData)
        {

            List<Genre> genre = new List<Genre>();

            // Get updated genres
            foreach (var genre_Id in updatedReleaseData.Genre_Id)
            {
                var genreItem = await _genreRepository.GetGenreById(genre_Id);

                genre.Add(genreItem);

            }
            // Get the current data for the release
            var release = await _context.Releases.FirstOrDefaultAsync(release => release.Release_Id == id);

            // Find the Genres related to the current release (dbo.GenreRelease join table)
            var obj = _context.Releases.Include(r => r.Genres)
                                       .FirstOrDefault(r => r.Release_Id == release.Release_Id);

            // Removes the gurrent Genres related to the current release (dbo.GenreRelease join table)
            foreach (var genre_Id in release.Genre_Id)
            {
                var genreToRemove = obj.Genres.FirstOrDefault(g => g.Genre_Id == genre_Id);
                obj.Genres.Remove(genreToRemove);
            }

            // Update current data with updated data
            release.ReleaseName = updatedReleaseData.ReleaseName;
            release.ReleaseYear = updatedReleaseData.ReleaseYear;
            release.Genre_Id = updatedReleaseData.Genre_Id;
            release.Genres = genre; // Adds the new Genres

            _context.Releases.Update(release);
            await _context.SaveChangesAsync();
            return release;
        }

        // Update Release by ReleaseName:
        public async Task<Release>? UpdateReleaseByReleaseName(string releaseName, Release updatedReleaseData)
        {
            List<Genre> genre = new List<Genre>();

            // Get updated genres
            foreach (var genre_Id in updatedReleaseData.Genre_Id)
            {
                var genreItem = await _genreRepository.GetGenreById(genre_Id);

                genre.Add(genreItem);

            }
            // Get the current data for the release
            var release = await _context.Releases.FirstOrDefaultAsync(release => release.ReleaseName == releaseName);

            // Find the Genres related to the current release (dbo.GenreRelease join table)
            var obj = _context.Releases.Include(r => r.Genres)
                                       .FirstOrDefault(r => r.Release_Id == release.Release_Id);

            // Removes the gurrent Genres related to the current release (dbo.GenreRelease join table)
            foreach (var genre_Id in release.Genre_Id)
            {
                var genreToRemove = obj.Genres.FirstOrDefault(g => g.Genre_Id == genre_Id);
                obj.Genres.Remove(genreToRemove);
            }

            

            release.ReleaseName = updatedReleaseData.ReleaseName;
            release.ReleaseYear = updatedReleaseData.ReleaseYear;
            release.Genre_Id = updatedReleaseData.Genre_Id;
            release.Genres = genre; // Adds the new Genres

            _context.Releases.Update(release);
            await _context.SaveChangesAsync();
            return release;
        }

        //##############################################################################################################

        // Delete: 

        // Delete Release by Id (Admin Only!):
        public async Task<Release>? DeleteReleaseById(int id)
        {
            var release = await _context.Releases.FirstOrDefaultAsync(release => release.Release_Id == id);

            _context.Releases.Remove(release);
            await _context.SaveChangesAsync();
            return release;
        }

        // Delete Release by ReleaseName (Admin Only!):
        public async Task<Release>? DeleteReleaseByReleaseName(string releaseName)
        {
            var release = await _context.Releases.FirstOrDefaultAsync(release => release.ReleaseName == releaseName);

            _context.Releases.Remove(release);
            await _context.SaveChangesAsync();
            return release;
        }
    }
}
