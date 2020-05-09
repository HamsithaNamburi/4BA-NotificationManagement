using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using SHR_Model;
using UserManagement.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement
{
	[Route("api/v1")]
    [ApiController]
	public class UserController : Controller
	{
        
        private readonly IUserManagementHelper _iUserManagementHelper;
        //private readonly ILogger<UserController> _logger;
        public UserController(IUserManagementHelper iUserManagementHelper)
        {
            _iUserManagementHelper = iUserManagementHelper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetUser/{userId}")]

        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                return Ok(await _iUserManagementHelper.GetUser(userId));
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _iUserManagementHelper.GetAllUsers());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDetails1"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public async Task<IActionResult> UserLogin(Login userLogin)
        {
            try
            {
                UserDetails userDetails= await _iUserManagementHelper.UserLogin(userLogin);
                //_logger.LogInformation("Login was called..");
                if (userDetails == null)
                    return Ok("Invalid User");
                else
                {
                    return Ok(userDetails);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserDetails userDetails)
        {
            try
            {
                await _iUserManagementHelper.RegisterUser(userDetails);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDetails userDetails)
        {
            try
            {
                await _iUserManagementHelper.UpdateUser(userDetails);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
