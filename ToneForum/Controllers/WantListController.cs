using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WantListController : ControllerBase
    {
        private readonly IWantListRepository wantListRepo;
        private readonly IReleaseRepository releaseRepo;

        public WantListController(IWantListRepository wantListRepo, IReleaseRepository releaseRepo)
        {
            this.wantListRepo = wantListRepo;
            this.releaseRepo = releaseRepo;
        }

        // Create: 

        //##############################################################################################################

        // Read:

        [HttpGet("{id:int}")] // Get WantList by Id
        public async Task<IActionResult> GetWantListById(int id)
        {
            var selectedWantList = await wantListRepo.GetWantListById(id);

            if (selectedWantList == null)
            {
                return NotFound();
            }

            return Ok(selectedWantList);
        }

        //##############################################################################################################

        // Update: 
        [HttpPatch("{id:int}")] // Update WantList by Id
        public async Task<IActionResult> AddToWantListById(int id, int releaseId)
        {
            var selectedWantList = await wantListRepo.AddToWantListById(id, releaseId);

            if (selectedWantList == null)
            {
                return NotFound();
            }

            return Ok(selectedWantList);
        }

        [HttpPatch("UpdateWantListByReleaseName")] // Update WantList by releaseName
        public async Task<IActionResult> AddToWantListByReleaseName(int id, string releaseName)
        {
            var selectedWantList = await wantListRepo.AddToWantListByReleaseName(id, releaseName);

            if (selectedWantList == null)
            {
                return NotFound();
            }

            return Ok(selectedWantList);
        }

        //##############################################################################################################

        // Delete: 

        [HttpDelete("{id:int}")] // Remove Release from WantList by Id
        public async Task<IActionResult> RemoveFromWantListById(int id, int releaseId)
        {
            var selectedWantList = await wantListRepo.RemoveFromWantListById(id, releaseId);

            if (selectedWantList == null)
            {
                return NotFound();
            }

            return Ok(selectedWantList);
        }

        [HttpDelete("RemoveReleaseFromWantListByReleaseName")] // Remove Release from WantList by ReleaseName
        public async Task<IActionResult> RemoveFromWantListByReleaseName(int id, string releaseName)
        {
            var selectedWantList = await wantListRepo.RemoveFromWantListByReleaseName(id, releaseName);

            if (selectedWantList == null)
            {
                return NotFound();
            }

            return Ok(selectedWantList);
        }
    }
}
