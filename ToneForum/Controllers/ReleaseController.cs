using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReleaseController : ControllerBase
    {
        private readonly IReleaseRepository releaseRepo;
        private readonly IGenreRepository genreRepo;

        public ReleaseController(IReleaseRepository releaseRepo, IGenreRepository genreRepo)
        {
            this.releaseRepo = releaseRepo;
            this.genreRepo = genreRepo;
        }

        // Create: 
        [HttpPost("CreateRelease")] // Add Release to database
        public async Task<IActionResult> CreateRelease(Release release)
        {
            if (release == null)
            {
                return BadRequest("Release is null.");
            }

            // Check if Release already exists in database
            var releaseCheck = await releaseRepo.GetReleaseByReleaseName(release.ReleaseName);
            if (releaseCheck == null) // If it doesn't exist, create Release
            {
                var newReleaseCreated = await releaseRepo.CreateRelease(release);

            }
            else // If it does exist, BadRequest
            {
                return BadRequest("A release with this name already exists!");
            }

            // Return the newly created release
            return CreatedAtAction(nameof(GetReleaseById), new { id = release.Release_Id }, release);
        }

        [HttpPost("CreateRelease2")]
        public async Task<IActionResult> CreateRelease2()
        {
            return Ok(await releaseRepo.CreateRelease2());
        }

        //##############################################################################################################

        // Read: 
        [HttpGet("GetAllReleases")] // Get all Releases
        public async Task<IActionResult> GetAllReleases()
        {
            var allReleases = await releaseRepo.GetAllReleases();

            return Ok(allReleases);
        }

        [HttpGet("{id:int}")] // Get Release by Id
        public async Task<IActionResult> GetReleaseById(int id)
        {
            var selectedRelease = await releaseRepo.GetReleaseById(id);

            if (selectedRelease == null)
            {
                return NotFound();
            }

            return Ok(selectedRelease);
        }

        [HttpGet("GetReleaseByBandId")] // Get Release by BandId
        public async Task<IActionResult> GetReleaseByBandId(int bandId)
        {
            var BandReleases = await releaseRepo.GetReleaseByBandId(bandId);

            return Ok(BandReleases);
        }

        [HttpGet("GetReleaseByReleaseName")] // Get Release by ReleaseName
        public async Task<IActionResult> GetReleaseByReleaseName(string releaseName)
        {
            var selectedRelease = await releaseRepo.GetReleaseByReleaseName(releaseName);

            if (selectedRelease == null)
            {
                return NotFound();
            }

            return Ok(selectedRelease);
        }

        //##############################################################################################################

        // Update: 

        [HttpPatch("{id:int}")] // Update Release by Id
        public async Task<IActionResult> UpdateReleaseById(int id, [FromBody] Release updatedReleaseData)
        {
            if (updatedReleaseData == null)
            {
                return BadRequest("Invalid release data.");
            }

            var selectedRelease = await releaseRepo.UpdateReleaseById(id, updatedReleaseData);

            if (selectedRelease == null)
            {
                return NotFound();
            }

            return Ok(selectedRelease);
        }

        [HttpPatch("UpdateReleaseByReleaseName")] // Update Release by BandName
        public async Task<IActionResult> UpdateReleaseByReleaseName(string releaseName, [FromBody] Release updatedReleaseData)
        {
            if (updatedReleaseData == null)
            {
                return BadRequest("Invalid release data.");
            }

            var selectedRelease = await releaseRepo.UpdateReleaseByReleaseName(releaseName, updatedReleaseData);

            if (selectedRelease == null)
            {
                return NotFound();
            }

            return Ok(selectedRelease);
        }

        //##############################################################################################################

        // Delete: 

        [HttpDelete("{id:int}")] // Delete Release by Id (Admin Only)
        public async Task<IActionResult> DeleteReleaseById(int id)
        {
            var selectedRelease = await releaseRepo.DeleteReleaseById(id);

            if (selectedRelease == null)
            {
                return NotFound();
            }

            return Ok(selectedRelease);
        }

        [HttpDelete("DeleteReleaseByReleaseName")] // Delete Release by ReleaseName (Admin Only)
        public async Task<IActionResult> DeleteReleaseByReleaseName(string releaseName)
        {
            var selectedRelease = await releaseRepo.DeleteReleaseByReleaseName(releaseName);

            if (selectedRelease == null)
            {
                return NotFound();
            }

            return Ok(selectedRelease);
        }
    }
}
