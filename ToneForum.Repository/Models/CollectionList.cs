using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Interfaces;

namespace ToneForum.Repository.Models
{
    public class CollectionList : ICollectionList
    {
        [Key]
        public int CollectionList_Id { get; set; }

        // 1:1 relationship with Users
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }

        // Navigation property for 1:M with Releases
        public List<Release> Releases { get; set; } = new List<Release>();
    }
}
