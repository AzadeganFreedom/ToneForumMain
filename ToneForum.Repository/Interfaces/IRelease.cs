using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;
using System.Text.Json.Serialization;

namespace ToneForum.Repository.Interfaces
{
    public interface IRelease
    {
        int Release_Id { get; set; }
        string ReleaseName { get; set; }
        double ReleaseYear { get; set; }


        //[ForeignKey("Band")]
        //int Band_Id { get; set; }
        //Band Band { get; set; }
        //[ForeignKey("Type")]
        //int Type_Id { get; set; }
        //Models.Type Type { get; set; }


        //ICollection<Genre> ReleaseGenres { get; set; }
        //ICollection<Format> ReleaseFormatsJoin { get; set; }
        //ICollection<CollectionList> CollectionListReleases { get; set; }
        //ICollection<WantList> WantListReleases { get; set; }

        //ICollection<ReleaseGenre> ReleaseGenres { get; set; }
        //ICollection<ReleaseFormatJoin> ReleaseFormatsJoin { get; set; }
        //ICollection<CollectionListReleases> CollectionListReleases { get; set; }
        //ICollection<WantListRelease> WantListReleases { get; set; }
    }
}
