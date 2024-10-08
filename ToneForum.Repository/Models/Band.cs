using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ToneForum.Repository.Interfaces;

namespace ToneForum.Repository.Models
{
    public class Band : IBand
    {
        [Key]
        public int Band_Id { get; set; }

        [Required]
        public string BandName { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public  bool Active { get; set; }
        [Required]
        public  double StartYear { get; set; }
        public double? EndYear { get; set; }

        // Navigation property for 1:M relationship with Releases
        //public ICollection<Release> Releases { get; set; }
    }
}
