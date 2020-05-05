using System;
using System.Collections.Generic;

namespace NotificationManagementDBEntity.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationName { get; set; }
        public string NotificationDesc { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserId { get; set; }

        public virtual UserDetails User { get; set; }
    }
}
