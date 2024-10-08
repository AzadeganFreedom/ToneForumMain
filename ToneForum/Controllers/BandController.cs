using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BandController : ControllerBase
    {
        private readonly IBandRepository repo;

        public BandController(IBandRepository repo)
        {
            this.repo = repo;
        }

        // Create: 
        [HttpPost("CreateBand")] // Add Genre to database
        public async Task<IActionResult> CreateBand(Band band)
        {
            if (band == null)
            {
                return BadRequest("Band is null.");
            }

            // Check if Band already exists in database
            var bandCheck = await repo.GetBandByBandName(band.BandName);
            if (bandCheck == null) // If it doesn't exist, create Band
            {
                var newBandCreated = await repo.CreateBand(band);
            }
            else // If it does exist, BadRequest
            {
                return BadRequest("A band with this name already exists!");
            }

            // Return the newly created user
            return CreatedAtAction(nameof(GetBandById), new { id = band.Band_Id }, band);
        }

        [HttpPost("CreateBand2")]
        public async Task<IActionResult> CreateBand2()
        {
            return Ok(await repo.CreateBand2());
            
        }
        //##############################################################################################################

        // Read: 
        [HttpGet("GetAllBands")] // Get all bands
        public async Task<IActionResult> GetAllBands()
        {
            var allBands = await repo.GetAllBands();

            return Ok(allBands);
        }

        [HttpGet("{id:int}")] // Get Band by Id
        public async Task<IActionResult> GetBandById(int id)
        {
            var selectedBand = await repo.GetBandById(id);

            if (selectedBand == null)
            {
                return NotFound();
            }

            return Ok(selectedBand);
        }

        [HttpGet("GetBandByBandName")] // Get band by BandName
        public async Task<IActionResult> GetBandByBandName(string bandName)
        {
            var selectedBand = await repo.GetBandByBandName(bandName);

            if (selectedBand == null)
            {
                return NotFound();
            }

            return Ok(selectedBand);
        }

        //##############################################################################################################

        // Update: 
        [HttpPatch("{id:int}")] // Update Band by Id
        public async Task<IActionResult> UpdateBandById(int id, [FromBody] Band updatedBandData)
        {
            if (updatedBandData == null)
            {
                return BadRequest("Invalid band data.");
            }

            var selectedBand = await repo.UpdateBandById(id, updatedBandData);

            if (selectedBand == null)
            {
                return NotFound();
            }

            return Ok(selectedBand);
        }

        [HttpPatch("UpdateBandByBandName")] // Update Band by BandName
        public async Task<IActionResult> UpdateBandByBandName(string bandName, [FromBody] Band updatedBandData)
        {
            if (updatedBandData == null)
            {
                return BadRequest("Invalid band data.");
            }

            var selectedBand = await repo.UpdateBandByBandName(bandName, updatedBandData);

            if (selectedBand == null)
            {
                return NotFound();
            }

            return Ok(selectedBand);
        }

        //##############################################################################################################

        // Delete: 
        [HttpDelete("{id:int}")] // Delete Band by Id (Admin Only)
        public async Task<IActionResult> DeleteBandById(int id)
        {
            var selectedBand = await repo.DeleteBandById(id);

            if (selectedBand == null)
            {
                return NotFound();
            }

            return Ok(selectedBand);
        }

        [HttpDelete("DeleteBandByBandName")] // Delete Band by BandName (Admin Only)
        public async Task<IActionResult> DeleteBandByBandName(string bandName)
        {
            var selectedBand = await repo.DeleteBandByBandName(bandName);

            if (selectedBand == null)
            {
                return NotFound();
            }

            return Ok(selectedBand);
        }
    }
}
