using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ToneForum.Repository.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToneForum.Repository.Models
{
    public class Genre : IGenre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Genre_Id { get; set; }

        [Required]
        public string GenreName { get; set; }

        [Required]
        public string ParentGenre { get; set; }

        // Navigation property for the M:M relationship with Releases
        //public ICollection<Release> ReleaseGenres;
        [JsonIgnore]
        public List<Release> Releases { get; set; } = new List<Release>();
    }
}
