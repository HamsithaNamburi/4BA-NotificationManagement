using System;
using System.Collections.Generic;

namespace NotificationManagemntDBEntity.Models
{
    public partial class Notifications
    {
        public string NotificationId { get; set; }
        public string NotificationName { get; set; }
        public string About { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserId { get; set; }

        public virtual UserDetails User { get; set; }
    }
}
