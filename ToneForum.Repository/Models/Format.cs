using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Interfaces;

namespace ToneForum.Repository.Models
{
    public class Format : IFormat
    {
        [Key]
        public int Format_Id { get; set; }

        [Required]
        public string FormatName { get; set; }

        // Navigation property for the M:M relationship with Releases
        //public ICollection<ReleaseFormatJoin> ReleaseFormat { get; set; }
    }
}
