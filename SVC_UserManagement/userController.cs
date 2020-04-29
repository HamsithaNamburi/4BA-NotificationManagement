using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationManagemntDBEntity.Models;
using NotificationManagemntDBEntity.Repository;
using userManagement.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace userManagement
{
    [Route("api/v1")]
    [ApiController]
    public class userController : Controller
    {
        // GET: api/<controller>
             private readonly iuserManagement _iuserManagement;
        public userController(iuserManagement iuserManagement)
        {
            _iuserManagement = iuserManagement;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin/{username}/{password}")]
        public async Task<IActionResult> UserLogin(string username, string password)
        {
            try
            {
                UserDetails u =await _iuserManagement.UserLogin(username,password);
                if (u == null)
                {
                    return Ok("invalid User");
                }
                else
                    return Ok(u);

            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserRegister")]
        public async Task<IActionResult> UserRegister(UserDetails userdetails)
        {
            try
            {
               await _iuserManagement.UserRegister(userdetails);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUser/{userid}")]
        public async Task<IActionResult> GetUser(string userid)
        {
            try
            {
                return Ok(await _iuserManagement.GetUser(userid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDetails userdetails)
        {
            try
            {
                await _iuserManagement.UpdateUser(userdetails);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
