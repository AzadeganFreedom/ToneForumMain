using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IType
    {
        int Type_Id { get; set; }
        string TypeName { get; set; }
        //ICollection<Release> Releases { get; set; }
    }
}
