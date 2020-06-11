using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class AddUpdateCenterUser
    {
        public Int64 Id { get; set; }
        public Int64 ContactTypeId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 UserTypeId { get; set; }
        public string JobTitle { get; set; }
        public Int64 CenterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string OfficeNo { get; set; }
        public string Department { get; set; }
        public Int64? CreatedBy { get; set; }     
        public Int64? UpdatedBy { get; set; }     
    }
}