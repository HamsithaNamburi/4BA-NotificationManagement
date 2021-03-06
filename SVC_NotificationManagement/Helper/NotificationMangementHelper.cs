﻿using log4net;
using log4net.Config;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace NotificationManagement.Helper
{
	public interface INotificationManagementHelper
	{
		Task<List<Notifications>> GetAllNotifications(int userId);
		Task<bool> AddNotification(Notifications notifications);
		Task<bool> UpdateNotification(Notifications notifications);
		Task<bool> DeleteNotification(int notificationId);
		Task<Notifications> GetNotification(int notificationId);
	}
	public class NotificationMangementHelper : INotificationManagementHelper
	{
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		private readonly INotificationRepository _iNotificationRepository;
		public NotificationMangementHelper(INotificationRepository inotificationRepository)
		{

			_iNotificationRepository = inotificationRepository;
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
		}
		/// <summary>
		/// Get Notifications By Notification Id
		/// </summary>
		/// <param name="notificationId"></param>
		/// <returns></returns>
		public async Task<Notifications> GetNotification(int notificationId)
		{
			log.Info("In NotificationMangementHelper :    GetNotification(int notificationId)");
			try
			{
				//checking the notifications , if exists it will return list of notifications else it will return null
				Notifications notifications = await _iNotificationRepository.GetNotification(notificationId);
				if(notifications != null)
				{
					return notifications;
				}
				else
				{
					return null;
				}
			}
			catch(Exception ex)
			{
				log.Error("Exception NotificationMangementHelper:   GetNotification(int notificationId)" + ex.Message);
				throw;
			}
		}
		/// <summary>
		/// To add a notification
		/// </summary>
		/// <param name="notifications"></param>
		/// <returns></returns>
		public async Task<bool> AddNotification(Notifications notifications)
		{
			log.Info("In NotificationMangementHelper :   AddNotification(Notifications notifications)");
			try
			{
				//It will add the notification and returns bool value if added else throws an exception 
				bool notification = await _iNotificationRepository.AddNotification(notifications);
				return notification;
			}
			catch(Exception ex)
			{
				log.Error("Exception NotificationMangementHelper:  AddNotification(Notifications notifications)" + ex.Message);
				throw;
			}
		}
		/// <summary>
		/// to delete a notification
		/// </summary>
		/// <param name="notificationId"></param>
		/// <returns></returns>
		public async Task<bool> DeleteNotification(int notificationId)
		{
			log.Info("In NotificationMangementHelper :  DeleteNotification(int notificationId)");
			try
			{
				//It will delete the notification if the notificationId exists else throws an exception
				bool result = await _iNotificationRepository.DeleteNotification(notificationId);
				if (result == true)
					return true;
				else
					return false;
			}
			catch(Exception ex)
			{
				log.Error("Exception NotificationMangementHelper:  DeleteNotification(int notificationId)" + ex.Message);
				throw;
			}
		}
		/// <summary>
		/// To view all notifications
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public async Task<List<Notifications>> GetAllNotifications(int userId)
		{
			log.Info("In NotificationMangementHelper : GetAllNotifications(int userId)");
			try
			{
				//Returns all the notifications which exists on the particular UserId profile, 
				//If exists returns list of notifications else throws exception
				List<Notifications> notifications = await _iNotificationRepository.GetAllNotifications(userId);
				if (notifications != null)
				{
					return notifications;
				}
				else
					return null;
			}
			catch(Exception ex)
			{
				log.Error("Exception NotificationMangementHelper:  GetAllNotifications(int userId)" + ex.Message);
				throw;
				
			}
		}
		/// <summary>
		/// To update a notification
		/// </summary>
		/// <param name="notifications"></param>
		/// <returns></returns>
	
		public async Task<bool> UpdateNotification(Notifications notifications)
		{
			log.Info("In NotificationMangementHelper :  UpdateNotification(Notifications notifications)");
			try
			{
				//It will Update the existing notification and returns true if updates else throws an exception
				bool result = await _iNotificationRepository.UpdateNotification(notifications);
				if (result == true)
					return true;
				else
					return false;
			}
			catch(Exception ex)
			{
				log.Error("Exception NotificationMangementHelper:  UpdateNotification(Notifications notifications)" + ex.Message);
				throw;
			}
		}
	}
}