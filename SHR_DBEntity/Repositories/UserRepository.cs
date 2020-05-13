using NotificationManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationManagementDBEntity.Models;
using Microsoft.EntityFrameworkCore.Storage;
using SHR_Model;
using Microsoft.EntityFrameworkCore;
using log4net;
using System.Reflection;
using System.IO;
using log4net.Config;

namespace UserManagement.Helper
{
    public class UserRepository : IUserRepository
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly NotificationDBContext _notificationDBContext;
        public UserRepository(NotificationDBContext notificationDBContext)
        {
            _notificationDBContext = notificationDBContext;
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
        /// <summary>
        /// To view the existing user based on userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDetails> GetUser(int userId)
        {
            log.Info("In UserRepository :  GetUser(int userId)");
            try
            {
                //Returns an userDetails if the entered userId exists else throws an exception
               
                return await _notificationDBContext.UserDetails.FindAsync(userId);
            }
            catch (Exception e)
            {
                log.Error("Exception UserRepository: GetUser(int userId)" + e.Message);
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
            log.Info("In UserRepository :  UserLogin(Login userlogin)");
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
            catch (Exception e)
            {
                log.Error("Exception UserRepository: UserLogin(Login userlogin)" + e.Message);
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
            log.Info("In UserRepository :  UserRegister(UserDetails userDetails)");
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
                log.Error("Exception UserRepository: UserRegister(UserDetails userDetails)" + e.Message);
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
            log.Info("In UserRepository :  UpdateUser(UserDetails userDetails)");
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
                log.Error("Exception UserRepository:  UpdateUser(UserDetails userDetails)" + e.Message);
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
            log.Info("In UserRepository :   GetAllUsers()");
            try
            {

                //Returns the list of Users exists in the database
                
                List<UserDetails> userDetails = await _notificationDBContext.UserDetails.ToListAsync();
                await _notificationDBContext.SaveChangesAsync();
                return userDetails;
            }
            catch(Exception e)
            {
                log.Error("Exception UserRepository:  GetAllUsers()" + e.Message);
                throw;
            }
        }
    }
}