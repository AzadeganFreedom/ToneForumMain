using Microsoft.AspNetCore.Mvc;
using ToneForum.Repository.Interfaces;
using ToneForum.Repository.Models;

namespace ToneForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepo;
        private readonly ICollectionListRepository collectionRepo;
        private readonly IWantListRepository wantListRepo;

        public UserController(IUserRepository repo1, ICollectionListRepository repo2, IWantListRepository repo3)
        {
            this.userRepo = repo1;
            this.collectionRepo = repo2;
            this.wantListRepo = repo3;
        }

        //##############################################################################################################

        // Create: 
        [HttpPost("CreateUser")] // Create user
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            // Check if UserName already exists in database
            var userCheck = await userRepo.GetUserByUserName(user.UserName, user.Password);
            if (userCheck == null) // If it doesn't exist, create User
            {
                // Creates a new user
                var newUserCreated = await userRepo.CreateUser(user);

                // Creates a new CollectionList for the user
                var newCollectionList = await collectionRepo.CreateCollectionList(user.User_Id);

                // Creates a new WantList for the user
                var newWantList = await wantListRepo.CreateWantList(user.User_Id);
            }
            else // If it does exist, BadRequest
            {
                return BadRequest("A User with this name already exists!");
            }

            // Return the newly created user
            return CreatedAtAction(nameof(GetUserById), new { id = user.User_Id }, user);
        }

        //##############################################################################################################

        // Read: 
        [HttpGet("GetAllUsers")] // Get all users
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await userRepo.GetAllUsers();

            return Ok(allUsers);
        }

        [HttpGet("{id:int}")] // Get user by Id
        public async Task<IActionResult> GetUserById(int id)
        {
            var selectedUser = await userRepo.GetUserById(id);

            if (selectedUser == null)
            {
                return NotFound();
            }

            return Ok(selectedUser);
        }

        [HttpGet("GetUserByUserName")] // Get user by UserName
        public async Task<IActionResult> GetUserByUserName(string userName, string password)
        {
            var selectedUser = await userRepo.GetUserByUserName(userName, password);

            if (selectedUser == null)
            {
                return NotFound();
            }

            return Ok(selectedUser);
        }

        //##############################################################################################################

        // Update: 
        [HttpPatch("{id:int}")] // Update user by Id
        public async Task<IActionResult> UpdateUserById(int id, [FromBody] User updatedUserData)
        {
            if (updatedUserData == null)
            {
                return BadRequest("Invalid user data.");
            }

            var selectedUser = await userRepo.UpdateUserById(id, updatedUserData);

            if (selectedUser == null)
            {
                return NotFound();
            }

            return Ok(selectedUser);
        }

        [HttpPatch("UpdateUserByUserName")] // Update user by UserName
        public async Task<IActionResult> UpdateUserByUserName(string userName, [FromBody] User updatedUserData)
        {
            if (updatedUserData == null)
            {
                return BadRequest("Invalid user data.");
            }

            var selectedUser = await userRepo.UpdateUserByUserName(userName, updatedUserData);

            if (selectedUser == null)
            {
                return NotFound();
            }

            return Ok(selectedUser);
        }

        //##############################################################################################################

        // Delete:
        [HttpDelete("{id:int}")] // Delete user by Id (Admin Only)
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var selectedUser = await userRepo.DeleteUserById(id);

            if (selectedUser == null)
            {
                return NotFound();
            }

            return Ok(selectedUser);
        }

        [HttpDelete("DeleteUserByUserName")] // Delete user by UserName (Admin Only)
        public async Task<IActionResult> DeleteUserByUserName(string userName)
        {
            var selectedUser = await userRepo.DeleteUserByUserName(userName);

            if (selectedUser == null)
            {
                return NotFound();
            }

            return Ok(selectedUser);
        }
    }
}
