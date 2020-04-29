using Microsoft.EntityFrameworkCore;
using NotificationManagemntDBEntity.Models;
using NotificationManagemntDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userManagement.Repository
{
    public class userRepository:iuserRepository
    {
        private readonly NotificationDBContext _notificationDbcontext;
        public userRepository(NotificationDBContext notificationDbcontext)
        {
            _notificationDbcontext = notificationDbcontext;
        }
        /// <summary>
        /// TO
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public async Task<UserDetails> GetUser(string Userid)
        {
            try
            {
                var userid = await _notificationDbcontext.UserDetails.FindAsync(Userid);
                if (userid != null)
                {
                    return userid;
                } else
                    return null;
            }catch(Exception e)
            {
                throw;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

        public async Task<bool> UpdateUser(UserDetails userdetails)
        {
            try
            {

                _notificationDbcontext.UserDetails.Update(userdetails);
                var id =await _notificationDbcontext.SaveChangesAsync();
                if (id > 0)
                {
                    return true;
                } else
                    return false;
            }catch(Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<UserDetails> UserLogin(string username, string password)
        {
            try
            {
                UserDetails u = await _notificationDbcontext.UserDetails.SingleOrDefaultAsync(e => e.UserName == username && e.UserPassword== password);
                // UserDetails u = await _notificationDbcontext.UserDetails.SingleOrDefault(e => e.Username == Username && e.Password == Password);
                return u;
            }catch(Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<bool> UserRegister(UserDetails userdetails)
        {
            try
            {

                _notificationDbcontext.Add(userdetails);
                var userid = await _notificationDbcontext.SaveChangesAsync();
                if (userid > 0)
                {
                    return true;
                } else
                    return false;
            }catch(Exception e)
            {
                throw;
            }
        }
    }
}
