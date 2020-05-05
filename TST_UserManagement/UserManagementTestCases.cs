using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using NUnit.Framework;
using SHR_Model;
using System;
using System.Threading.Tasks;
using UserManagement.Helper;

namespace UserManagementTestCases
{
	[TestFixture]
	public class Tests
	{
		public UserRepository _userRepository;
		[SetUp]
		public void Setup()
		{
			_userRepository = new UserRepository(new NotificationDbContext());
		}
        [Test]
        [Description("TestUserLogin")]
        public async Task TestUserLogin()
        {
            var result = await _userRepository.UserLogin(new Login()
            {
                userName = "skvali5",
                userPassword = "abcd123"
            });
            Assert.IsNotNull(result);
        }
        [Test]
        [Description("TestUserRegister")]
        public async Task TestUserRegister()
        {
            await _userRepository.RegisterUser(new UserDetails()
            {
                FirstName = "vasu",
                LastName = "yadav",
                UserName = "yadav5",
                UserPassword = "xyz23",
                EmailAddr = "yadav5@gmail.com",
                ContactNumber = "7660947176",
                RegisteredDatetime = System.DateTime.Now,
                UserAddress = "Dronadula"

            });
        }
        [Test]
        [Description("user profile")]
        public async Task TestGetUser()
        {
            var result = await _userRepository.GetUser(1);
            Assert.NotNull(result);
        }
        [Test]
        [Description("update user")]
        public async Task UpdateUser()
        {
            UserDetails user = await _userRepository.GetUser(1);
            user.EmailAddr = "meera5@gmail.com";
            user.UpdatedDate = DateTime.Now;
            await _userRepository.UpdateUser(user);
            UserDetails user1 = await _userRepository.GetUser(1);
            Assert.AreSame(user, user1);

        }
    }
}