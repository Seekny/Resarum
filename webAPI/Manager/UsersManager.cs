using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;
using webAPI.Repositories;

namespace webAPI.Manager
{
    public class UsersManager
    {
        private readonly UserRepository _usersRepository;

        public UsersManager(UserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        // Get All
        public async Task<List<User>> GetUsers()
        {
            return await _usersRepository.GetAllUser();
        }

        // Get By ID
        public async Task<User> GetUserIDAsync(string username)
        {
            return await _usersRepository.GetUserID(username);
        }

        // Add user
        public async Task<bool> AddUser(string username)
        {
            await _usersRepository.AddUserAsync(username);

            return true;
        }

        // Verify User Exist 
        public async Task<bool> VerifyUsername(string username)
        {
            return await _usersRepository.VerifyUserNameExist(username);
        }

        //get username
        public string GetUsername()
        {
            return _usersRepository.GetUserNameFromLdap();
        }
    }
}
