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
		Task<List<Notifications>> GetAllNotifications(int userId);
		Task<bool> AddNotification(Notifications notifications);
		Task<bool> UpdateNotification(Notifications notifications);
		Task<bool> DeleteNotification(int notificationId);
	}
	public class NotificationMangementHelper : INotificationManagementHelper
	{
		private readonly INotificationRepository _iNotificationRepository;
		public NotificationMangementHelper(INotificationRepository inotificationRepository)
		{
			_iNotificationRepository = inotificationRepository;
		}
		public async Task<bool> AddNotification(Notifications notifications)
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
		public async Task<List<Notifications>> GetAllNotifications(int userId)
		{
			try
			{
				List<Notifications> notifications = await _iNotificationRepository.GetAllNotifications(userId);
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
		public async Task<bool> UpdateNotification(Notifications notifications)
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
