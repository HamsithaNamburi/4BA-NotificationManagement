using System;
using System.Collections.Generic;

namespace NotificationManagemntDBEntity.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            Notifications = new HashSet<Notifications>();
        }

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? RegisteredDateTime { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserAddress { get; set; }

        public virtual ICollection<Notifications> Notifications { get; set; }
    }
}
