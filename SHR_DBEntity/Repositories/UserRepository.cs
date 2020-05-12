using NotificationManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationManagementDBEntity.Models;
using Microsoft.EntityFrameworkCore.Storage;
using SHR_Model;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Helper
{
    public class UserRepository : IUserRepository
    {
        private readonly NotificationDBContext _notificationDBContext;
        public UserRepository(NotificationDBContext notificationDBContext)
        {
            _notificationDBContext = notificationDBContext;
        }
        /// <summary>
        /// Get the User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDetails> GetUser(int userId)
        {
            try
            {
                //UserDetails userDetails = await _notificationDBContext.UserDetails.FindAsync(userId);
                //if (userDetails == null)
                //    return null;
                //else
                    return await _notificationDBContext.UserDetails.FindAsync(userId);
            }
            catch(Exception )
            {
                throw;
            }
        }
        /// <summary>
        /// Login in to the page with username and password
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public async Task<UserDetails> UserLogin(Login userLogin)
        {
            try
            {
                UserDetails userDetails = _notificationDBContext.UserDetails.SingleOrDefault(i => i.UserName == userLogin.userName && i.UserPassword == userLogin.userPassword);
                if (userDetails == null)
                {
                    return null;
                }
                else
                {
                    return userDetails;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public async Task<bool> RegisterUser(UserDetails userDetails)
        {
            try
            {
                _notificationDBContext.UserDetails.Add(userDetails);
               var userId = await _notificationDBContext.SaveChangesAsync();
                await _notificationDBContext.SaveChangesAsync();
                if (userId > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                // To Do Log
                throw;
            }
        }
        /// <summary>
        /// Upadte the Exsisting
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(UserDetails userDetails)
        {
            try
            {
                _notificationDBContext.UserDetails.Update(userDetails);
                var productId = await _notificationDBContext.SaveChangesAsync();
                if (productId > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                // To Do Log
                throw;
            }
        }
        /// <summary>
        /// Get all users in a list
        /// </summary>
        /// <returns></returns>

        public async Task<List<UserDetails>> GetAllUsers()
        {
            try
            {
                List<UserDetails> userDetails = await _notificationDBContext.UserDetails.ToListAsync();
               await _notificationDBContext.SaveChangesAsync();
                return userDetails;
            }
            catch
            {
                throw;
            }
        }
    }
}
