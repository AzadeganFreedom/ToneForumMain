using Microsoft.AspNetCore.Mvc;
using ToneForum.Repository.Interfaces;

namespace ToneForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepository repo;

        public TypeController(ITypeRepository repo)
        {
            this.repo = repo;
        }

        // Create: 

        //##############################################################################################################

        // Read:

        [HttpGet("GetAllTypes")] // Get all types
        public async Task<IActionResult> GetAllTypes()
        {
            var allTypes = await repo.GetAllTypes();

            return Ok(allTypes);
        }

        [HttpGet("GetTypeById{id:int}")] // Get Type by Id
        public async Task<IActionResult> GetTypeById(int id)
        {
            var selectedType = await repo.GetTypeById(id);

            if (selectedType == null)
            {
                return NotFound();
            }

            return Ok(selectedType);
        }

        [HttpGet("GetTypeByTypeName")] // Get type by TypeName
        public async Task<IActionResult> GetTypeByTypeName(string typeName)
        {
            var selectedType = await repo.GetTypeByTypeName(typeName);

            if (selectedType == null)
            {
                return NotFound();
            }

            return Ok(selectedType);
        }

        //##############################################################################################################

        // Update: 

        //##############################################################################################################

        // Delete: 
    }
}
