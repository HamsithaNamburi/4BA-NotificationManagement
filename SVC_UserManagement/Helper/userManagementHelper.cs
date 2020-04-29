using NotificationManagemntDBEntity.Models;
using NotificationManagemntDBEntity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userManagement.Helper
{
    public interface iuserManagement
    {
        Task<UserDetails> UserLogin(string username, string password);

        Task<int> UserRegister(UserDetails userdetails);
        Task<UserDetails> GetUser(string userid);
        Task<bool> UpdateUser(UserDetails userdetails);
    }
    public class userManagementHelper : iuserManagement
    {
        private readonly iuserRepository _iuserRepository;
        public userManagementHelper(iuserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;

        }
        public  async Task<UserDetails> GetUser(string Userid)
        {
                try
                {
                UserDetails u = await _iuserRepository.GetUser(Userid);
                    if (u != null)
                    {
                        return u;
                    }
                    else
                        return null;
                }
                catch (Exception e)
                {
                    throw;
                }

            
        }

        public async Task<bool> UpdateUser(UserDetails userdetails)
        {
            try
            {
                bool userid = await _iuserRepository.UpdateUser(userdetails);
                if (userid == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<UserDetails> UserLogin(string username, string password)
        {
            try
            {
                UserDetails u = await _iuserRepository.UserLogin(username, password);
                if (u != null)
                {
                    return u;
                }
                else
                    return null;
            }catch(Exception e)
            {
                throw;
            }



        }

        public async Task<int> UserRegister(UserDetails userdetails)
        {
            try
            {
                bool userid = await _iuserRepository.UserRegister(userdetails);
                if (userid == true)
                {
                    return 1;
                } else
                    return 0;
            }catch(Exception e)
            {
                throw;
            }
        }
    }
}
