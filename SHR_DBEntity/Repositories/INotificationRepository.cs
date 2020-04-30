using NotificationManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationManagementDBEntity.Repositories
{
	public interface INotificationRepository
	{
		public List<Notifications> GetAllNotifications(string userId);
		public void AddNotification(Notifications notifications);
		public void UpdateNotification(Notifications notifications);
		public void DeleteNotification(string notificationId);
	}
}
