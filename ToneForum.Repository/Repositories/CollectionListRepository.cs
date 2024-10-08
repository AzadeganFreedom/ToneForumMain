using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Repositories
{
    public class CollectionListRepository : ICollectionListRepository
    {
        private readonly DataContext _context;
        private readonly IReleaseRepository _releaseRepository;
        public CollectionListRepository(DataContext Context)
        {
            _context = Context;
            _releaseRepository = new ReleaseRepository(Context);
        }

        // Create: 

        // Create CollectionList when a user is created: 
        public async Task<CollectionList>? CreateCollectionList(int user_Id)
        {
            var collectionList = new CollectionList();

            collectionList.User_Id = user_Id;
           
            _context.CollectionLists.Add(collectionList);
            await _context.SaveChangesAsync();
            return collectionList;
        }

        //##############################################################################################################

        // Read:

        // Get a CollectionList by Id: 
        public async Task<CollectionList>? GetCollectionListById(int id)
        {
            List<Release> release = new List<Release>();

            var collection = await _context.CollectionLists.FirstOrDefaultAsync(collection => collection.CollectionList_Id == id);

            var releaseObj = _context.CollectionLists.Include(c => c.Releases)
                                                     .FirstOrDefault(c => c.CollectionList_Id == collection.CollectionList_Id);

            return releaseObj;
        }

        //##############################################################################################################

        // Update: 

        // Add a release to CollectionList by Release_Id:  
        public async Task<CollectionList>? AddToCollectionListById(int id, int releaseId)
        {
            List<Release> release = new List<Release>();

            // Get current data for the CollectionList
            var collection = await _context.CollectionLists.FirstOrDefaultAsync(collection => collection.User_Id == id);

            // Get release data from releaseId
            var releaseItem = await _releaseRepository.GetReleaseById(releaseId);

            // Adds release data to release variable
            release.Add(releaseItem);

            // Updates the Collectionslists Releases join table (dbo.CollectionListRelease)
            collection.Releases = release;

            _context.CollectionLists.Update(collection);
            await _context.SaveChangesAsync();
            return collection;
        }

        // Add a release to CollectionList by ReleaseName:  
        public async Task<CollectionList>? AddToCollectionListByReleaseName(int id, string releaseName)
        {
            List<Release> release = new List<Release>();

            // Get current data for the CollectionList
            var collection = await _context.CollectionLists.FirstOrDefaultAsync(collection => collection.User_Id == id);

            // Get release data from releaseId
            var releaseItem = await _releaseRepository.GetReleaseByReleaseName(releaseName);

            // Adds release data to release variable
            release.Add(releaseItem);

            // Updates the Collectionslists Releases join table (dbo.CollectionListRelease)
            collection.Releases = release;

            _context.CollectionLists.Update(collection);
            await _context.SaveChangesAsync();
            return collection;
        }

        //##############################################################################################################

        // Delete: 

        // Remove a release from CollectionList by Release_Id
        public async Task<CollectionList>? RemoveFromCollectionListById(int id, int releaseId)
        {
            List<Release> release = new List<Release>();

            // Get the Collection list based off of the User_Id
            var collection = await _context.CollectionLists.FirstOrDefaultAsync(collection => collection.User_Id == id);

            // Get the Release related to the Collection (dbo.CollectionListRelease) by Release_Id
            var releaseItem = await _releaseRepository.GetReleaseById(releaseId);

            // Find the specific row in the join table that shares the same CollectionList_Id (var collection) and Release_Id (var releaseItem)
            var row = _context.CollectionLists.Include(c => c.Releases)
                                      .FirstOrDefault(c => c.CollectionList_Id == collection.CollectionList_Id && c.Releases
                                      .Any(r => r.Release_Id == releaseItem.Release_Id));

            // Get the Release_Id of that row and remove it from the database
            var releaseToRemove = row.Releases.FirstOrDefault(r => r.Release_Id == releaseItem.Release_Id);
            row.Releases.Remove(releaseToRemove);

            // Save changes
            await _context.SaveChangesAsync();
            return collection;
        }

        // Remove a release from CollectionList by ReleaseName
        public async Task<CollectionList>? RemoveFromCollectionListByReleaseName(int id, string releaseName)
        {
            List<Release> release = new List<Release>();

            // Get the Collection list based off of the User_Id
            var collection = await _context.CollectionLists.FirstOrDefaultAsync(collection => collection.User_Id == id);

            // Get the Release related to the Collection (dbo.CollectionListRelease) by ReleaseName
            var releaseItem = await _releaseRepository.GetReleaseByReleaseName(releaseName);

            // Find the specific row in the join table that shares the same CollectionList_Id (var collection) and Release_Id (var releaseItem)
            var row = _context.CollectionLists.Include(c => c.Releases)
                                      .FirstOrDefault(c => c.CollectionList_Id == collection.CollectionList_Id && c.Releases
                                      .Any(r => r.Release_Id == releaseItem.Release_Id));

            // Get the Release_Id of that row and remove it from the database
            var releaseToRemove = row.Releases.FirstOrDefault(r => r.Release_Id == releaseItem.Release_Id);
            row.Releases.Remove(releaseToRemove);

            // Save changes
            await _context.SaveChangesAsync();
            return collection;
        }
    }
}
