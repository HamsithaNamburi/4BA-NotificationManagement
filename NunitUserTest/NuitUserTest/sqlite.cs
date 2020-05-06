using NotificationManagementDBEntity.Models;
using SHR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuitUserTest
{
    public interface ISqLite
    {
        bool RegisterUser(UserDetails userDetails);
        bool UpdateUser(UserDetails userDetails);
        UserDetails UserLogin(Login userLogin);
        UserDetails GetUser(int userId);
        List<UserDetails> GetAllUsers();
    }
    public class SqLite : ISqLite
    {
        private readonly NotificationDBContext _notificationDBContext;
        public SqLite(NotificationDBContext notificationDBContext)
        {
            _notificationDBContext = notificationDBContext;
        }
        public List<UserDetails> GetAllUsers()
        {
            return _notificationDBContext.UserDetails.ToList();
        }

        public bool UpdateUser(UserDetails userDetails)
        {
            _notificationDBContext.UserDetails.Update(userDetails);
            var UserId = _notificationDBContext.SaveChanges();
            if (UserId > 0)
                return true;
            else
                return false;
        }

        public UserDetails UserLogin(Login user)
        {
            return _notificationDBContext.UserDetails.SingleOrDefault(e => e.UserName == user.userName && e.UserPassword == user.userPassword);
        }

        public bool RegisterUser(UserDetails userDetails)
        {
            _notificationDBContext.UserDetails.Add(userDetails);
            var UserId = _notificationDBContext.SaveChanges();
            if (UserId > 0)
                return true;
            else
                return false;
        }

        public UserDetails GetUser(int userId)
        {
            return _notificationDBContext.UserDetails.Find(userId);
        }
    }
    }
