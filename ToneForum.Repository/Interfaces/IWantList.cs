using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IWantList
    {
        int WantList_Id { get; set; }
        [ForeignKey("User")]
        int User_Id { get; set; }
        User User { get; set; }
        //ICollection<WantListRelease> WantListReleases { get; set; }
    }
}
