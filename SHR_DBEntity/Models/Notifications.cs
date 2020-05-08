using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotificationManagementDBEntity.Models
{
    public partial class Notifications
    { 
        [Key]
        public int NotificationId { get; set; }
        public string NotificationName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserId { get; set; }

        public virtual UserDetails User { get; set; }
    }
}
