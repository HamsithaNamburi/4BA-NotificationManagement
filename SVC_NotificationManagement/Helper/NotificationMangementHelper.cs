using NotificationManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationManagement.Helper
{
	public interface INotificationManagementHelper
	{
		Task<List<Notification>> GetAllNotifications(int userId);
		Task<bool> AddNotification(Notification notifications);
		Task<bool> UpdateNotification(Notification notifications);
		Task<bool> DeleteNotification(int notificationId);
	}
	public class NotificationMangementHelper : INotificationManagementHelper
	{
		private readonly INotificationManagementHelper _iNotificationManagementHelper;
		public NotificationMangementHelper(INotificationManagementHelper inotificationManagementHelper)
		{
			_iNotificationManagementHelper = inotificationManagementHelper;
		}
		public async Task<bool> AddNotification(Notification notifications)
		{
			try
			{
				bool notification = await _iNotificationManagementHelper.AddNotification(notifications);
				return notification;
			}
			catch
			{
				throw;
			}
		}

		public async Task<bool> DeleteNotification(int notificationId)
		{
			try
			{
				bool notification = await _iNotificationManagementHelper.DeleteNotification(notificationId);
				return notification;
			}
			catch
			{
				throw;
			}
		}
		public async Task<List<Notification>> GetAllNotifications(int userId)
		{
			try
			{
				List<Notification> notifications = await _iNotificationManagementHelper.GetAllNotifications(userId);
				if (notifications != null)
				{
					return notifications;
				}
				else
					return null;
			}
			catch
			{
				throw;
			}
		}
		public async Task<bool> UpdateNotification(Notification notifications)
		{
			try
			{
				bool notification = await _iNotificationManagementHelper.UpdateNotification(notifications);
				return notification;
			}
			catch
			{
				throw;
			}
		}
	}
}
