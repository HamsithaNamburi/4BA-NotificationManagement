using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementUI.Models
{
    public partial class UserDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddr { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? RegisteredDatetime { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UserAddress { get; set; }
    }
}
