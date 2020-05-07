using Moq;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Helper;
using UserManagementTestCases.Data;

namespace UserManagementTestCases.Helper
{
    class UserManagementHelperTests
    {
        private UserManagementHelper userManagementHelper;
        private Mock<IUserRepository> mockUserRepository;
        private userData mockUserData;
        [SetUp]
        public void Setup()
        {
            mockUserRepository = new Mock<IUserRepository>();
            mockUserData = new userData();
            userManagementHelper = new UserManagementHelper(mockUserRepository.Object);

        }
        [Test]
        public async Task GetAllUsers_Valid_Returns()
        {
            mockUserRepository.Setup(d => d.GetAllUsers()).ReturnsAsync(mockUserData.userDetails);
            var result = await userManagementHelper.GetAllUsers();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.Count, Is.EqualTo(2));
        }
        [Test]
        public async Task GetAll_InValid_ReturnsNull()
        {
            mockUserRepository.Setup(d => d.GetAllUsers()).ReturnsAsync((List<UserDetails>)(null));
            var result = await userManagementHelper.GetAllUsers();
            Assert.That(result, Is.Null);
        }



       


    }
}





