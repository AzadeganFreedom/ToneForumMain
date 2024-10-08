using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionListController : ControllerBase
    {
        private readonly ICollectionListRepository collectionRepo;
        private readonly IReleaseRepository releaseRepo;

        public CollectionListController(ICollectionListRepository collectionRepo, IReleaseRepository releaseRepo)
        {
            this.collectionRepo = collectionRepo;
            this.releaseRepo = releaseRepo;
        }

        // Create: 

        //##############################################################################################################

        // Read:

        [HttpGet("{id:int}")] // Get CollectionList by Id
        public async Task<IActionResult> GetCollectionListById(int id)
        {
            var selectedCollection = await collectionRepo.GetCollectionListById(id);

            if (selectedCollection == null)
            {
                return NotFound();
            }

            return Ok(selectedCollection);
        }

        //##############################################################################################################

        // Update: 
        [HttpPatch("{id:int}")] // Update CollectionList by Id
        public async Task<IActionResult> AddToCollectionById(int id, int releaseId)
        {
            var selectedCollection = await collectionRepo.AddToCollectionListById(id, releaseId);

            if (selectedCollection == null)
            {
                return NotFound();
            }

            return Ok(selectedCollection);
        }

        [HttpPatch("UpdateCollectionListByReleaseName")] // Update CollectionList by releaseName
        public async Task<IActionResult> AddToCollectionByName(int id, string releaseName)
        {
            var selectedCollection = await collectionRepo.AddToCollectionListByReleaseName(id, releaseName);

            if (selectedCollection == null)
            {
                return NotFound();
            }

            return Ok(selectedCollection);
        }

        //##############################################################################################################

        // Delete: 

        [HttpDelete("{id:int}")] // Remove Release from CollectionList by Id
        public async Task<IActionResult> RemoveFromCollectionListById(int id, int releaseId)
        {
            var selectedCollection = await collectionRepo.RemoveFromCollectionListById(id, releaseId);

            if (selectedCollection == null)
            {
                return NotFound();
            }

            return Ok(selectedCollection);
        }

        [HttpDelete("RemoveReleaseFromCollectionListByReleaseName")] // Remove Release from CollectionList by ReleaseName
        public async Task<IActionResult> RemoveFromCollectionListByReleaseName(int id, string releaseName)
        {
            var selectedCollection = await collectionRepo.RemoveFromCollectionListByReleaseName(id, releaseName);

            if (selectedCollection == null)
            {
                return NotFound();
            }

            return Ok(selectedCollection);
        }
    }
}
