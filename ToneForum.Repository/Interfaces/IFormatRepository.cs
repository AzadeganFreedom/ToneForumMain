using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IFormatRepository
    {

        // Create: 

        //##############################################################################################################

        // Read: 
        Task<Format>? GetFormatById(int id);
        Task<Format>? GetFormatByFormatName(string formatName);

        //##############################################################################################################

        // Update: 

        //##############################################################################################################

        // Delete: 
    }
}
