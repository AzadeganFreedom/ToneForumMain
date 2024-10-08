using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IGenre
    {
        int Genre_Id { get; set; }
        string GenreName { get; set; }
        string ParentGenre { get; set; }

        //ICollection<Release> ReleaseGenres { get; set; }
        //ICollection<ReleaseGenre> ReleaseGenres { get; set; }
    }
}
