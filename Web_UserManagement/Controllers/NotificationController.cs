using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotificationManagementUI.Models;

namespace UserManagementUI.Controllers
{
    public class NotificationController : Controller
    {
        public static string url = "https://localhost:62545/api/v1/";

        //public ViewResult GetAllNotifications() => View();
        /// <summary>
        /// Getting notifications based on user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllNotifications(int id)
        {
            List<Notifications> notificationDetails = new List<Notifications>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62545/api/v1/GetAllNotifications/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    notificationDetails = JsonConvert.DeserializeObject<List<Notifications>>(apiResponse);
                }
            }
            TempData["id"] = id;
           //n View(productList);
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
        public async Task<IActionResult> AddNotification(Notifications notifications)
        {
            Notifications notifiy = notifications;
            int userId = Convert.ToInt32(TempData["UserId"]);
            notifiy.UserId = userId;
            ViewBag.UserId = userId;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(notifiy), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:62545/api/v1/AddNotification/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //notifiy = JsonConvert.DeserializeObject<Notifications>(apiResponse);
                }
            }
            return RedirectToAction("GetAllNotifications", new { id = userId });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            Notifications notify = new Notifications();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62545/api/v1/GetNotification/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    notify = JsonConvert.DeserializeObject<Notifications>(apiResponse);
                }
            }
            TempData["id"] = notify.UserId;
            return View(notify);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(Notifications notifications)
        {
            Notifications notify = notifications;
            int userId = Convert.ToInt32(TempData["UserId"]);
            notifications.UpdatedDate = DateTime.Now;
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(notify), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:62545/api/v1/UpdateNotification/", stringContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetAllNotifications", new { id = userId });
        }
        [HttpGet]
        public async Task<IActionResult> DeleteNotification(int? id)
        {
            Notifications notify = new Notifications();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62545/api/v1/GetNotification/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    notify = JsonConvert.DeserializeObject<Notifications>(apiResponse);
                }
            }
            return View(notify);
        }
        [HttpPost]
        [ActionName("DeleteNotification")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            int userId = Convert.ToInt32(TempData["UserId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:62545/api/v1/DeleteNotification/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("GetAllNotifications", new { id = userId });
        }
    }
}