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
    public class FormatRepository : IFormatRepository
    {
        private readonly DataContext _context;
        public FormatRepository(DataContext Context)
        {
            _context = Context;
        }

        // Create: 

        //##############################################################################################################

        // Read: 
        // Get Genre by Id: 
        public async Task<Format>? GetFormatById(int id)
        {
            return await _context.Formats.FirstOrDefaultAsync(format => format.Format_Id == id);
        }

        // Get Genre by GenreName
        public async Task<Format>? GetFormatByFormatName(string formatName)
        {
            return await _context.Formats.FirstOrDefaultAsync(format => format.FormatName == formatName);
        }

        //##############################################################################################################

        // Update: 

        //##############################################################################################################

        // Delete: 
    }
}
