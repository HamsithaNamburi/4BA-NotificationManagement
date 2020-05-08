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


        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockUserRepository.Setup(d => d.GetUser(It.IsAny<int>())).ReturnsAsync(new UserDetails());
            var result = await userManagementHelper.GetUser(10);
            Assert.That(result, Is.Not.Null);
            /*            Assert.That(result.UserId, Is.EqualTo(10));*/
        }

        [Test]
        public async Task GetUser_InValid_ReturnsNull()
        {
            mockUserRepository.Setup(d => d.GetUser(It.IsAny<int>())).ReturnsAsync((UserDetails)(null));
            var result = await userManagementHelper.GetUser(10);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task RegisterUser_valid_Returns()
        {
            mockUserRepository.Setup(d => d.RegisterUser(It.IsAny<UserDetails>())).ReturnsAsync(true);
            var result = await userManagementHelper.RegisterUser(new UserDetails()
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
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public async Task UpdateUser_valid_Returns()
        {
            mockUserRepository.Setup(d => d.UpdateUser(It.IsAny<UserDetails>())).ReturnsAsync(true);
            var result = await userManagementHelper.UpdateUser(new UserDetails()
            {
                UserId = 10,
                UserName = "Abc1",
                EmailAddr = "Abc1@gmail.com",
                UserPassword = "4545",
                UserAddress = "Ap",
               RegisteredDatetime= DateTime.Now,
                UpdatedDate = DateTime.Now,
                ContactNumber = "9874563210",
                FirstName = "Abc1",
                LastName = "Xyz"
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }


    }
}





