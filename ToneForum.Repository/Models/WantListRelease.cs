using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToneForum.Repository.Models
{
    public class WantListRelease
    {
        // Foreign key for WantLists
        [ForeignKey("WantList")]
        public int WantList_Id { get; set; }
        public WantList WantList { get; set; }

        // Foreign key for Releases
        [ForeignKey("Release")]
        public int Release_Id { get; set; }
        public Release Release { get; set; }
    }
}
