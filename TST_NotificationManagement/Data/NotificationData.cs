using NotificationManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationManagementTestCases.Data
{
    class NotificationData
    {
        public List<Notifications> notification { get; private set; }
        public NotificationData()
        {
            notification = new List<Notifications>(){new  Notifications() { NotificationId = 100, NotificationName = "5678543",Description ="hello"
            ,CreatedDatetime=DateTime.Now,UpdatedDate=DateTime.Now,UserId = 10,
           },

           new Notifications()
            {
               
               
                NotificationName = "NTYRE",
                Description = "hello hiii",
                CreatedDatetime = DateTime.Now,
                UpdatedDate = DateTime.Now,
                 UserId = 1,


           }};

        }

    }
}
