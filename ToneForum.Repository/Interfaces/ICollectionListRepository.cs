using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface ICollectionListRepository
    {
        // Create
        Task<CollectionList>? CreateCollectionList(int user_Id);

        //##############################################################################################################

        // Read:

        Task<CollectionList>? GetCollectionListById(int id);

        //##############################################################################################################

        // Update: 
        Task<CollectionList>? AddToCollectionListById(int id, int releaseId);

        Task<CollectionList>? AddToCollectionListByReleaseName(int id, string releaseName);

        //##############################################################################################################

        // Delete:
        Task<CollectionList>? RemoveFromCollectionListById(int id, int releaseId);

        Task<CollectionList>? RemoveFromCollectionListByReleaseName(int id, string releaseName);
    }
}