using NabavkeSolutionCore.Models.Mobile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace NabavkeSolutionCore.Models.Helpers
{
    public interface INotificationHandler
    {
        Device GetDevices();
        string CreateNotifications(string message, string[] palyers);
    }

    public class NotificationHandler:INotificationHandler
    {
        private readonly IOptions<OneSignalAPIKey> OneSignalAPIKey;

        public NotificationHandler(IOptions<OneSignalAPIKey> oneSignalAPIKey)
        {
            OneSignalAPIKey = oneSignalAPIKey;
        }
        public Device GetDevices()
        {
            var request = WebRequest.Create("https://onesignal.com/api/v1/players?app_id="
                +OneSignalAPIKey.Value.App_ID) as HttpWebRequest;

            
            Device devices = new Device();
            request.KeepAlive = true;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", $"Basic {OneSignalAPIKey.Value.APIKey}");
            
           
            string responseContent = null;

            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            System.Diagnostics.Debug.WriteLine(responseContent);
            return devices = JsonConvert.DeserializeObject<Device>(responseContent);
        }
        public string CreateNotifications(string message, string[] palyers)
        {
            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", $"Basic {OneSignalAPIKey.Value.APIKey}");
            var time = DateTime.UtcNow + new TimeSpan(2, 0, 0);
            DateTime time2;
            if (time.Hour < 10)
                time2 = new DateTime(time.Year, time.Month, time.Day, 8, 0, 0, DateTimeKind.Utc);
            else time2 = new DateTime(time.Year, time.Month, time.Day + 1, 8, 0, 0, DateTimeKind.Utc);

            var obj = new
            {
                app_id = OneSignalAPIKey.Value.App_ID
                   .Substring(0, 36),
                include_player_ids = palyers,
                contents = new { en = message },
                send_after = time2.ToString("yyyy-MM-dd hh:mm:ss") + " GMT",
            };



            var param = JsonConvert.SerializeObject(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();

                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            System.Diagnostics.Debug.WriteLine(responseContent);
            return responseContent;
        }


    }
}