using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Interfaces;

namespace ToneForum.Repository.Models
{
    public class User : IUser
    {
        [Key]
        public int User_Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool AcceptTermsAndPolicy { get; set; }

        // 1:1 relations
        //public CollectionLists CollectionList_Id { get; set; }
        //public WantLists WantList_Id { get; set; }
    }
}
