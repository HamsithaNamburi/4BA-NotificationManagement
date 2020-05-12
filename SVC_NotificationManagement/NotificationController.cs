using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationManagement.Helper;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationManagement
{
	[Route("api/v1")]
	[ApiController]
	public class NotificationController : Controller
	{
        private readonly INotificationManagementHelper _inotificationManagementHelper;
        public NotificationController(INotificationManagementHelper iNotificationManagementHelper)
        {
            _inotificationManagementHelper = iNotificationManagementHelper;
        }
        /// <summary>
        /// Find the notification based on notificationId
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNotification/{notificationId}")]
        public async Task<IActionResult> GetNotification(int notificationId)
        {
            try
            {
                return Ok(await _inotificationManagementHelper.GetNotification(notificationId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// To get all the notifications
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllNotifications/{userId}")]
        public async Task<IActionResult> GetAllNotifications(int userId)
        {
            try
            {
                return Ok(await _inotificationManagementHelper.GetAllNotifications(userId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// to add a notification using post method
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNotification")]
        public async Task<IActionResult> AddNotification(Notifications notifications)
        {
            try
            {
                await _inotificationManagementHelper.AddNotification(notifications);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        /// <summary>
        /// To update a notification using Put method
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateNotification")]
        public async Task<IActionResult> UpdateNotification(Notifications notifications)
        {
            try
            {
              return Ok( await _inotificationManagementHelper.UpdateNotification(notifications));
                
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// to delete a notification using Delete method
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteNotification/{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            try
            {
                await _inotificationManagementHelper.DeleteNotification(notificationId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}