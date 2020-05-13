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
        /// Find a User by  userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet]
        [Route("GetUser/{userId}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                //Input for this method is userId which is of integer datatatype
                //Returns UserDetails if the entered userId is valid else it returns exception message 
                return Ok(await _iUserManagementHelper.GetUser(userId));
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Get all Users in a List
        /// </summary>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpGet]
        [Route("GetAllUsers")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                //Returns Users list present in the database else if nothing exists it will returns exception
                return Ok(await _iUserManagementHelper.GetAllUsers());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpPost]
        [Route("UserLogin")]
        [ProducesResponseType(200, Type = typeof(UserDetails))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> UserLogin(Login userLogin)
        {
            try
            {
                //Input is userName and userPassword 
                //Returns  respected userDetails if the entered credentials are valid else it throws an exception message 
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
                return NotFound(ex.InnerException.Message);
            }
        }
        /// <summary>
        /// Add a new User to a List.
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [Route("RegisterUser")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> RegisterUser(UserDetails userDetails)
        {
            try
            {
                //Input for this Register i userDetails if passed values are correct the user registration is successfull else it throws an exception
                await _iUserManagementHelper.RegisterUser(userDetails);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }
        /// <summary>
        /// Update a new user to a List 
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        /// /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request/Request Invalid </response>
        /// <response code="404">Requested Resouce  not found</response>
        /// <response code="500">Internal server Error</response>
        [HttpPut]
        [Route("UpdateUser")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> UpdateUser(UserDetails userDetails)
        {
            try
            {
                //Input for this update method is userDetails if passed values are correct it will update else it throws an exception
                await _iUserManagementHelper.UpdateUser(userDetails);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
    }
}
