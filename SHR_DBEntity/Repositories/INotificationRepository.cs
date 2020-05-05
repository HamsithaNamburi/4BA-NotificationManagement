using NotificationManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationManagementDBEntity.Repositories
{
	public interface INotificationRepository
	{
		Task<List<Notification>> GetAllNotifications(int userId);
		Task<bool> AddNotification(Notification notifications);
		Task<bool> UpdateNotification(Notification notifications);
		Task<bool> DeleteNotification(int notificationId);
	}
}
