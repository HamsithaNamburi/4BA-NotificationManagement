﻿using NotificationManagementDBEntity.Repositories;
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
        /// To view the existing user based on userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDetails> GetUser(int userId)
        {
            try
            {
                //Returns an userDetails if the entered userId exists else throws an exception
                return await _notificationDBContext.UserDetails.FindAsync(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To authenticate the user 
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public async Task<UserDetails> UserLogin(Login userLogin)
        {
            try
            {
                //Returns the userDetails if the entered credentials are valid else it throws an exception
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
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// To Add/ Register a new user 
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public async Task<bool> RegisterUser(UserDetails userDetails)
        {
            try
            {
                //Returns true if the passed userDetails are inserted else returns error 
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
        /// To update  the existing user 
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(UserDetails userDetails)
        {
            UserDetails userDetails1 = userDetails;
            userDetails1.UpdatedDate = DateTime.Now;
            try
            {
                //Returns the boolean value if the userDetails are updated else throws an exception
                _notificationDBContext.UserDetails.Update(userDetails1);
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
        /// To view all the users 
        /// </summary>
        /// <returns></returns>

        public async Task<List<UserDetails>> GetAllUsers()
        {
            try
            {
                //Returns the list of Users exists in the database
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