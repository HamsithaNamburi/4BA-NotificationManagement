﻿using Microsoft.EntityFrameworkCore;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationManagement
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDBContext _notificationDBContext;
        public NotificationRepository(NotificationDBContext notificationDBContext)
        {
            _notificationDBContext = notificationDBContext;
        }
        /// <summary>
        /// To view the notification based on notificationId
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public async Task<Notifications> GetNotification(int notificationId)
        {
            try
            {
                //Returns a notification if the entered notificationId exists if not it will throws exception
                return await _notificationDBContext.Notifications.FindAsync(notificationId);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        /// <summary>
        /// To add new  notification
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        public async Task<bool> AddNotification(Notifications notifications)
        {
            try
            {
                //Returns the bool value if the notification added , or else if the passed object is wrong then it will throws an exception
                _notificationDBContext.Notifications.Add(notifications);
                var notification = await _notificationDBContext.SaveChangesAsync();
                await _notificationDBContext.SaveChangesAsync();

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
        /// <summary>
        /// To delete a notification based on notificationId
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteNotification(int notificationId)
        {

            try
            {
                //Delete a notification if the entered notificationId exists else throws an exception
                Notifications notifications = _notificationDBContext.Notifications.Find(notificationId);
                _notificationDBContext.Notifications.Remove(notifications);
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
        /// <summary>
        /// To view  list of notifications based on UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Notifications>> GetAllNotifications(int userId)
        {
            try
            {

                //Returns all notifications which exists on the entered userId, else if entered the invalid userId throws an exception 
                List<Notifications> userDetails = await _notificationDBContext.Notifications.Where(i => i.UserId == userId).ToListAsync();
                await _notificationDBContext.SaveChangesAsync();
                return userDetails;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// To Update Notification
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNotification(Notifications notifications)
        {
            Notifications notifications1 = notifications;
            notifications1.UpdatedDate = DateTime.Now;
            try
            {
                //Returns true if notification is updated else it throws an exception
                _notificationDBContext.Notifications.Update(notifications1);
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