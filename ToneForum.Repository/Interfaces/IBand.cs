using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IBand
    {
        int Band_Id { get; set; }
        string BandName { get; set; }
        public string Country { get; set; }
        bool Active { get; set; }
        double StartYear { get; set; }
        double? EndYear { get; set; }
        //ICollection<Release> Releases { get; set; }
    }
}
