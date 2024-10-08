using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToneForum.Repository.Interfaces;

namespace ToneForum.Repository.Models
{
    public class Type : IType
    {
        [Key]
        public int Type_Id { get; set; }

        [Required]
        public string TypeName { get; set; }

        // Navigation property for 1:M relationship with Releases
        [JsonIgnore]
        public List<Release> Releases { get; set; }
    }
}
