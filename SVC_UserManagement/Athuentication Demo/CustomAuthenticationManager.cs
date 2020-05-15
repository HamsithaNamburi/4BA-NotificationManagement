using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Athuentication_Demo
{

    public interface ICustomAuthenticationManager

    {

        string Authenticate(string username, string password);

        IDictionary<string, string> Tokens { get; }

    }

    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {
        private readonly NotificationDBContext _notificationDBContext;

        private readonly IDictionary<string, string> tokens = new Dictionary<string, string>();
        public CustomAuthenticationManager(NotificationDBContext notificationDBContext)
        {
            _notificationDBContext = notificationDBContext;
        }
        public IDictionary<string, string> Tokens => tokens;

        public string Authenticate(string username, string password)

        {
           UserDetails userDetails = _notificationDBContext.UserDetails.SingleOrDefault(i => i.UserName == username && i.UserPassword == password);
            if (userDetails == null)
            {

                return null;

            }
            else
            {
                var token = Guid.NewGuid().ToString();

                tokens.Add(token, password);

                return token;
            }

        }


    }
}




   
