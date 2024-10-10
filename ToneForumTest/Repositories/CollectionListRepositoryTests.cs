using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToneForum.Repository.Models;
using ToneForum.Repository.Repositories;

namespace ToneForumTest.Repositories
{
    public class CollectionListRepositoryTests
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly CollectionListRepository _collectionRepository;

        public CollectionListRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "CollectionListRepositoryTests")
                .Options;

            _context = new(_options);

            _collectionRepository = new(_context);
        }
        [Fact] //Create Collection
        public async Task CreateCollectionList_ShouldAddCollectionListInDatabase_IfCollectionListIsValid()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            var collectionRepository = new CollectionListRepository(_context);
            var newCollection = new CollectionList
            {
                User_Id = 1,
                CollectionList_Id = 1,
            };

            // Act
            var result = await collectionRepository.CreateCollectionList(newCollection.User_Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CollectionList>(result);
            Assert.Equal(1, result.User_Id);
        }

        [Fact] // Get Collection by Id
        public async Task GetCollectionById_ShouldReturnCollection_WhenCollectionExist()
        {
            // Arrange 
            await _context.Database.EnsureDeletedAsync();
            var collectionRepository = new CollectionListRepository(_context);

            var newCollection = new CollectionList
            {
                User_Id = 1,
                CollectionList_Id = 1
            };
            await collectionRepository.CreateCollectionList(newCollection.User_Id);

            // Act
            var result = await collectionRepository.GetCollectionListById(newCollection.User_Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CollectionList>(result);
            Assert.Equal(newCollection.User_Id, result.User_Id);
            Assert.Equal(newCollection.CollectionList_Id, result.CollectionList_Id);
        }
    }
}
