using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToneForum.Repository.Interfaces
{
    public interface ITypeRepository
    {

        // Create: 

        //##############################################################################################################

        // Read: 

        Task<IEnumerable<Models.Type>>? GetAllTypes();

        Task<Models.Type>? GetTypeById(int id);

        Task<Models.Type>? GetTypeByTypeName(string typeName);

        //##############################################################################################################

        // Update: 

        //##############################################################################################################

        // Delete: 
    }
}
