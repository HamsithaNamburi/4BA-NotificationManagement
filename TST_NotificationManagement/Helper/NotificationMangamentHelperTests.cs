using Moq;
using NotificationManagement.Helper;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using NotificationManagementTestCases.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationManagementTestCases.Helper
{
    class NotificationMangamentHelperTests
    {
        private NotificationMangementHelper notificationManagementHelper;
        private Mock<INotificationRepository> mockNotificationRepository;
        private NotificationData mockUserData;
        [SetUp]
        public void Setup()
        {
            mockNotificationRepository = new Mock<INotificationRepository>();
            mockUserData = new NotificationData();
            notificationManagementHelper = new NotificationMangementHelper(mockNotificationRepository.Object);

        }
        [Test]
        public async Task GetAllNotifications_Valid_Returns()
        {
            mockNotificationRepository.Setup(d => d.GetAllNotifications(It.IsAny<int>())).ReturnsAsync(mockUserData.notification);
            var result = await notificationManagementHelper.GetAllNotifications(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result.Count, Is.EqualTo(2));
        }
        [Test]
        public async Task GetAll_InValid_ReturnsNull()
        {
            mockNotificationRepository.Setup(d => d.GetAllNotifications(It.IsAny<int>())).ReturnsAsync((List<Notifications>)(null));
            var result = await notificationManagementHelper.GetAllNotifications(1);
            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task AddNotification_valid_Returns()
        {
            mockNotificationRepository.Setup(d => d.AddNotification(It.IsAny<Notifications>())).ReturnsAsync(true);
            var result = await notificationManagementHelper.AddNotification(new Notifications()
            {
                NotificationName = "Some NTYRE",
                Description = "hello",
                CreatedDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1,
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public async Task UpdateNotification_valid_Returns()
        {
            mockNotificationRepository.Setup(d => d.UpdateNotification(It.IsAny<Notifications>())).ReturnsAsync(true);
            var result = await notificationManagementHelper.UpdateNotification(new Notifications()
            {
                NotificationName = "HNTYRE",
                Description = "hello hiii",
                CreatedDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1,

            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public async Task DeleteNotification_Valid_Return()
        {
            mockNotificationRepository.Setup(d => d.DeleteNotification(It.IsAny<int>())).ReturnsAsync(true);
            var result = await notificationManagementHelper.DeleteNotification(110);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }


       
    }
}
