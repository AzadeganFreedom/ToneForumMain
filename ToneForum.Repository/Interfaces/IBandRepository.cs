using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IBandRepository
    {
        // Create: 
        Task<Band>? CreateBand(Band band);

        Task<Band>? CreateBand2();

        //##############################################################################################################

        // Read: 
        Task<IEnumerable<Band>>? GetAllBands();
        Task<Band>? GetBandById(int id);
        Task<Band>? GetBandByBandName(string bandName);

        //##############################################################################################################

        // Update:
        Task<Band>? UpdateBandById(int id, Band updatedBandData);
        Task<Band>? UpdateBandByBandName(string bandName, Band updatedBandData);

        //##############################################################################################################

        // Delete: 
        Task<Band>? DeleteBandById(int id);
        Task<Band>? DeleteBandByBandName(string bandName);
    }
}
