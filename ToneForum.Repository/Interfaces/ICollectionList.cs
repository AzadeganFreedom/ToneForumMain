using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface ICollectionList
    {
        int CollectionList_Id { get; set; }
        [ForeignKey("User_Id")]
        int User_Id { get; set; }
        User User { get; set; }
        //ICollection<CollectionListReleases> CollectionListReleases { get; set; }
    }
}
