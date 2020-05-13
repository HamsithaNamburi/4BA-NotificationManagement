using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
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
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly INotificationManagementHelper _inotificationManagementHelper;
        public NotificationController(INotificationManagementHelper iNotificationManagementHelper)
        {
            _inotificationManagementHelper = iNotificationManagementHelper;
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        /// <summary>
        /// Find the notification based on notificationId
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet]
        [Route("GetNotification/{notificationId}")]

        [ProducesResponseType(200, Type = typeof(Notifications))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetNotification(int notificationId)
        {
            log.Info("In NotificationController :  GetNotification(int notificationId)");
            try
            {
                //Returns a notification if the entered notificationId exists if not it will throws exception
                return Ok(await _inotificationManagementHelper.GetNotification(notificationId));
            }
            catch (Exception ex)
            {
                log.Error("Exception NotificationController :  GetNotification(int notificationId)" + ex.Message);
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// To get all the notifications
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet]
        [Route("GetAllNotifications/{userId}")]
        [ProducesResponseType(200, Type = typeof(Notifications))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetAllNotifications(int userId)
        {
            log.Info("In NotificationController :   GetAllNotifications(int userId)");
            try
            {
                //Returns all notifications which exists on the entered userId, else if entered the invalid userId throws an exception 
                return Ok(await _inotificationManagementHelper.GetAllNotifications(userId));
            }
            catch (Exception ex)
            {
                log.Error("Exception NotificationController : GetAllNotifications(int userId)" + ex.Message);
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// to add a notification using post method
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpPost]
        [Route("AddNotification")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> AddNotification(Notifications notifications)
        {
            log.Info("In NotificationController :   AddNotification(Notifications notifications)");
            try
            {
                //Returns the bool value if the notification added , or else if the passed object is wrong then it will throws an exception
                await _inotificationManagementHelper.AddNotification(notifications);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error("Exception NotificationController :  AddNotification(Notifications notifications)" + ex.Message);
                return NotFound(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// To update a notification using Put method
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpPut]
        [Route("UpdateNotification")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> UpdateNotification(Notifications notifications)
        {
            log.Info("In NotificationController :   UpdateNotification(Notifications notifications)");
            try
            {
                //Returns true if notification is updated else it throws an exception
                return Ok( await _inotificationManagementHelper.UpdateNotification(notifications));
                
            }
            catch (Exception ex)
            {
                log.Error("Exception NotificationController : UpdateNotification(Notifications notifications)" + ex.Message);
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// to delete a notification using Delete method
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpDelete]
        [Route("DeleteNotification/{notificationId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            log.Info("In NotificationController :  DeleteNotification(int notificationId)");
            try
            {
                //Delete a notification if the entered notificationId exists else throws an exception
                await _inotificationManagementHelper.DeleteNotification(notificationId);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error("Exception NotificationController :  DeleteNotification(int notificationId)" + ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}