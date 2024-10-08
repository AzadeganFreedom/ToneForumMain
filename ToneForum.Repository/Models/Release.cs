using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToneForum.Repository.Interfaces;
using System.Text.Json.Serialization;

namespace ToneForum.Repository.Models
{
    public class Release : IRelease
    {
        [Key] 
        public int Release_Id { get; set; }

        [Required]
        public string ReleaseName { get; set; }
        [Required]
        public double ReleaseYear { get; set; }

        // Foreign Key for the 1:M relationship with Bands
        [ForeignKey("Band")]
        public int Band_Id { get; set; }
        [JsonIgnore]
        public Band? Band { get; set; }

        // 1:M relationship with ReleaseTypes
        [ForeignKey("Type")]
        public int Type_Id { get; set; }
        [JsonIgnore]
        public Type? Type { get; set; }


        // M:M relationship with Genres through join table
        [ForeignKey("Genre")]
        public int[] Genre_Id { get; set; }
        [JsonIgnore]
        public List<Genre> Genres { get; set; } = new List<Genre>();


        // Navigation property for 1:M with WantList
        [JsonIgnore]
        public List<WantList> WantLists { get; set; } = new List<WantList>();

        // Navigation property for 1:M with CollectionList
        [JsonIgnore]
        public List<CollectionList> CollectionLists { get; set; } = new List<CollectionList>();


        // M:M relationship with ReleaseFormats through join table
        //public ICollection<ReleaseFormatJoin> ReleaseFormatsJoin; //{ get; set; }

        // M:M relationship with CollectionLists through join table
        //public ICollection<CollectionListReleases> CollectionListReleases; //{ get; set; }

        // M:M relationship with WantLists through join table
        //public ICollection<WantListRelease> WantListReleases; //{ get; set; }


        //// M:M relationship with Genres through join table
        //public ICollection<Genre> ReleaseGenres { get; set; }

        //// M:M relationship with ReleaseFormats through join table
        //public ICollection<Format> ReleaseFormatsJoin { get; set; }

        //// M:M relationship with CollectionLists through join table
        //public ICollection<CollectionList> CollectionListReleases { get; set; }

        //// M:M relationship with WantLists through join table
        //public ICollection<WantList> WantListReleases { get; set; }

    }
}
