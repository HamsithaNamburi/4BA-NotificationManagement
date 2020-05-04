using System.Threading.Tasks;
using NotificationManagementDBEntity.Models;
using SHR_Model;

namespace NotificationManagementDBEntity.Repositories
{
	public interface IUserRepository
	{
		Task<bool> RegisterUser(UserDetails userDetails);
		Task<bool> UpdateUser(UserDetails userDetails);
		Task<UserDetails> UserLogin(Login userLogin);
		Task<UserDetails> GetUser(int userId);
	}
}
