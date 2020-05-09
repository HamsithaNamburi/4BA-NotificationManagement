using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotificationManagementUI.Models;

namespace NotificationManagementUI.Controllers
{
    public class NotificationController : Controller
    {

        public static string url = "https://localhost:62545/api/v1/";

        public ViewResult GetAllNotifications() => View();
       /// <summary>
       /// Getting notifications based on user id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllNotifications(int id)
        {
            Notifications notificationDetails = new Notifications();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62545/api/v1/GetAllNotifications/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   // notificationDetails = JsonConvert.DeserializeObject<Notifications>(apiResponse);
                }
            }
            return View(notificationDetails);
        }



        /// <summary>
        /// To addnotification
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AddNotification()
        {
            return View();
        }
       /// <summary>
       /// to add notifications using post
       /// </summary>
       /// <param name="userDetails"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNotification(Notifications userDetails)
        {
            Notifications notifiy= new Notifications();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:62545/api/v1/AddNotification/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    notifiy = JsonConvert.DeserializeObject<Notifications>(apiResponse);
                }
            }
            return RedirectToAction("GetAllNotifications");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(string notid)
        {
            Notifications notify = new Notifications();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62545/api/v1/UpdateNotification/" + notid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    notify = JsonConvert.DeserializeObject<Notifications>(apiResponse);
                }
            }
            return View(notify);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(Notifications notifications)
        {
            Notifications notify = new Notifications();
            int notid = notify.NotificationId;
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(notify.UserId.ToString()), "UserId");
                content.Add(new StringContent(notify.NotificationName), "NotificationName");
                content.Add(new StringContent(notify.Description), "Description");
                content.Add(new StringContent(notify.CreatedDatetime.ToString()), "CreatedDatetime");
               
                content.Add(new StringContent(notify.UpdatedDate.ToString()), "UpdatedDate");

                content.Add(new StringContent(notify.NotificationId.ToString()), "NotificationId");
                using (var response = await httpClient.PutAsync("http://localhost:62545/api/v1/UpdateNotification/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    notify = JsonConvert.DeserializeObject<Notifications>(apiResponse);
                }
            }
            return RedirectToAction("GetAllNotifications");
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteNotification(string notid)
        {
            Notifications notify = new Notifications();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62545/api/v1/DeleteNotification/" + notid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    notify = JsonConvert.DeserializeObject<Notifications>(apiResponse);
                }
            }
            return View(notify);
        }



    }
}