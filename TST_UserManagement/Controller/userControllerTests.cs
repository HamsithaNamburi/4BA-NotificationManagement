using Microsoft.AspNetCore.Mvc;
using Moq;
using NotificationManagementDBEntity.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;
using UserManagement;
using UserManagement.Helper;
using UserManagementTestCases.Data;

namespace UserManagementTestCases.Controller
{
    [TestFixture]
    class userControllerTests
    {
        private UserController userController;
        private Mock<IUserManagementHelper> mockUserManagementHelper;
        private userData mockUserDatas;
        [SetUp]
        public void Setup()
        {
            mockUserManagementHelper = new Mock<IUserManagementHelper>();
            mockUserDatas = new userData();
            userController = new UserController(mockUserManagementHelper.Object);
        }
        /// <summary>
        /// To Test the GetAllUsers
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllUsers_Valid_Return()
        {
            mockUserManagementHelper.Setup(d => d.GetAllUsers()).ReturnsAsync(mockUserDatas.userDetails);
            var result = await userController.GetAllUsers();
            Assert.That(result, Is.Not.Null);
        }
        /// <summary>
        /// To Test the Exception for GetAllUsers
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllUsers_Invalid_ReturnsNull()
        {
            mockUserManagementHelper.Setup(d => d.GetAllUsers()).ReturnsAsync((List<UserDetails>)(null));
            var result = await userController.GetAllUsers();
            Assert.That(result, Is.Not.Null);
        }


        /// <summary>
        /// To get details of a particular user by using userId
        /// </summary>

        /// <returns></returns>
        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.GetUser(It.IsAny<int>()));
            var result = await userController.GetUser(10);
            Assert.That(result, Is.Not.Null);

        }
       
        /// <summary>
        /// For a new user to register
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task RegisterUser_valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.RegisterUser(It.IsAny<UserDetails>())).ReturnsAsync(new bool());
            var result = await userController.RegisterUser(new UserDetails()
            {
                UserId = 67,
                UserName = "Abc",
                EmailAddr = "Abc@gmail.com",
                UserPassword = "4545",
                UserAddress = "Ap",
                RegisteredDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ContactNumber = "9874563210",
                FirstName = "Abc",
                LastName = "Xyz"
            }) as OkResult;
            Assert.That(result, Is.Not.Null);
            //   IActionResult actionResult = result.ExecuteResultAsync();
            // Assert.That(result., Is.Not.Null);

            Assert.That(result.StatusCode, Is.EqualTo(200));
        }




        [Test]
        public async Task UpdateUser_valid_Returns()
        {
            mockUserManagementHelper.Setup(d => d.UpdateUser(It.IsAny<UserDetails>())).ReturnsAsync(new bool());
            var result = await userController.UpdateUser(new UserDetails()
            {
                UserId = 10,
                UserName = "Abc1",
                EmailAddr = "Abc1@gmail.com",
                UserPassword = "4545",
                UserAddress = "Apppp",
                RegisteredDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ContactNumber = "9874563210",
                FirstName = "Abc1",
                LastName = "Xyz"
            }) as OkResult;
            Assert.That(result, Is.Not.Null);
            //Assert.That(result, Is.Not.Null);
            //Assert.That(result, Is.EqualTo(true));
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
    }
}
