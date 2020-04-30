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
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : Controller
	{
        private readonly INotificationRepository _notificationRepository;
        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        [HttpGet]
        [Route("GetAllNotifications/{id}")]
        public IActionResult GetAllNotifications(string id)
        {
            try
            {
                return Ok(_notificationRepository.GetAllNotifications(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddNotification")]
        public IActionResult AddNotification(Notifications notifications)
        {
            try
            {
                _notificationRepository.AddNotification(notifications);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateNotification")]
        public IActionResult UpdateNotification(Notifications notifications)
        {
            try
            {
                _notificationRepository.UpdateNotification(notifications);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteNotification/{notificationid}")]
        public IActionResult DeleteNotification(string notificationId)
        {
            try
            {
                _notificationRepository.DeleteNotification(notificationId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
