using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NotificationManagementDBEntity.Models;

namespace NotificationManagementDBEntity.Repositories
{
	public interface IUserRepository
	{
		Task<bool> RegisterUser(UserDetails userDetails);
		Task<bool> UpdateUser(UserDetails userDetails);
		Task<UserDetails> Login(string userName, string userPassword);
		Task<UserDetails> GetUser(int userId);
	}
}
