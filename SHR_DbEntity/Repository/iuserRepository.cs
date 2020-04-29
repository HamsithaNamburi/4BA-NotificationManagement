using NotificationManagemntDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationManagemntDBEntity.Repository
{
  public interface iuserRepository
    {
        Task<UserDetails> UserLogin(string username, string password);

        Task<bool> UserRegister(UserDetails userdetails);
        Task<UserDetails> GetUser(string userid);
        Task<bool> UpdateUser(UserDetails userdetails);
    }
}
