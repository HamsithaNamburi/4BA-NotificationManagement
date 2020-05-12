using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using SHR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Helper
{
	public interface IUserManagementHelper
	{
		Task<bool> RegisterUser(UserDetails userDetails);
		Task<bool> UpdateUser(UserDetails userDetails);
		Task<UserDetails> UserLogin(Login userLogin);
		Task<UserDetails> GetUser(int userId);
		Task<List<UserDetails>> GetAllUsers();
	}
	public class UserManagementHelper : IUserManagementHelper
	{
		private readonly IUserRepository _iUserRepository;
		public UserManagementHelper(IUserRepository iUserRepository)
		{
			_iUserRepository = iUserRepository;
		}
		/// <summary>
		/// Add a new user to List
		/// </summary>
		/// <param name="userDetails"></param>
		/// <returns></returns>
		public async Task<bool> RegisterUser(UserDetails userDetails)
		{
			try
			{
				bool userId = await _iUserRepository.RegisterUser(userDetails);
				return userId;
			}
			catch
			{
				throw;
			}
		}
		/// <summary>
		/// Get the User by Id
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public async Task<UserDetails> GetUser(int userId)
		{
			try
			{
				UserDetails userDetails = await _iUserRepository.GetUser(userId);
				if (userDetails != null)
				{
					return userDetails;
				}
				else
					return null;
			}
			catch
			{
				throw;
			}
		}
		/// <summary>
		/// Login with credentials
		/// </summary>
		/// <param name="userLogin"></param>
		/// <returns></returns>
		public async Task<UserDetails> UserLogin(Login userLogin)
		{
			return  await _iUserRepository.UserLogin(userLogin);
		}
		/// <summary>
		/// Update the Exsisting user
		/// </summary>
		/// <param name="userDetails"></param>
		/// <returns></returns>
		public async Task<bool> UpdateUser(UserDetails userDetails)
		{
			try
			{
				bool userId = await _iUserRepository.UpdateUser(userDetails);
				return userId;	
				//if (userId == true)
				//	return 1;
				//else
				//	return 0;
			}
			catch
			{
				throw;
			}
		}
		/// <summary>
		/// Get All Users in a list
		/// </summary>
		/// <returns></returns>
		public async Task<List<UserDetails>> GetAllUsers()
		{
			try
			{
				List<UserDetails> userDetails = await _iUserRepository.GetAllUsers();
				return userDetails;	
			}
			catch
			{
				throw;
			}
		}
	}
}
