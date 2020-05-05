using System;
using System.Collections.Generic;

namespace NotificationManagementDBEntity.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            Notification = new HashSet<Notification>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPassword { get; set; }
        public string EmailAddr { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UserAddress { get; set; }

        public virtual ICollection<Notification> Notification { get; set; }
    }
}
