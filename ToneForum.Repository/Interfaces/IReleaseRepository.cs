using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IReleaseRepository
    {
        // Create: 
        Task<Release>? CreateRelease(Release release);

        Task<Release>? CreateRelease2();

        //##############################################################################################################

        // Read: 
        Task<IEnumerable<Release>>? GetAllReleases();
        Task<Release>? GetReleaseById(int id);
        Task<List<Release>>? GetReleaseByBandId(int bandId);
        Task<Release>? GetReleaseByReleaseName(string releaseName);

        //##############################################################################################################

        // Update: 
        Task<Release>? UpdateReleaseById(int id, Release updatedReleaseData);
        Task<Release>? UpdateReleaseByReleaseName(string releaseName, Release updatedReleaseData);

        //##############################################################################################################

        // Delete: 
        Task<Release>? DeleteReleaseById(int id);
        Task<Release>? DeleteReleaseByReleaseName(string releaseName);
    }
}
