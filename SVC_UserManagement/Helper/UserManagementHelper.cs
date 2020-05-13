using log4net;
using log4net.Config;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using SHR_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private readonly IUserRepository _iUserRepository;
		public UserManagementHelper(IUserRepository iUserRepository)
		{
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
			_iUserRepository = iUserRepository;
		}
		/// <summary>
		/// Add a new user to List
		/// </summary>
		/// <param name="userDetails"></param>
		/// <returns></returns>
		public async Task<bool> RegisterUser(UserDetails userDetails)
		{
			log.Info("In UserManagementHelper :   RegisterUser(UserDetails userDetails)");
			try
			{
				//Input for this is userDetails if valid then registration will be successfull else thrwos an exception
				bool userId = await _iUserRepository.RegisterUser(userDetails);
				return userId;
			}
			catch(Exception e)
			{
				log.Error("Exception UserManagementHelper:  RegisterUser(UserDetails userDetails)" + e.Message);
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
			log.Info("In UserManagementHelper :  GetUser(int userId)");
			try
			{
				//Input for this method is userId if valid userId then returns userDetails else throws exception
				UserDetails userDetails = await _iUserRepository.GetUser(userId);
				if (userDetails != null)
				{
					return userDetails;
				}
				else
					return null;
			}
			catch(Exception e)
			{
				log.Error("Exception UserManagementHelper:GetUser(int userId)" + e.Message);
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
			//Input is userName and userPassword
			return  await _iUserRepository.UserLogin(userLogin);
		}
		/// <summary>
		/// Update the Exsisting user
		/// </summary>
		/// <param name="userDetails"></param>
		/// <returns></returns>
		public async Task<bool> UpdateUser(UserDetails userDetails)
		{
			log.Info("In UserManagementHelper :  UpdateUser(UserDetails userDetails)");
			try
			{
				//Input for this update method is userDetails if passed values are correct it will update else it throws an exception
				bool userId = await _iUserRepository.UpdateUser(userDetails);
				return userId;	
				//if (userId == true)
				//	return 1;
				//else
				//	return 0;
			}
			catch(Exception e)
			{
				log.Error("Exception UserManagementHelper: UpdateUser(UserDetails userDetails)" + e.Message);
				throw;
			}
		}
		/// <summary>
		/// Get All Users in a list
		/// </summary>
		/// <returns></returns>
		public async Task<List<UserDetails>> GetAllUsers()
		{
			log.Info("In UserManagementHelper :   GetAllUsers()");
			try
			{
				//Returns Users list present in the database else if nothing exists it will returns exception
				List<UserDetails> userDetails = await _iUserRepository.GetAllUsers();
				return userDetails;	
			}
			catch(Exception e)
			{
				log.Error("Exception UserManagementHelper: GetAllUsers()" + e.Message);
				throw;
			}
		}
	}
}
