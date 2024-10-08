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
    public class BandRepository : IBandRepository
    {
        private readonly DataContext _context;
        public BandRepository(DataContext Context)
        {
            _context = Context;
        }

        // Create: 

        // Create a Band: 
        public async Task<Band>? CreateBand(Band band)
        {
            _context.Bands.Add(band);
            await _context.SaveChangesAsync();
            return band;
        }


        public async Task<Band>? CreateBand2()
        {
            Genre g = new Genre();
            g.GenreName = "Punk Rock";
            g.ParentGenre = "Punk";
            List<Genre> genre = new List<Genre>();
            genre.Add(g);
            //List<String> strings = new List<String>();  
            var band = new Band
            {
                BandName = "Megadeth",
                Country = "USA",
                Active = true,
                StartYear = 1983,
                //ged  = genre
            };
            _context.Bands.Add(band);
            await _context.SaveChangesAsync();
            return band;
        }



        //##############################################################################################################

        // Read: 

        // Get all Bands: 
        public async Task<IEnumerable<Band>>? GetAllBands()
        {
            var listOfBands = await _context.Bands.ToListAsync();
            return listOfBands;
        }

        // Get a Band by Id: 
        public async Task<Band>? GetBandById(int id)
        {
            return await _context.Bands.FirstOrDefaultAsync(band => band.Band_Id == id);
        }

        // Get a Band by BandName: 
        public async Task<Band>? GetBandByBandName(string bandName)
        {
            return await _context.Bands.FirstOrDefaultAsync(band => band.BandName == bandName);
        }

        //##############################################################################################################

        // Update: 

        // Update Band by Id:
        public async Task<Band>? UpdateBandById(int id, Band updatedBandData)
        {
            var band = await _context.Bands.FirstOrDefaultAsync(band => band.Band_Id == id);

            band.BandName = updatedBandData.BandName;
            band.Country = updatedBandData.Country;
            band.Active = updatedBandData.Active;
            band.StartYear = updatedBandData.StartYear;
            band.EndYear = updatedBandData.EndYear;

            _context.Bands.Update(band);
            await _context.SaveChangesAsync();
            return band;
        }

        // Update Band by BandName:
        public async Task<Band>? UpdateBandByBandName(string bandName, Band updatedBandData)
        {
            var band = await _context.Bands.FirstOrDefaultAsync(band => band.BandName == bandName);

            band.BandName = updatedBandData.BandName;
            band.Active = updatedBandData.Active;
            band.StartYear = updatedBandData.StartYear;
            band.EndYear = updatedBandData.EndYear;

            _context.Bands.Update(band);
            await _context.SaveChangesAsync();
            return band;
        }

        //##############################################################################################################

        // Delete: 

        // Delete Band by Id (Admin Only!):
        public async Task<Band>? DeleteBandById(int id)
        {
            var band = await _context.Bands.FirstOrDefaultAsync(band => band.Band_Id == id);

            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();
            return band;
        }

        // Delete Band by BandName (Admin Only!):
        public async Task<Band>? DeleteBandByBandName(string bandName)
        {
            var band = await _context.Bands.FirstOrDefaultAsync(band => band.BandName == bandName);

            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();
            return band;
        }
    }
}
