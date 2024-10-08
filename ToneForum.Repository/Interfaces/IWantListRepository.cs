using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IWantListRepository
    {
        // Create: 
        Task<WantList>? CreateWantList(int user_Id);

        //##############################################################################################################

        // Read: 
        Task<WantList>? GetWantListById(int id);

        //##############################################################################################################

        // Update: 
        Task<WantList>? AddToWantListById(int id, int releaseId);

        Task<WantList>? AddToWantListByReleaseName(int id, string releaseName);

        //##############################################################################################################

        // Delete: 
        Task<WantList>? RemoveFromWantListById(int id, int releaseId);

        Task<WantList>? RemoveFromWantListByReleaseName(int id, string releaseName);
    }
}
