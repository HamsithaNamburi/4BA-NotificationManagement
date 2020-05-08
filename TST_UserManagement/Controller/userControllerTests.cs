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
            Assert.That(result, Is.Null);
        }
    }
}
