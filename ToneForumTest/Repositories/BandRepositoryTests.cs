using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToneForum.Repository.Models;
using ToneForum.Repository.Repositories;

namespace ToneForumTest.Repositories
{
    public class BandRepositoryTests
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly BandRepository _bandRepository;

        public BandRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "BandRepositoryTests")
                .Options;

            _context = new(_options);

            _bandRepository = new(_context);
        }
        [Fact] //Get All Bands
        public async void GetAllBands_ShouldReturnListOfBands_WhenBandsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            _context.Bands.Add(new Band
            {
                Band_Id = 1,
                BandName = "God Seed",
                Country = "Norway",
                Active = false,
                StartYear = 2008,
                EndYear = 2015
            });

            _context.Bands.Add(new Band
            {
                Band_Id = 2,
                BandName = "The Dillinger Escape Plan",
                Country = "USA",
                Active = true,
                StartYear = 1996,
                EndYear = null
            });

            await _context.SaveChangesAsync();

            // Act 
            var result = await _bandRepository.GetAllBands();

            // Assert 
            Assert.NotNull(result);
            Assert.IsType<List<Band>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetAllBands_ShouldReturnEmptyListOfBands_WhenNoBandsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            // Act 
            var result = await _bandRepository.GetAllBands();

            // Assert 
            Assert.NotNull(result);
            Assert.IsType<List<Band>>(result);
            Assert.Empty(result);
        }

        [Fact] // Create Band
        public async Task CreateBand_ShouldAddBandToDatabase_WhenBandIsValid()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var bandRepository = new BandRepository(_context);
            var newBand = new Band
            {
                Band_Id = 1,
                BandName = "Anthrax",
                Country = "USA",
                Active = true,
                StartYear = 1981,
                EndYear = null
            };

            // Act
            var result = await bandRepository.CreateBand(newBand);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Band>(result);
            Assert.Equal("Anthrax", result.BandName);

            // Verify that the band is actually added to the database
            var bandFromDb = await _context.Bands.FindAsync(result.Band_Id);
            Assert.NotNull(bandFromDb); // Ensure the band was added to the database
            Assert.Equal("Anthrax", bandFromDb.BandName); // Confirm properties
        }

        [Fact] // Get Band by Id
        public async Task GetBandById_ShouldReturnBand_WhenBandExist()
        {
            // Arrange 
            await _context.Database.EnsureDeletedAsync();
            var bandRepository = new BandRepository(_context);

            var newBand = new Band
            {
                Band_Id = 1,
                BandName = "Anthrax",
                Country = "USA",
                Active = true,
                StartYear = 1981,
                EndYear = null
            };
            await bandRepository.CreateBand(newBand);

            // Act
            var result = await bandRepository.GetBandById(newBand.Band_Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Band>(result);
            Assert.Equal(newBand.BandName, result.BandName);
            Assert.Equal(newBand.Country, result.Country);
            Assert.True(result.Active);
        }

        [Fact] //Get Band by BandName
        public async Task GetBandByBandName_ShouldReturnBand_WhenBandExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var bandRepository = new BandRepository(_context);

            var newBand = new Band
            {
                Band_Id = 1,
                BandName = "Anthrax",
                Country = "USA",
                Active = true,
                StartYear = 1981,
                EndYear = null
            };
            await bandRepository.CreateBand(newBand);

            // Act
            var result = await bandRepository.GetBandByBandName(newBand.BandName);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Band>(result);
            Assert.Equal(newBand.BandName, result.BandName);
        }

        [Fact] //Update Band By Id
        public async Task UpdateBandById_ShouldUpdateBand_WhenBandExists()
        {
            // Arrange 
            await _context.Database.EnsureDeletedAsync();
            var bandRepository = new BandRepository(_context);

            var existingBand = new Band
            {
                Band_Id = 1,
                BandName = "Antraxasdasd",
                Country = "Canada",
                Active = false,
                StartYear = 1999,
                EndYear = 2020
            };
            await bandRepository.CreateBand(existingBand);

            var updateBandData = new Band
            {
                BandName = "Anthrax!",
                Country = "USA",
                Active = true,
                StartYear = 1981,
                EndYear = null
            };

            var result = await bandRepository.UpdateBandById(existingBand.Band_Id, updateBandData);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Band>(result);
            Assert.Equal(updateBandData.BandName, result.BandName);
            //Assert.NotEqual(existingBand.BandName, result.BandName);
        }

        [Fact] //Update Band By BandName
        public async Task UpdateBandByBandName_ShouldUpdateBand_WhenBandExists()
        {
            // Arrange 
            await _context.Database.EnsureDeletedAsync();
            var bandRepository = new BandRepository(_context);

            var existingBand = new Band
            {
                Band_Id = 1,
                BandName = "Antraxasdasd",
                Country = "Canada",
                Active = false,
                StartYear = 1999,
                EndYear = 2020
            };
            await bandRepository.CreateBand(existingBand);

            var updateBandData = new Band
            {
                BandName = "Anthrax!",
                Country = "USA",
                Active = true,
                StartYear = 1981,
                EndYear = null
            };

            var result = await bandRepository.UpdateBandByBandName(existingBand.BandName, updateBandData);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Band>(result);
            Assert.Equal(updateBandData.BandName, result.BandName);
            //Assert.NotEqual(existingBand.BandName, result.BandName);
        }

        [Fact] //Delete Band By Id
        public async Task DeleteBandById_ShouldDeleteBand_WhenBandExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var bandRepository = new BandRepository(_context);

            var existingBand = new Band
            {
                BandName = "Anthrax!",
                Country = "USA",
                Active = true,
                StartYear = 1981,
                EndYear = null
            };

            await bandRepository.CreateBand(existingBand);

            // Act 
            var result = await bandRepository.DeleteBandById(existingBand.Band_Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Band>(result);
            Assert.Equal(existingBand.BandName, result.BandName);
        }

        [Fact] //Delete Band By BandName
        public async Task DeleteBandByBandName_ShouldDeleteBand_WhenBandExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var bandRepository = new BandRepository(_context);

            var existingBand = new Band
            {
                BandName = "Anthrax!",
                Country = "USA",
                Active = true,
                StartYear = 1981,
                EndYear = null
            };

            await bandRepository.CreateBand(existingBand);

            // Act 
            var result = await bandRepository.DeleteBandByBandName(existingBand.BandName);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Band>(result);
            Assert.Equal(existingBand.BandName, result.BandName);
        }
    }
}
