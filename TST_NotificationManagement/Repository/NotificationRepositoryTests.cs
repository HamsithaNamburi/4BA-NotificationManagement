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
            [Test]
            public async Task GetAllNotifications_Valid_Returns(int UserId)
            {
                mockNotificationManagementContext.Notifications.AddRange(mockUserDatas.notification);
                await mockNotificationManagementContext.SaveChangesAsync();
            var getUserById = await notificationRepository.GetAllNotifications(UserId);
            Assert.That(getUserById, Is.Not.Null);
           //// Assert.That(getUserById, Is.EqualTo(10));

             }


            [Test]
            public async Task AddNotification_valid_Returns()
            {
                mockNotificationManagementContext.Notifications.AddRange(mockUserDatas.notification);
                await mockNotificationManagementContext.SaveChangesAsync();

                var getUserById = await notificationRepository.AddNotification(new Notifications()
                {
                    // UserId = 12,
                    NotificationId = 132,
                    NotificationName = "NNNNtTR",
                    Description = "hello hiii hiii",
                    CreatedDatetime = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UserId = 1,

                });
               // bool b = true;
                Assert.That(getUserById, Is.Not.Null);
                Assert.That(getUserById, Is.EqualTo(true));

            }




          


            //[Test]
            //public async Task UpdateNotification_Valid_Returns(Notifications notifications)
            //{
            //    mockNotificationManagementContext.Notifications.AddRange(mockUserDatas.notification);
            //    await mockNotificationManagementContext.SaveChangesAsync();
            //    var getUserById = await notificationsRepository.GetUser(10);
            //    notifications.NotificationName = "Welcome to notification";
            //    var updateUser = await notificationRepository.UpdateNotification(notifications);
            //    UserDetails user1 = await notificationRepository.GetUser(10);
            //    Assert.AreSame(updateUser, user1);
            //}



        }
    }
