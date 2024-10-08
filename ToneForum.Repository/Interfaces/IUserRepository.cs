using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Interfaces
{
    public interface IUserRepository
    {
        // Create
        Task<User>? CreateUser(User user);

        //##############################################################################################################

        // Read
        Task<IEnumerable<User>>? GetAllUsers();
        Task<User>? GetUserById(int id);
        Task<User>? GetUserByUserName(string userName, string password);

        //##############################################################################################################

        // Update
        Task<User>? UpdateUserById(int id, User updateUserData);
        Task<User>? UpdateUserByUserName(string userName, User updateUserData);

        //##############################################################################################################

        // Delete
        Task<User>? DeleteUserById(int id);
        Task<User>? DeleteUserByUserName(string userName);
    }
}
