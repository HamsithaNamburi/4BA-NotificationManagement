using NotificationManagement;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using NotificationManagementTestCases.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationManagementTestCases.Repository
{
    [TestFixture]
    class NotificationRepositoryTests
    {


        private INotificationRepository notificationRepository;
        private NotificationDBContext mockNotificationManagementContext;
        private NotificationData mockUserDatas;
        [SetUp]
        public void Setup()
        {
            mockNotificationManagementContext = new Sqlite().CreateSqliteConnection();
            notificationRepository = new NotificationRepository(mockNotificationManagementContext);
            mockUserDatas = new NotificationData();
        }
        /// <summary>
        /// To test GetAllNotifications 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetAllNotifications_Valid_Returns()
        {
            mockNotificationManagementContext.Notifications.AddRange(mockUserDatas.notification);
            await mockNotificationManagementContext.SaveChangesAsync();
            var getUserById = await notificationRepository.GetAllNotifications(1);
            Assert.That(getUserById, Is.Not.Null);
            //// Assert.That(getUserById, Is.EqualTo(10));

        }

        /// <summary>
        /// To test AddNotification
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddNotification_valid_Returns()
        {
            mockNotificationManagementContext.Notifications.AddRange(mockUserDatas.notification);
            await mockNotificationManagementContext.SaveChangesAsync();

            var getUserById = await notificationRepository.AddNotification(new Notifications()
            {
                NotificationId = 132,
                NotificationName = "NNNNtTR",
                Description = "hello hiii hiii",
                CreatedDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1,

            });
            bool b = true;
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById, Is.EqualTo(b));

        }
        /// <summary>
        /// To test UpdateNotification
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task UpdateNotification_Valid_Returns()
        {
            mockNotificationManagementContext.Notifications.AddRange(mockUserDatas.notification);
            await mockNotificationManagementContext.SaveChangesAsync();
            var getUserById = await notificationRepository.GetAllNotifications(10);
            //getUserById. = "Welcome to notification";
            var updatenotification = await notificationRepository.UpdateNotification(
                new Notifications()
                {
                    NotificationId = 101,
                    NotificationName = "NTYRE",
                    Description = "hello hiii hiiii",
                    CreatedDatetime = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UserId = 10,
                });
            Assert.That(updatenotification, Is.Not.Null);
            Assert.That(updatenotification, Is.EqualTo(true));
        }
        /// <summary>
        /// To test DeleteNotification
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteNotification_valid_Returns()
        {
            mockNotificationManagementContext.Notifications.AddRange(mockUserDatas.notification);
            await mockNotificationManagementContext.SaveChangesAsync();
            var getallnotification = await notificationRepository.DeleteNotification(100);
            Assert.That(getallnotification, Is.Null);
        }

    }
}