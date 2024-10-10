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
        [HttpPost("CreateBand")] // Add Band to database
        public async Task<IActionResult> CreateBand(Band band)
        {
            try
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
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
            
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
            try
            {
                var allBands = await repo.GetAllBands();

                if (allBands == null || !allBands.Any())
                {
                    return NotFound("No bands found.");
                }

                return Ok(allBands);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("{id:int}")] // Get Band by Id
        public async Task<IActionResult> GetBandById(int id)
        {
            try
            {
                var selectedBand = await repo.GetBandById(id);

                if (selectedBand == null)
                {
                    return NotFound();
                }

                return Ok(selectedBand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("GetBandByBandName")] // Get band by BandName
        public async Task<IActionResult> GetBandByBandName(string bandName)
        {
            try
            {
                var selectedBand = await repo.GetBandByBandName(bandName);

                if (selectedBand == null)
                {
                    return NotFound();
                }

                return Ok(selectedBand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        //##############################################################################################################

        // Update: 
        [HttpPatch("{id:int}")] // Update Band by Id
        public async Task<IActionResult> UpdateBandById(int id, [FromBody] Band updatedBandData)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpPatch("UpdateBandByBandName")] // Update Band by BandName
        public async Task<IActionResult> UpdateBandByBandName(string bandName, [FromBody] Band updatedBandData)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
            
        }

        //##############################################################################################################

        // Delete: 
        [HttpDelete("{id:int}")] // Delete Band by Id (Admin Only)
        public async Task<IActionResult> DeleteBandById(int id)
        {
            try
            {
                var selectedBand = await repo.DeleteBandById(id);

                if (selectedBand == null)
                {
                    return NotFound();
                }

                return Ok(selectedBand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }

        }

        [HttpDelete("DeleteBandByBandName")] // Delete Band by BandName (Admin Only)
        public async Task<IActionResult> DeleteBandByBandName(string bandName)
        {
            try
            {
                var selectedBand = await repo.DeleteBandByBandName(bandName);

                if (selectedBand == null)
                {
                    return NotFound();
                }

                return Ok(selectedBand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
            
        }
    }
}
