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
        private readonly NotificationDbContext _notificationDBContext;
        public NotificationRepository(NotificationDbContext notificationDBContext)
        {
            _notificationDBContext = notificationDBContext;
        }
        public void AddNotification(Notifications notifications)
        {
            _notificationDBContext.Notifications.Add(notifications);
            _notificationDBContext.SaveChanges();
        }

        public void DeleteNotification(string notificationId)
        {
            Notifications notifications = _notificationDBContext.Notifications.Find(notificationId);
            _notificationDBContext.Notifications.Remove(notifications);
            _notificationDBContext.SaveChanges();
        }

        public List<Notifications> GetAllNotifications(string userId)
        {
            return _notificationDBContext.Notifications.Where(i => i.Id == userId).ToList();
        }

        public void UpdateNotification(Notifications notifications)
        {
            _notificationDBContext.Notifications.Update(notifications);
            _notificationDBContext.SaveChanges();
        }
    }
}
