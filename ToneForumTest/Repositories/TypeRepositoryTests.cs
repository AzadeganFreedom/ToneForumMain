using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;
using ToneForum.Repository.Repositories;
using Type = ToneForum.Repository.Models.Type;

namespace ToneForumTest.Repositories
{
    public class TypeRepositoryTests
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly TypeRepository _typeRepository;

        public TypeRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TypeRepositoryTests")
                .Options;

            _context = new(_options);
            _typeRepository = new(_context);
        }

        [Fact] //Get All Types
        public async void GetAllTypes_ShouldReturnListOfTypes_WhenTypesExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            _context.Types.Add(new Type
            {
                Type_Id = 1,
                TypeName = "LP"

            });

            _context.Types.Add(new Type
            {
                Type_Id = 2,
                TypeName = "EP"

            });

            await _context.SaveChangesAsync();

            // Act 
            var result = await _typeRepository.GetAllTypes();

            // Assert 
            Assert.NotNull(result);
            Assert.IsType<List<Type>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact] // Get Type By Id
        public async Task getTypeById_ShouldReturnType_WhenTypeExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var typeRepository = new TypeRepository(_context);

            _context.Types.Add(new ToneForum.Repository.Models.Type
            {
                Type_Id = 1,
                TypeName = "LP"

            });

            await _context.SaveChangesAsync();

            // Act
            var result = await typeRepository.GetTypeById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Type>(result);
            Assert.Equal(1, result.Type_Id);
        }

        [Fact] // Get Type By TypeName
        public async Task getTypeByTypeName_ShouldReturnType_WhenTypeExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var typeRepository = new TypeRepository(_context);

            _context.Types.Add(new ToneForum.Repository.Models.Type
            {
                Type_Id = 1,
                TypeName = "LP"

            });

            await _context.SaveChangesAsync();

            // Act
            var result = await typeRepository.GetTypeByTypeName("LP");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Type>(result);
            Assert.Equal("LP", result.TypeName);
        }
    }
}
