using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Tawjeeh.Entities;
using Tawjeeh.SMSBulkSending.Helper;
using Tawjeeh.SMSBulkSending.Notification.Model;

namespace Tawjeeh.SMSBulkSending.Notification
{
    public class PushNotification:IPushNotification
    {     
        private Config _config;
        public PushNotification(Config config)
        {
            _config = config;
        }      
        public bool SendToSingle(PushNotificationLogs fcmdevice)
        {
            bool status = SendNotification(fcmdevice);
            return status;
        }
        public bool SendToMultiple(List<PushNotificationLogs> fcmdevices)
        {
            bool status = false;
            foreach (var device in fcmdevices)
            {
                status = SendNotification(device);
            }
            return status;
        }
        private bool SendNotification(PushNotificationLogs fcmdevices)
        {
            bool status = true;
            try
            {              
                WebRequest tRequest = WebRequest.Create(Utilities.fcmURL);
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = Utilities.deviceToken,
                    priority = Utilities.priority,
                    notification = new
                    {
                        body = fcmdevices.Topic,
                        title = "Ïnitiative Campaign",
                        notification_id = fcmdevices.InitiativeCampaignId                       
                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", _config.ApplicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", _config.SenderID));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                JObject sResponse = JObject.Parse(sResponseFromServer);
                                status = Convert.ToInt32(sResponse["success"]) == 1 ? true : false;                               
                            }
                        }
                    }
                }
            }

            catch (Exception)
            {
                status = false;
            }
            return status;
        }

       
    }
}
