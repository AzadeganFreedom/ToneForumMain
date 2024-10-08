using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext Context)
        {
            _context = Context;
        }

        //##############################################################################################################

        // Create a User: 
        public async Task<User>? CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //##############################################################################################################

        // Get all Users (Admin Only!): 
        public async Task<IEnumerable<User>>? GetAllUsers()
        {
            var listOfUsers = await _context.Users.ToListAsync();
            return listOfUsers;
        }

        // Get a User by Id: 
        public async Task<User>? GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.User_Id == id);
        }

        // Get a User by UserName: 
        public async Task<User>? GetUserByUserName(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName && user.Password == password);
        }

        //##############################################################################################################

        // Update User by Id:
        public async Task<User>? UpdateUserById(int id, User updatedUserData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.User_Id == id);

            user.FirstName = updatedUserData.FirstName;
            user.LastName = updatedUserData.LastName;
            user.UserName = updatedUserData.UserName;
            user.Password = updatedUserData.Password;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Update User by UserName:
        public async Task<User>? UpdateUserByUserName(string userName, User updatedUserData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName);

            user.FirstName = updatedUserData.FirstName;
            user.LastName = updatedUserData.LastName;
            user.UserName = updatedUserData.UserName;
            user.Password = updatedUserData.Password;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //##############################################################################################################

        // Delete User by Id (Admin Only!):
        public async Task<User>? DeleteUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.User_Id == id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Delete User by UserName (Admin Only!):
        public async Task<User>? DeleteUserByUserName(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
