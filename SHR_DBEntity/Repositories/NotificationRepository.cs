using Microsoft.EntityFrameworkCore;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationManagement
{
	public class NotificationRepository:INotificationRepository
	{
        private readonly NotificationDBContext _notificationDBContext;
        public NotificationRepository(NotificationDBContext notificationDBContext)
        {
            _notificationDBContext = notificationDBContext;
        }
        public async Task<bool> AddNotification(Notification notifications)
        {
            try
            {
                _notificationDBContext.Notification.Add(notifications);
                var notification = await _notificationDBContext.SaveChangesAsync();
                if (notification > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                // To Do Log
                throw;
            }
        }

        public async Task<bool> DeleteNotification(int notificationId)
        {
            Notification notifications = _notificationDBContext.Notification.Find(notificationId);
            try
            {
                _notificationDBContext.Notification.Remove(notifications);
                var notification = await _notificationDBContext.SaveChangesAsync();
                if (notification > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async  Task<List<Notification>> GetAllNotifications(int userId)
        {
            try
            {
                return await _notificationDBContext.Notification.Where(i => i.UserId == userId).ToListAsync();
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
                _notificationDBContext.Notification.Update(notifications);
                var notification = await _notificationDBContext.SaveChangesAsync();
                if (notification > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
