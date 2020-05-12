 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EO.WebBrowser.DOM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagementUI.Models;

namespace UserManagementUI.Controllers
{
    public class UserController : Controller
    {
        public static string url = "https://localhost:62518/api/v1/";
        // GET: User
        public async Task<IActionResult> Index()
        {
            List<UserDetails> userList = new List<UserDetails>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62518/api/v1/GetAllUsers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<UserDetails>>(apiResponse);
                }
            }
            return View(userList);
        }
        // GET: User/Create
        public async Task<IActionResult> RegisterUser()
        {
            return View();
        }
        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(UserDetails userDetails)
        {
            UserDetails userDetails1 = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:62518/api/v1/RegisterUser/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //userDetails1 = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public ViewResult GetUser() => View();

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            UserDetails userDetails = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62518/api/v1/GetUser/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   userDetails = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return View(userDetails);
        }
        public async Task<IActionResult> UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserDetails userDetails)
        {
            UserDetails user = userDetails;
            string apiResponse;
            UserDetails userDetails1 = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:62518/api/v1/UserLogin/", content))
                {
                    Console.WriteLine(response);
                    //UserDetails user = JsonConvert.DeserializeObject<UserDetails>(response);
                     apiResponse = await response.Content.ReadAsStringAsync();
                    // Console.WriteLine(apiResponse);
                    if (apiResponse == "Invalid User")
                    {
                        ViewBag.ErrorMessage = "Invalid Credentials";
                    }
                    else
                    {
                        userDetails1 = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                        TempData["UserId"] = userDetails1.UserId;
                    }
                    return RedirectToAction("GetAllNotifications", "Notification", new { id = userDetails1.UserId });
                    
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            UserDetails user = new UserDetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62518/api/v1/GetUser/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDetails userDetails)
        {
            UserDetails user = userDetails;
            user.UpdatedDate = DateTime.Now;
            string apiResponse;
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:62518/api/v1/UpdateUser/", stringContent))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    //ViewBag.Result = "Success";
                    //user = JsonConvert.DeserializeObject<UserDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}