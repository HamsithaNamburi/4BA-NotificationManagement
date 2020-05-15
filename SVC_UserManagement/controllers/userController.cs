using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHR_Model;
using UserManagement.Athuentication_Demo;

namespace UserManagement.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly ICustomAuthenticationManager _customAuthenticationManager;

        public userController(ICustomAuthenticationManager customAuthenticationManager)

        {

            _customAuthenticationManager = customAuthenticationManager;

        }

        [AllowAnonymous]

        [HttpPost("Authenticate")]

        public IActionResult Authenticate([FromBody] Login user)

        {

            var token = _customAuthenticationManager.Authenticate(user.userName, user.userPassword);

            if (token == null)

                return Unauthorized();

            return Ok(token);

        }


    }
}