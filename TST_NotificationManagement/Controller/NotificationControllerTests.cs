using Microsoft.AspNetCore.Mvc;
using Moq;
using NotificationManagement;
using NotificationManagement.Helper;
using NotificationManagementDBEntity.Models;
using NotificationManagementTestCases.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationManagementTestCases.Controller
{
    class NotificationControllerTests
    {
        private NotificationController notificationsController;
        private Mock<INotificationManagementHelper> mockNotificationManagementHelper;
        private NotificationData mockNotificationData;
        [SetUp]
        public void Setup()
        {
            mockNotificationManagementHelper = new Mock<INotificationManagementHelper>();
            mockNotificationData = new NotificationData();
            notificationsController = new NotificationController(mockNotificationManagementHelper.Object);
        }
        [Test]
        public async Task GetAllUsers_Valid_Return()
        {
            mockNotificationManagementHelper.Setup(d => d.GetAllNotifications(It.IsAny<int>())).ReturnsAsync(mockNotificationData.notification);
            var result = await notificationsController.GetAllNotifications(101);
            Assert.That(result, Is.Not.Null);
        }
        /// <summary>
        /// To Test the Exception for GetAllUsers
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllnotifications_Invalid_ReturnsNull()
        {
            mockNotificationManagementHelper.Setup(d => d.GetAllNotifications(It.IsAny<int>())).ReturnsAsync((List<Notifications>)(null));
            var result = await notificationsController.GetAllNotifications(101);
            Assert.That(result, Is.Not.Null);

        }

        [Test]
        public async Task UpdateUser_valid_Returns()
        {
            mockNotificationManagementHelper.Setup(d => d.UpdateNotification(It.IsAny<Notifications>())).ReturnsAsync(new bool());
            var result = await notificationsController.UpdateNotification(new Notifications()
            {
                NotificationId = 203,
                NotificationName = "NTYRE",
                Description = "hello hiii",
                CreatedDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1,
            }) as OkResult;
            Assert.That(result, Is.Not.Null);
            //Assert.That(result, Is.Not.Null);
            //Assert.That(result, Is.EqualTo(true));
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }


        [Test]
        public async Task AddNotification_valid_Returns()
        {
            mockNotificationManagementHelper.Setup(d => d.AddNotification(It.IsAny<Notifications>())).ReturnsAsync(new bool());
            var result = await notificationsController.AddNotification(new Notifications()
            {
                NotificationId = 203,
                NotificationName = "NTYRE",
                Description = "hello hiii",
                CreatedDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1,
            }) as OkResult;
            Assert.That(result, Is.Not.Null);

            Assert.That(result.StatusCode, Is.EqualTo(200));

        }


    }
}
