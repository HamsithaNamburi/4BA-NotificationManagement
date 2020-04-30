using NotificationManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationManagementDBEntity.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace UserManagement.Helper
{
    public class UserRepository : IUserRepository
    {
        private readonly NotificationDbContext _notificationDBContext;
        public UserRepository(NotificationDbContext notificationDBContext)
        {
            _notificationDBContext = notificationDBContext;
        }
        public async Task<UserDetails> GetUser(int userId)
        {
            try
            {
                UserDetails userDetails = await _notificationDBContext.UserDetails.FindAsync(userId);
                if (userDetails == null)
                    return null;
                else
                    return userDetails;
            }
            catch
            {
                throw;
            }
        }
        public async Task<UserDetails> Login(string userName, string userPassword)
        {
            try
            {
                UserDetails userDetails = _notificationDBContext.UserDetails.SingleOrDefault(i => i.UserName == userName && i.UserPassword == userPassword);
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
        public async Task<bool> RegisterUser(UserDetails userDetails)
        {
            try
            {
                _notificationDBContext.UserDetails.Add(userDetails);
                var userId = await _notificationDBContext.SaveChangesAsync();
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
        public async Task<bool> UpdateUser(UserDetails userDetails)
        {
            try
            {
                _notificationDBContext.UserDetails.Update(userDetails);
                var user = await _notificationDBContext.SaveChangesAsync();
                if (user > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
