using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToneForum.Repository.Models
{
    public class CollectionListReleases
    {
        // Foreign key for CollectionList
        [ForeignKey("CollectionList")]
        public int CollectionList_Id { get; set; }
        public CollectionList CollectionList { get; set; }

        // Foreign key for Releases
        [ForeignKey("Release")]
        public int Release_Id { get; set; }
        public Release Release { get; set; }
    }
}

