using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DataContext _context;
        public TypeRepository(DataContext Context)
        {
            _context = Context;
        }

        // Create: 

        //##############################################################################################################

        // Read: 

        // Get all Types: 
        public async Task<IEnumerable<Models.Type>>? GetAllTypes()
        {
            var listOfTypes = await _context.Types.ToListAsync();
            return listOfTypes;
        }

        // Get a Type by Id: 
        public async Task<Models.Type>? GetTypeById(int id)
        {
            return await _context.Types.FirstOrDefaultAsync(type => type.Type_Id == id);
        }

        // Get a Type by TypeName: 
        public async Task<Models.Type>? GetTypeByTypeName(string typeName)
        {
            return await _context.Types.FirstOrDefaultAsync(type => type.TypeName == typeName);
        }

        //##############################################################################################################

        // Update: 

        //##############################################################################################################

        // Delete: 
    }
}
