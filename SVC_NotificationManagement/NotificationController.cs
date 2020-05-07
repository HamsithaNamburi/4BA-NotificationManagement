using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationManagement
{
	[Route("api/v1")]
	[ApiController]
	public class NotificationController : Controller
	{
        private readonly INotificationRepository _notificationRepository;
        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllNotifications/{UserId}")]
        public async Task<IActionResult> GetAllNotifications(int userId)
        {
            try
            {
                return Ok(await _notificationRepository.GetAllNotifications(userId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNotification")]
        public async Task<IActionResult> AddNotification(Notifications notifications)
        {
            try
            {
                await _notificationRepository.AddNotification(notifications);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateNotification")]
        public async Task<IActionResult> UpdateNotification(Notifications notifications)
        {
            try
            {
               await _notificationRepository.UpdateNotification(notifications);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteNotification/{NotificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            try
            {
                await _notificationRepository.DeleteNotification(notificationId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
