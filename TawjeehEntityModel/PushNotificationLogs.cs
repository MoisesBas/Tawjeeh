﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tawjeeh.EntityModel
{
   public class PushNotificationLogs
    {
       
        public Int64 Id { get; set; }
        public int NotificationType { get; set; }   
      
       
        public Int64? InitiativeCampaignId { get; set; }
        public string Topic { get; set; }
        public Int64? RecieveCnt { get; set; }
        public Int64? SendCnt { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Int64? UpdatedBy { get; set; }
    }
}
