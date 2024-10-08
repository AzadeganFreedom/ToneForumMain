using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToneForum.Repository.Models
{
    public class ReleaseGenre
    {
        public int Release_Id { get; set; }
        public Release Release { get; set; }

        public int Genre_Id { get; set; }
        public Genre Genre { get; set; }
    }
}
