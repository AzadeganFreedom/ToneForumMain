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
    public class WantListRepository : IWantListRepository
    {
        private readonly DataContext _context;
        private readonly IReleaseRepository _releaseRepository;
        public WantListRepository(DataContext Context)
        {
            _context = Context;
            _releaseRepository = new ReleaseRepository(_context);
        }

        // Create: 

        // Create WantList when a user is created: 
        public async Task<WantList>? CreateWantList(int user_Id)
        {
            var WantList = new WantList();

            WantList.User_Id = user_Id;

            _context.WantLists.Add(WantList);
            await _context.SaveChangesAsync();
            return WantList;
        }

        //##############################################################################################################

        // Read:

        // Get a WantList by Id: 
        public async Task<WantList>? GetWantListById(int id)
        {
            List<Release> release = new List<Release>();

            // Get current data for the WantList
            var wantList = await _context.WantLists.FirstOrDefaultAsync(wantList => wantList.WantList_Id == id);

            // Find all rows in the join table that shares the same WantList_Id (var wantList)
            var releaseObj = _context.WantLists.Include(w => w.Releases)
                                                     .FirstOrDefault(w => w.WantList_Id == wantList.WantList_Id);

            return releaseObj;
        }

        //##############################################################################################################

        // Update: 

        // Add a release to WantList by Release_Id:  
        public async Task<WantList>? AddToWantListById(int id, int releaseId)
        {
            List<Release> release = new List<Release>();

            // Get current data for the WantList
            var wantList = await _context.WantLists.FirstOrDefaultAsync(wantList => wantList.User_Id == id);

            // Get release data from releaseId
            var releaseItem = await _releaseRepository.GetReleaseById(releaseId);

            // Adds release data to release variable
            release.Add(releaseItem);

            // Updates the Wantlists Releases join table (dbo.ReleaseWantList)
            wantList.Releases = release;

            _context.WantLists.Update(wantList);
            await _context.SaveChangesAsync();
            return wantList;
        }

        // Add a release to CollectionList by ReleaseName:  
        public async Task<WantList>? AddToWantListByReleaseName(int id, string releaseName)
        {
            List<Release> release = new List<Release>();

            // Get current data for the WantList
            var wantList = await _context.WantLists.FirstOrDefaultAsync(wantList => wantList.User_Id == id);

            // Get release data from releaseId
            var releaseItem = await _releaseRepository.GetReleaseByReleaseName(releaseName);

            // Adds release data to release variable
            release.Add(releaseItem);

            // Updates the Collectionslists Releases join table (dbo.CollectionListRelease)
            wantList.Releases = release;

            _context.WantLists.Update(wantList);
            await _context.SaveChangesAsync();
            return wantList;
        }

        //##############################################################################################################

        // Delete: 

        // Remove a release from WantList by Release_Id
        public async Task<WantList>? RemoveFromWantListById(int id, int releaseId)
        {
            List<Release> release = new List<Release>();

            // Get the WantList list based off of the User_Id
            var wantList = await _context.WantLists.FirstOrDefaultAsync(wantList => wantList.User_Id == id);

            // Get the Release related to the WantList (dbo.ReleaseWantList) by Release_Id
            var releaseItem = await _releaseRepository.GetReleaseById(releaseId);

            // Find the specific row in the join table that shares the same WantList_Id (var wantList) and Release_Id (var releaseItem)
            var row = _context.WantLists.Include(c => c.Releases)
                                      .FirstOrDefault(c => c.WantList_Id == wantList.WantList_Id && c.Releases
                                      .Any(r => r.Release_Id == releaseItem.Release_Id));

            // Get the Release_Id of that row and remove it from the database
            var releaseToRemove = row.Releases.FirstOrDefault(r => r.Release_Id == releaseItem.Release_Id);
            row.Releases.Remove(releaseToRemove);

            // Save changes
            await _context.SaveChangesAsync();
            return wantList;
        }

        // Remove a release from WantList by ReleaseName
        public async Task<WantList>? RemoveFromWantListByReleaseName(int id, string releaseName)
        {
            List<Release> release = new List<Release>();

            // Get the WantList based off of the User_Id
            var wantList = await _context.WantLists.FirstOrDefaultAsync(wantList => wantList.User_Id == id);

            // Get the Release related to the WantList (dbo.ReleaseWantList) by ReleaseName
            var releaseItem = await _releaseRepository.GetReleaseByReleaseName(releaseName);

            // Find the specific row in the join table that shares the same WantList_Id (var wantList) and Release_Id (var releaseItem)
            var row = _context.WantLists.Include(c => c.Releases)
                                      .FirstOrDefault(c => c.WantList_Id == wantList.WantList_Id && c.Releases
                                      .Any(r => r.Release_Id == releaseItem.Release_Id));

            // Get the Release_Id of that row and remove it from the database
            var releaseToRemove = row.Releases.FirstOrDefault(r => r.Release_Id == releaseItem.Release_Id);
            row.Releases.Remove(releaseToRemove);

            // Save changes
            await _context.SaveChangesAsync();
            return wantList;
        }
    }
}
