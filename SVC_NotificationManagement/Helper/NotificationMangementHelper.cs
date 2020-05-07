using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
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
		private readonly INotificationRepository _iNotificationRepository;
		public NotificationMangementHelper(INotificationRepository inotificationRepository)
		{
			_iNotificationRepository = inotificationRepository;
		}
		public async Task<bool> AddNotification(Notification notifications)
		{
			try
			{
				bool notification = await _iNotificationRepository.AddNotification(notifications);
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
				bool notification = await _iNotificationRepository.DeleteNotification(notificationId);
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
				List<Notification> notifications = await _iNotificationRepository.GetAllNotifications(userId);
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
				bool notification = await _iNotificationRepository.UpdateNotification(notifications);
				return notification;
			}
			catch
			{
				throw;
			}
		}
	}
}
