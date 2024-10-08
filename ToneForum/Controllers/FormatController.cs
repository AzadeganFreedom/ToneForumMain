using Microsoft.AspNetCore.Mvc;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormatController : ControllerBase
    {
        private readonly IFormatRepository repo;

        public FormatController(IFormatRepository repo)
        {
            this.repo = repo;
        }

        // Create: 

        //##############################################################################################################

        // Read: 
        [HttpGet("{id:int}")] // Get Format by Id
        public async Task<IActionResult> GetFormatById(int id)
        {
            var selectedFormat = await repo.GetFormatById(id);

            if (selectedFormat == null)
            {
                return NotFound();
            }

            return Ok(selectedFormat);
        }

        [HttpGet("GetFormatByFormatName")] // Get Format by FormatName
        public async Task<IActionResult> GetFormatByFormatName(string formatName)
        {
            var selectedFormat = await repo.GetFormatByFormatName(formatName);

            if (selectedFormat == null)
            {
                return NotFound();
            }

            return Ok(selectedFormat);
        }

        //##############################################################################################################

        // Update: 

        //##############################################################################################################

        // Delete: 
    }
}
