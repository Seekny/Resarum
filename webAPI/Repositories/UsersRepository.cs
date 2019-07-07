using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Repositories
{
    public class UserRepository
    {
        private readonly DbAppContext _context;

        public UserRepository(DbAppContext context)
        {
            _context = context;
          
        }

        //get user from ldap authentification
        public string GetUserNameFromLdap()
        {
            //PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            //UserPrincipal user = UserPrincipal.Current;
            //string displayName = user.DisplayName;

            string Name = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
            string igo = System.Environment.UserName;
            string qlf = Environment.GetEnvironmentVariable("USERNAME");

            string Taric = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            // find current user
            UserPrincipal user = UserPrincipal.Current;

            if (user != null)
            {
                string loginName = user.SamAccountName; // or whatever you mean by "login name"
            }
            return Name;
        }

        //Verify User exist in database from username
        public async Task<bool> VerifyUserNameExist(string username)
        {
           var user =  await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
           
            if( user == null)
            {
                return false;
            }
            else
            {
                return true;
            }             
        }

        // Add new User
        public async Task AddUserAsync(string username)
        {
            User user = new User();
            user.UserName = username;
            await _context.AddAsync(user);            
            await _context.SaveChangesAsync();
        }
        
        // Get User Id from username
        public async Task<User> GetUserID(string username) {
            
            var UserID = await _context.Users.Where(u => u.UserName == username).SingleOrDefaultAsync();
            return UserID;
        }

        // Get All Users
        public async Task<List<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
