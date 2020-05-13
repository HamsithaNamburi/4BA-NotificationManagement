using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Helper;
using UserManagementTestCases.Data;

namespace UserManagementTestCases.Repository
{
    [TestFixture]
    class UserRepositoryTests
    {
        private IUserRepository userRepository;
        private NotificationDBContext mockNotificationManagementContext;
        private userData mockUserDatas;
        [SetUp]
        public void Setup()
        {
            mockNotificationManagementContext = new Sqlite().CreateSqliteConnection();
            userRepository = new UserRepository(mockNotificationManagementContext);
            mockUserDatas = new userData();
        }
        [Test]
        public async Task GetAllUsers_Valid_Returns()
        {
            mockNotificationManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockNotificationManagementContext.SaveChangesAsync();
            var getAllUser = await userRepository.GetAllUsers();
            Assert.That(getAllUser, Is.Not.Null);
            Assert.That(getAllUser.Count, Is.EqualTo(2));

        }


        [Test]
        public async Task RegisterUser_valid_Returns()
        {
            mockNotificationManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockNotificationManagementContext.SaveChangesAsync();

            var getUserById = await userRepository.RegisterUser(new UserDetails()
            {
               // UserId = 12,
                FirstName = "sai",
                LastName = "manu",
                UserName = "sri",
                UserPassword = "1234",
                EmailAddr = "manu@gmail.com",
                ContactNumber = "9988712345",
                RegisteredDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserAddress = "chennai"

            });
            bool b = true;
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById, Is.EqualTo(b));

        }




        [Test]
        public async Task GetUser_Valid_Returns()
        {
            mockNotificationManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockNotificationManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.GetUser(10);
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById.UserId, Is.EqualTo(10));

        }


        [Test]
        public async Task UpdateUser_valid_Returns()
        {
            mockNotificationManagementContext.UserDetails.AddRange(mockUserDatas.userDetails);
            await mockNotificationManagementContext.SaveChangesAsync();
            var getUserById = await userRepository.UpdateUser(
                new UserDetails()
                {
                    //UserId = 18,
                    UserName = "hello11123",
                    EmailAddr = "hello@gmail.com",
                    UserPassword = "hello1",
                    UserAddress = "tnllll",
                    RegisteredDatetime = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    ContactNumber = "6583920836",
                    FirstName = "hello1",
                    LastName = "hello1"

                });
            Assert.That(getUserById, Is.Not.Null);
            Assert.That(getUserById, Is.EqualTo(true));
        }



    }
}