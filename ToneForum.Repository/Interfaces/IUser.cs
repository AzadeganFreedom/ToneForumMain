using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IUser
    {
        int User_Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool AcceptTermsAndPolicy { get; set; }
        //CollectionLists CollectionList_Id { get; set; }
        //WantLists WantList_Id { get; set; }
    }
}
